using System;
using System.Linq;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistance.Csv.Exceptions;
using Infrastructure.Persistance.Csv.Models;

namespace Infrastructure.Persistance.Csv.Importers
{
    public class PublicationCsvImporter : ICsvImporter
    {

        private readonly IRepository<Publication> publicationRepository;
        private readonly IRepository<CaseType> caseTypeRepository;
        private readonly IRepository<Company> companyRepository;
        private readonly IRepository<CompanyRole> companyRoleRepository;


        public PublicationCsvImporter(IRepository<Publication> publicationRepository, 
            IRepository<CaseType> caseTypeRepository,
            IRepository<Company> companyRepository,
            IRepository<CompanyRole> companyRoleRepository)
        {
            this.publicationRepository = publicationRepository;
            this.caseTypeRepository = caseTypeRepository;
            this.companyRepository = companyRepository;
            this.companyRoleRepository = companyRoleRepository;
        }

        public void Import(CsvRow csvRow)
        {
            if (csvRow.Id == null) throw new DbImportException("Imported publications must always have an ID");
            if (publicationRepository.GetAll().Where(p => p.ImportOriginId == csvRow.Id).Any())
            {
                Console.WriteLine($"Publication with id {csvRow.Id} already imported - skipping.");
                return;
            }
            var caseType = caseTypeRepository.GetById((int)csvRow.CaseType);
            var publisherName = csvRow.Publisher.Trim();
            Company publisher = companyRepository.GetAll().Where(c => c.Name == publisherName).FirstOrDefault();
            if (publisher == null)
            {
                publisher = new Company
                {
                    Name = publisherName
                };
                companyRepository.Add(publisher);
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
            publicationRepository.Add(publication);           
        }
    }
}