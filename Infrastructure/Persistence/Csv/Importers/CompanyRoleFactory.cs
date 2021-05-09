using System.Linq;
using Application.Interfaces;
using Domain.Entities;
using Domain.Enumerations;

namespace Infrastructure.Persistence.Csv.Importers
{
    public class CompanyRoleFactory<T> where T : BaseEntity, new()
    {
        private readonly INamedEntityRepository<Company> companyRepository;
        private readonly INamedEntityRepository<CompanyRoleType> companyRoleRepository;

        public CompanyRoleFactory(INamedEntityRepository<Company> companyRepository,
            INamedEntityRepository<CompanyRoleType> companyRoleRepository)
        {
            this.companyRepository = companyRepository;
            this.companyRoleRepository = companyRoleRepository;
        }

        // public T CreateCompanyRole(CompanyRoleEnum role, string name)
        // {
        //     Company company = companyRepository.GetByName(name).FirstOrDefault();
        //     if (company == null)
        //     {
        //         company = new Company
        //         {
        //             Name = name
        //         };
        //         companyRepository.Add(company);
        //     }
        //     var publisherRole = companyRoleRepository.GetById((int) role);
        //     var companyRole = new T
        //     {
        //         Company = company,
        //         Role = publisherRole
        //     };
        //     return ...

        // }
        
    }
}