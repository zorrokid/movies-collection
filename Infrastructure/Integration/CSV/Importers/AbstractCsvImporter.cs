using System.Linq;
using Application.Interfaces;
using Domain.Entities;
using Domain.Enumerations;
using Infrastructure.Integration.CSV.Models;

namespace Infrastructure.Integration.CSV.Importers
{
    public class AbstractCsvImporter
    {
        protected readonly IPublicationRepository publicationRepository;
        public AbstractCsvImporter(IPublicationRepository publicationRepository)
        {
            this.publicationRepository = publicationRepository;
        }

        protected Publication CreatePublication(CsvRow csvRow)
        {
            var caseType = publicationRepository.GetCaseType(csvRow.CaseType);

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
            Company publisher = publicationRepository.GetCompany(csvRow.Publisher).FirstOrDefault();
            if (publisher == null)
            {
                publisher = new Company
                {
                    Name = publisherName
                };
                // publicationRepository.AddCompany(publisher);
            }
            var publisherRole = publicationRepository.GetCompanyRoleType(CompanyRoleEnum.Publisher);
            var publicationCompanyRole = new PublicationCompanyRole
            {
                Company = publisher,
                Role = publisherRole
            };
            return publicationCompanyRole;
        }
    }
}