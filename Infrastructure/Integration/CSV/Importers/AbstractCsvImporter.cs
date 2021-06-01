using System.Linq;
using Domain.Entities;
using Domain.Enumerations;
using Infrastructure.Integration.CSV.Models;
using Infrastructure.Persistence.Database;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Integration.CSV.Importers
{
    public class AbstractCsvImporter
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly ILogger<AbstractCsvImporter> logger;

        public AbstractCsvImporter(IUnitOfWork unitOfWork, ILogger<AbstractCsvImporter> logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

        protected Publication CreatePublication(CsvRow csvRow)
        {
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
                CaseTypeId = (int) csvRow.CaseType,
                CountryCode = csvRow.Country,
                ConditionClassId = (int) csvRow.Condition
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
            }
            var publisherRole = unitOfWork.CompanyRoleTypes.GetById((int)CompanyRoleEnum.Publisher);
            var publicationCompanyRole = new PublicationCompanyRole
            {
                Company = publisher,
                Role = publisherRole
            };
            return publicationCompanyRole;
        }

        public void Complete()
        {
            unitOfWork.SaveChanges();
        }
    }
}