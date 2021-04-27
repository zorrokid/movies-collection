using System.Linq;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistance.Csv.Models;

namespace Infrastructure.Persistance.Csv.Importers
{
    public class AbstractCsvImporter
    {
        protected readonly IRepository<Company> companyRepository;
        protected readonly IRepository<CompanyRole> companyRoleRepository;
        protected readonly IRepository<CaseType> caseTypeRepository;
        protected readonly IRepository<Publication> publicationRepository;

        public AbstractCsvImporter(IRepository<Company> companyRepository,
            IRepository<CompanyRole> companyRoleRepository, 
            IRepository<CaseType> caseTypeRepository,
            IRepository<Publication> publicationRepository)
        {
            this.companyRepository = companyRepository;
            this.companyRoleRepository = companyRoleRepository;
            this.caseTypeRepository = caseTypeRepository;
            this.publicationRepository = publicationRepository;
        }

        protected Publication CreatePublication(CsvRow csvRow)
        {
            var caseType = caseTypeRepository.GetById((int)csvRow.CaseType);
            Company publisher = null;
            if (csvRow.Publisher != null)
            {
                var publisherName = csvRow.Publisher.Trim();
                publisher = companyRepository.GetAll().Where(c => c.Name == publisherName).FirstOrDefault();
                if (publisher == null)
                {
                    publisher = new Company
                    {
                        Name = publisherName
                    };
                    companyRepository.Add(publisher);
                }
            }
            
            var publication = new Publication
            {
                ImportOriginId = csvRow.Id.Value,
                IsVerified = csvRow.IsChecked,
                Barcode = csvRow.Barcode,
                HasBooklet = csvRow.HasLeaflet,
                HasHologram = csvRow.HasHologram,
                HasSlipCover = csvRow.HasSlipCover,
                IsRental = csvRow.IsRental,
                HasTwoSidedCover = csvRow.HasTwoSidedCover,
                Notes = csvRow.Notes,
                OriginalTitle = csvRow.OriginalTitle,
                LocalTitle = csvRow.LocalTitle,
                CaseType = caseType,
                CountryCode = csvRow.Country,
                Publisher = publisher
            };
            return publication;
        }
    }
}