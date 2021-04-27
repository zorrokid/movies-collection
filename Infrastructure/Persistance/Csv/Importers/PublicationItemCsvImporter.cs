using System.Collections.Generic;
using System.Linq;
using Application.Extensions;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistance.Csv.Models;

namespace Infrastructure.Persistance.Csv.Importers
{
    public class PublicationItemCsvImporter : AbstractCsvImporter, ICsvImporter
    {
        private readonly IRepository<ProductionType> productionTypeRepository;
        private readonly INamedEntityRepository<Person> personRepository;

        public PublicationItemCsvImporter(IRepository<Publication> publicationRepository, 
            IRepository<CaseType> caseTypeRepository,
            IRepository<Company> companyRepository,
            IRepository<CompanyRole> companyRoleRepository,
            IRepository<ProductionType> productionTypeRepository,
            INamedEntityRepository<Person> personRepository) 
            : base(companyRepository, companyRoleRepository, caseTypeRepository, publicationRepository)
        {
            this.productionTypeRepository = productionTypeRepository;
            this.personRepository = personRepository;
        }
        
        public void Import(CsvRow csvRow)
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
            var productionType = productionTypeRepository.GetById((int)csvRow.ProductionType);  
            var directorNames = csvRow.Directors;
            
            var directors = new List<Person>();
            foreach(var directorName in directorNames)
            {
                var person = personRepository.GetByName(directorName).FirstOrDefault();
                if(person != null)
                {
                    directors.Add(person);
                }
                else 
                {
                    var newPerson = new Person
                    {
                        Name = directorName,
                        GivenName = directorName.GivenName(),
                        Surname = directorName.FamilyName()
                    };
                    personRepository.Add(newPerson);
                    directors.Add(newPerson);
                }
            }


            var production = new Production
            {
                ProductionType = productionType,
                OriginalTitle = csvRow.OriginalTitle,

            };

            var publicationItem = new PublicationItem
            {
                Publication = publication,
                Production = production,

            };
        }
    }
}