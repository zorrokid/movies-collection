using System.Collections.Generic;
using System.Linq;
using Application.Interfaces;
using Application.Models;
using Domain.Entities;

namespace Application.UseCases.ImportCsv
{
    public class DirectorImporter : IDBImporter
    {
        private readonly IRepository<Person> personRepository;
        private readonly IRepository<PersonRole> personRoleRepository;

        public DirectorImporter(IRepository<Person> personRepository, IRepository<PersonRole> personRoleRepository)
        {
            this.personRepository = personRepository;
            this.personRoleRepository = personRoleRepository;
        }

        public void Import(IEnumerable<CsvRow> csvRows)
        {
            var persons = personRepository.GetAll().ToList();
            var personRoles = personRoleRepository.GetAll().ToList();

            foreach(var row in csvRows) 
            {
                var importPerson = row.Director;
                if (!persons.Any(x => x.FullName.ToLower() == importPerson.ToLower()))
                {
                    var person = new Person
                    {
                        FullName = importPerson
                    };
                    persons.Add(person);
                    var id = personRepository.Add(person).Id;
                }
            }
        }
    }
}