using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
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
            var publicationItem = new PublicationItem
            {
                Production = GetProduction(csvRow)
            };
            publicationItem.MediaItems.AddRange(GetMediaItems(csvRow));
            publication.PublicationItems.Add(publicationItem);
            logger.LogInformation($"Created publication item {publicationItem}");
            unitOfWork.Publications.Add(publication);
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
            if (publicationId != null)
            {
                publication = unitOfWork.Publications.GetById((int)publicationId);
            }
            else
            {
                publication = CreatePublication(csvRow);
            }
            return publication;
        }

        private Production GetProduction(CsvRow csvRow)
        {
            var productionType = unitOfWork.ProductionTypes.GetById((int)csvRow.ProductionType); 
            logger.LogInformation($"Got production type {productionType.Id} {productionType.Name} from db");

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
                ProductionType = productionType,
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