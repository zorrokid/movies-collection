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
    public class PublicationItemCsvImporter : AbstractCsvImporter, ICsvImporter<CsvRow>
    {

        public PublicationItemCsvImporter(IUnitOfWork unitOfWork, ILogger<PublicationItemCsvImporter> logger) 
            : base(unitOfWork, logger)
        {
        }
        
        public void Import(CsvRow csvRow)
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

            // For publication item publication id depends weather CollectionId is set or not:
            // - if CollectionId is set, this row is part of some publication (containing multiple publication items)
            // - otherwise create a publication of this row containing publication item also created of this same row
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
            Company studio = null;
            
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
            }

            var production = new Production
            {
                ProductionTypeId = (int)csvRow.ProductionType,
                OriginalTitle = csvRow.OriginalTitle
            };

            production.PersonRoles.AddRange(GetDirectors(csvRow));

            return production;
        }

        private List<ProductionPersonRole> GetDirectors(CsvRow csvRow)
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