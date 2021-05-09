using System.Collections.Generic;
using System.Linq;
using Application.Interfaces;
using Domain.Entities;
using Domain.Enumerations;

namespace Infrastructure.Persistence.Database
{
    public class PublicationRepository : IPublicationRepository
    {
        private readonly INamedEntityRepository<Company> companyRepository;
        private readonly IRepository<CompanyRoleType> companyRoleTypeRepository;
        private readonly IRepository<PublicationCompanyRole> publicationCompanyRoleRepository;
        private readonly IRepository<CaseType> caseTypeRepository;
        private readonly IRepository<Publication> publicationRepository;

        public PublicationRepository(INamedEntityRepository<Company> companyRepository,
            IRepository<CompanyRoleType> companyRoleTypeRepository,
            IRepository<PublicationCompanyRole> publicationCompanyRoleRepository, 
            IRepository<CaseType> caseTypeRepository,
            IRepository<Publication> publicationRepository)
        {
            this.companyRepository = companyRepository;
            this.companyRoleTypeRepository = companyRoleTypeRepository;
            this.publicationCompanyRoleRepository = publicationCompanyRoleRepository;
            this.caseTypeRepository = caseTypeRepository;
            this.publicationRepository = publicationRepository;
        }

        public Publication Add(Publication publication)
        {
            return publicationRepository.Add(publication);
        }

        public Company AddCompany(Company company)
        {
            return companyRepository.Add(company);
        }

        public PublicationCompanyRole AddPublicationCompanyRole(PublicationCompanyRole publicationCompanyRole)
        {
            return publicationCompanyRoleRepository.Add(publicationCompanyRole);
        }

        public Publication GetById(int id)
        {
            return publicationRepository.GetById(id);
        }

        public CaseType GetCaseType(CaseTypeEnum caseType)
        {
            return caseTypeRepository.GetById((int)caseType);
        }

        public List<Company> GetCompany(string name)
        {
            return companyRepository.GetByName(name).ToList();
        }

        public CompanyRoleType GetCompanyRoleType(CompanyRoleEnum companyRole)
        {
            return companyRoleTypeRepository.GetById((int)companyRole);
        }

        public Publication GetPublicationByImportOriginId(int importOriginId, string idInImportOrigin)
        {
           return publicationRepository.GetAll()
            .Where(p => p.ImportOriginId == importOriginId && p.IdInImportOrigin == idInImportOrigin)
            .FirstOrDefault();
        }
    }
}