using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Enumerations;
using Infrastructure.Integration.CSV.Exceptions;
using Infrastructure.Integration.CSV.Importers.MediaItemsStrategy;
using Infrastructure.Integration.CSV.Models;
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
            logger.LogInformation($"Importing {csvRow}");
            var publication = GetPublication(csvRow);
            if (publication.PublicationItems.Count() > 0)
            {
                logger.LogWarning($"Publication {publication.Id} already imported, skipping.");
                return;
            }
            var publicationItem = new PublicationItem
            {
                Production = GetProduction(csvRow)
            };
            publicationItem.MediaItems.AddRange(GetMediaItems(csvRow));
            publication.PublicationItems.Add(publicationItem);
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
        }

        private List<MediaItem> GetMediaItems(CsvRow csvRow)
        {
            var strategy = MediaItemsStrategyFactory.GetStrategy(csvRow);
            return strategy.Create(csvRow);
        }

        private Publication GetPublication(CsvRow csvRow)
        {
            Publication publication = null;
            var publicationId = csvRow.CollectionId;
            if (!string.IsNullOrEmpty(publicationId))
            {
                logger.LogInformation($"Trying to find publication with id {csvRow.CollectionId}");
                publication = unitOfWork.Publications.GetByImportOrigin((int) ImportOriginEnum.CustomCsv, publicationId);
            }
            else
            {
                publication = CreatePublication(csvRow);
            }
            if (publication == null)
            {
                throw new CsvImportException("Failed geting/creating publication.");
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
                // var person = personRepository.GetByName(directorName).FirstOrDefault();
                // if(person != null)
                // {
                //     directors.Add(person);
                // }
                // else 
                // {
                //     var newPerson = new Person
                //     {
                //         Name = directorName,
                //         GivenName = directorName.GivenName(),
                //         Surname = directorName.FamilyName()
                //     };
                //     personRepository.Add(newPerson);
                //     directors.Add(newPerson);
                // }
            }
            return directors;
        }
    }
}