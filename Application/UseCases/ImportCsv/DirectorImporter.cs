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
            var persons = personRepository.GetAll();
            var personRoles = personRoleRepository.GetAll();

            foreach(var row in csvRows) 
            {
                var importPerson = row.Director;
                if (!persons.Any(x => $"{x.GivenName} {x.Surname}".ToLower() == importPerson.ToLower()))
                {
                    var nameParts = importPerson.Split(' ');
                    // var person = new Person
                    // {
                    //     GivenName = nameParts.Last();

                    //};
                    // personRepository.Add(new Person
                    // {

                    // });
                }
            }
            // check each entry if exists in db-collection
            // if not write to db and proceed
            throw new System.NotImplementedException();
        }
    }
}