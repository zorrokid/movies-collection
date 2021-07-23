using System.Collections.Generic;
using System.Linq;
using Application.Extensions;
using Domain.Entities;
using Domain.Enumerations;
using Infrastructure.Integration.CSV.Exceptions;
using Infrastructure.Integration.CSV.Importers.MediaItemsStrategy;
using Infrastructure.Integration.CSV.Models;
using Infrastructure.Persistence.Database;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Integration.CSV.Importers
{
    public interface ICsvImporter
    {
         void Import(IEnumerable<CsvRow> csvRow);
    }

    public class CsvImporter : ICsvImporter
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly ILogger<CsvImporter> logger;

        public CsvImporter(IUnitOfWork unitOfWork, ILogger<CsvImporter> logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

        public void Import(IEnumerable<CsvRow> csvRows)
        {
            // Import first rows which are marked as collection since some other rows are part of that collection
            var collections = csvRows.Where(row => row.ProductionType == ProductionTypeEnum.Collection);
            ImportCollectionRows(collections);

            var collectionItems = csvRows.Where(row => row.ProductionType != ProductionTypeEnum.Collection);
            ImportCollectionItemRows(collectionItems);
        }

        private void ImportCollectionRows(IEnumerable<CsvRow> csvRows)
        {
            foreach (var csvRow in csvRows)
            {
                if (unitOfWork.Publications.GetByImportOrigin((int)ImportOriginEnum.CustomCsv, csvRow.Id) != null)
                {
                    logger.LogWarning($"Publication with id {csvRow.Id} already imported - skipping.");
                    continue;
                }

                var publication = CreatePublication(csvRow, csvRow.Id);
                unitOfWork.Publications.Add(publication);
            }
        }

        private void ImportCollectionItemRows(IEnumerable<CsvRow> csvRows)
        {
            foreach (var csvRow in csvRows)
            {
                ImportCollectionItem(csvRow);
            }
        }

        private void ImportCollectionItem(CsvRow csvRow)
        {

            logger.LogInformation($"Start importing {csvRow}");

            var externalId = CreateExternalId(csvRow);

            logger.LogInformation($"Created externalId '{externalId}'");

            if (unitOfWork.PublicationItems.GetByImportOrigin((int)ImportOriginEnum.CustomCsv, externalId) != null)
            {
                logger.LogWarning($"Publication item with id {externalId} already imported - skipping.");
                return;
            }

            logger.LogInformation($"Creating new publication item of {csvRow}.");
            var publication = GetPublication(csvRow, externalId);
            var publicationItem = new PublicationItem
            {
                Production = GetProduction(csvRow),
                ImportOriginId = (int) ImportOriginEnum.CustomCsv,
                IdInImportOrigin = externalId
            };
            publicationItem.MediaItems.AddRange(GetMediaItems(csvRow));
            publication.PublicationItems.Add(publicationItem);

            publicationItem.SubtitleLanguages.AddRange(CreateSubtitles(csvRow));

            logger.LogInformation($"Created publication item {publicationItem}");
            if (publication.Id == 0)
            {
                logger.LogInformation($"Adding publication item {publicationItem} to db.");
                unitOfWork.Publications.Add(publication);
            }
            else
            {
                logger.LogInformation($"Updating publication item {publicationItem.Id} to db.");
                unitOfWork.Publications.Update(publication);
            }
            logger.LogInformation($"Finish importing {csvRow}");
        }

        private string CreateExternalId(CsvRow csvRow)
        {
            // Id from source material cannot be used since there are duplicate Id's
            // Combine externalId from fields: Id, Barcode, CollecionId
            var idParts = new string[]{ csvRow.Id, csvRow.Barcode, csvRow.IMDBCode, csvRow.CollectionId }
                .Where(id => !string.IsNullOrWhiteSpace(id))
                .ToArray();

            if (!idParts.Any()) throw new CsvImportException($"Could not create externalId for {csvRow}.");
            return string.Join("|", idParts);
        }

        private Publication CreatePublication(CsvRow csvRow, string externalId)
        {
            var publication = new Publication
            {
                ImportOriginId = (int)ImportOriginEnum.CustomCsv,
                IdInImportOrigin = externalId,
                IsVerified = csvRow.IsChecked,
                Barcode = csvRow.Barcode,
                HasBooklet = csvRow.HasLeaflet,
                HasHologram = csvRow.HasHologram,
                HasSlipCover = csvRow.HasSlipCover,
                IsRental = csvRow.IsRental,
                HasTwoSidedCover = csvRow.HasTwoSidedCover,
                Notes = csvRow.Notes,
                OriginalTitle = csvRow.OriginalTitle,
                LocalTitle = csvRow.LocalTitle,
                CaseTypeId = (int) csvRow.CaseType,
                CountryCode = csvRow.Country,
                ConditionClassId = (int) csvRow.Condition
            };

            if (csvRow.Publisher != null)
            {
                publication.PublicationCompanyRoles.Add(CreatePublicationCompanyRole(csvRow));
            }
            return publication;
        }

        private PublicationCompanyRole CreatePublicationCompanyRole(CsvRow csvRow)
        {
            var publisherName = csvRow.Publisher;
            Company publisher = unitOfWork.Companies.GetByName(csvRow.Publisher).FirstOrDefault();
            if (publisher == null)
            {
                publisher = new Company
                {
                    Name = publisherName
                };
            }
            var publisherRole = unitOfWork.CompanyRoleTypes.GetById((int)CompanyRoleEnum.Publisher);
            var publicationCompanyRole = new PublicationCompanyRole
            {
                Company = publisher,
                Role = publisherRole
            };
            return publicationCompanyRole;
        }

        private List<SubtitleLanguage> CreateSubtitles(CsvRow csvRow)
        {
            List<SubtitleLanguage> subtitles = new();
            if (csvRow.HasSubEn)
            {
                subtitles.Add(new SubtitleLanguage
                {
                    LanguageCode = "en"
                });
            }
            if (csvRow.HasSubFi)
            {
                subtitles.Add(new SubtitleLanguage
                {
                    LanguageCode = "fi"
                });
            }
            return subtitles;
        }

        private List<MediaItem> GetMediaItems(CsvRow csvRow)
        {
            logger.LogInformation($"Creating media items, types: {csvRow.MediaType.Length}, discs: {csvRow.Discs}");
            var strategy = MediaItemsStrategyFactory.GetStrategy(csvRow);
            return strategy.Create(csvRow);
        }

        private Publication GetPublication(CsvRow csvRow, string externalId)
        {
            Publication publication = null;

            // For publication item publication id depends wether CollectionId is set or not:
            // - if CollectionId is set, this row is part of some publication (containing multiple publication items), add item as part of that publication
            // - otherwise create a publication of this row containing a publication item created also from itself
            var publicationId = csvRow.CollectionId;

            if (!string.IsNullOrEmpty(publicationId))
            {
                logger.LogInformation($"Checking if there's existing publication with id {publicationId}");
                publication = unitOfWork.Publications.GetByImportOrigin((int) ImportOriginEnum.CustomCsv, publicationId);
                if (publication == null) throw new CsvImportException($"Didn't find publication for item with CollectionId {publicationId}.");
            }
            else
            {
                publication = CreatePublication(csvRow, externalId);
                logger.LogInformation($"Created new publication {publication}");
            }
            if (publication == null)
            {
                throw new CsvImportException($"Failed geting/creating publication for {csvRow}");
            }
            return publication;
        }

        private Production GetProduction(CsvRow csvRow)
        {
            if (string.IsNullOrEmpty(csvRow.OriginalTitle))
            {
                throw new CsvImportException("OriginalTitle-field is missing");
            }

            var production = new Production
            {
                ProductionTypeId = (int)csvRow.ProductionType,
                OriginalTitle = csvRow.OriginalTitle
            };

            production.ProductionPersonRoles.AddRange(GetProductionPersonRoles(csvRow));
            production.ProductionCompanyRoles.AddRange(GetProductionCompanyRoles(csvRow));

            // TODO check productions with same name and type and merge data?            
            // var productions = unitOfWork.Productions.GetProductionsByNameAndType(csvRow.OriginalTitle, csvRow.ProductionType);

            return production;
        }

        private List<ProductionCompanyRole> GetProductionCompanyRoles(CsvRow csvRow)
        {
            Company studio = null;
            List<ProductionCompanyRole> companyRoles = new(); 
            
            if (!string.IsNullOrEmpty(csvRow.Studio)) 
            {
                studio = unitOfWork.Companies.GetByName(csvRow.Studio).FirstOrDefault(); 
                logger.LogInformation($"Got company {studio} from db");

                if (studio == null)
                {
                    logger.LogInformation($"Create new company {csvRow.Studio}");
                    studio = new Company { Name = csvRow.Studio };
                    unitOfWork.Companies.Add(studio);
                }
                companyRoles.Add(new ProductionCompanyRole
                {
                    Company = studio,
                    CompanyRoleTypeId = (int) CompanyRoleEnum.Studio
                });
            }
            return companyRoles;
        }

        private List<ProductionPersonRole> GetProductionPersonRoles(CsvRow csvRow)
        {
            var directorNames = csvRow.Directors;
            var directors = new List<ProductionPersonRole>();
            foreach(var directorName in directorNames)
            {
                var person = unitOfWork.Persons.GetByName(directorName).FirstOrDefault();
                if(person == null)
                {
                    person = new Person
                    {
                        Name = directorName,
                        GivenName = directorName.GivenName(),
                        Surname = directorName.FamilyName()
                    };
                    unitOfWork.Persons.Add(person);
                }
                directors.Add(new ProductionPersonRole
                {
                    Person = person,
                    PersonRoleTypeId = (int)PersonRoleEnum.Director
                });
            }
            return directors;
        }
    }
}