using System.Collections.Generic;
using Domain.Entities;
using Domain.Enumerations;

namespace Application.Interfaces
{
    public interface IPublicationRepository
    {
        Publication Add(Publication publication);
        Publication GetById(int id);
        CaseType GetCaseType(CaseTypeEnum caseType);
        CompanyRoleType GetCompanyRoleType(CompanyRoleEnum companyRole);
        List<Company> GetCompany(string name);
        Company AddCompany(Company company);
        PublicationCompanyRole AddPublicationCompanyRole(PublicationCompanyRole publicationCompanyRole);
        Publication GetPublicationByImportOriginId(int importOriginId, string id);
    }
}