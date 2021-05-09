using System.Collections.Generic;
using System.Linq;
using Application.Extensions;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Csv.Models;

namespace Infrastructure.Persistence.Csv.Importers
{
    public class PublicationItemCsvImporter : AbstractCsvImporter, ICsvImporter
    {
        private readonly IRepository<ProductionType> productionTypeRepository;
        private readonly INamedEntityRepository<Person> personRepository;
        private readonly IRepository<MediaType> mediaTypeRepository;

        public PublicationItemCsvImporter(IPublicationRepository publicationRepository,
            IRepository<ProductionType> productionTypeRepository,
            INamedEntityRepository<Person> personRepository,
            IRepository<MediaType> mediaTypeRepository) 
            : base(publicationRepository)
        {
            this.productionTypeRepository = productionTypeRepository;
            this.personRepository = personRepository;
            this.mediaTypeRepository = mediaTypeRepository;
        }
        
        public void Import(CsvRow csvRow)
        {
            var publicationItem = new PublicationItem
            {
                Publication = GetPublication(csvRow),
                Production = GetProduction(csvRow)
            };
            publicationItem.MediaItems.AddRange(GetMediaItems(csvRow));
        }

        private List<MediaItem> GetMediaItems(CsvRow csvRow)
        {
            var mediaItems = new List<MediaItem>();
            if (csvRow.MediaType.Length == csvRow.Discs)
            {
                // mediaItems = csvRow.MediaType.Select(mt => new MediaItem
                // {
                //     MediaType = 
                // }).ToList();
            }
            return mediaItems;
        }

        private Publication GetPublication(CsvRow csvRow)
        {
            Publication publication = null;
            var publicationId = csvRow.CollectionId;
            if (publicationId != null)
            {
                publication = publicationRepository.GetById((int)publicationId);
            }
            else
            {
                publication = CreatePublication(csvRow);
            }
            return publication;
        }

        private Production GetProduction(CsvRow csvRow)
        {
            var productionType = productionTypeRepository.GetById((int)csvRow.ProductionType); 

            Company studio = null;
            
            if (!string.IsNullOrEmpty(csvRow.Studio)) 
            {
                studio = publicationRepository.GetCompany(csvRow.Studio).FirstOrDefault();

                if (studio == null)
                {
                    studio = new Company { Name = csvRow.Studio };
                    publicationRepository.AddCompany(studio);
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