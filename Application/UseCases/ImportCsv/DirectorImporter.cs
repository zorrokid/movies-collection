using System;
using System.Linq;
using Application.Extensions;
using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Enumerations;
using Application.UseCases.ReadCsv;

namespace Application.UseCases.ImportCsv
{
    public class DirectorImporter : IDBImporter
    {
        private readonly IRepository<Person> personRepository;
        private readonly IRepository<PersonRole> personRoleRepository;
        private readonly IRepository<PersonRoleType> roleRepository;

        public DirectorImporter(IRepository<Person> personRepository,
            IRepository<PersonRole> personRoleRepository,
            IRepository<PersonRoleType> roleRepository)
        {
            this.roleRepository = roleRepository;
            this.personRepository = personRepository;
            this.personRoleRepository = personRoleRepository;
        }

        public void Import(CsvRow row)
        {
            var personFullName = row.Director.Trim();
            var personGivenName = personFullName.GivenName();
            var personFamilyName = personFullName.FamilyName();

            // var persons = personRepository.GetAll();
            // var personRoles = personRoleRepository.GetAll();

            var person = (from p in personRepository.GetAll()
                          where p.FullName == personFullName
                          select p).FirstOrDefault();

            if (person == null)
            {
                person = personRepository.Add(new Person
                {
                    FullName = personFullName,
                    // Just guessing these, may need to be fixed later on:
                    GivenName = personFullName.GivenName(),
                    Surname = personFullName.FamilyName()
                });
            }
            else
            {

                var role = roleRepository.GetById((int)PersonRoleEnum.Director);

                if (role == null)
                {
                    throw new DbImportException("No role for PersonRoleEnum.Director in database");
                }

                var personHasRole = (from p in personRoleRepository.GetAll()
                                     where p.Person.Id == person.Id && p.Role.Id == role.Id
                                     select p).Any();


                if (!personHasRole)
                {
                    // personRoleRepository.Add(new PersonRole
                    // {
                    //     Person = person,
                    //     Role = role,
                    //     Movie = movie
                    // })
                }

        }



        var directors = from d in personRepository.GetAll()
                        join r in personRoleRepository.GetAll() on d.Id equals r.Person.Id
                        select d;

        Console.WriteLine(row.LocalTitle);
            // var importPerson = row.Director;
            // if (!persons.Any(x => x.FullName.ToLower() == importPerson.ToLower()))
            // {
            //     var person = new Person
            //     {
            //         FullName = importPerson
            //     };
            //     persons.Add(person);
            //     var id = personRepository.Add(person).Id;
            // }
        }
}
}