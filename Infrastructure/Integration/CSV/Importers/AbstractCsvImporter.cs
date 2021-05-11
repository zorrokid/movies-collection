using System.Linq;
using Domain.Entities;
using Domain.Enumerations;
using Infrastructure.Integration.CSV.Models;

namespace Infrastructure.Integration.CSV.Importers
{
    public class AbstractCsvImporter
    {
        protected readonly IUnitOfWork unitOfWork;

        public AbstractCsvImporter(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        protected Publication CreatePublication(CsvRow csvRow)
        {
            var caseType = unitOfWork.CaseTypes.GetById((int)csvRow.CaseType);

            var publication = new Publication
            {
                ImportOriginId = (int)ImportOriginEnum.CustomCsv,
                IdInImportOrigin = csvRow.Id,
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
                CountryCode = csvRow.Country
            };

            if (csvRow.Publisher != null)
            {
                publication.PublicationCompanyRoles.Add(CreatePublicationCompanyRole(csvRow));
            }
            return publication;
        }

        private PublicationCompanyRole CreatePublicationCompanyRole(CsvRow csvRow)
        {
            var publisherName = csvRow.Publisher;
            Company publisher = unitOfWork.Companies.GetByName(csvRow.Publisher).FirstOrDefault();
            if (publisher == null)
            {
                publisher = new Company
                {
                    Name = publisherName
                };
                // publicationRepository.AddCompany(publisher);
            }
            var publisherRole = unitOfWork.CompanyRoleTypes.GetById((int)CompanyRoleEnum.Publisher);
            var publicationCompanyRole = new PublicationCompanyRole
            {
                Company = publisher,
                Role = publisherRole
            };
            return publicationCompanyRole;
        }
    }
}