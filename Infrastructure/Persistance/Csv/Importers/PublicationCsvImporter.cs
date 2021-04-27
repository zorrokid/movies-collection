using System;
using System.Linq;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistance.Csv.Exceptions;
using Infrastructure.Persistance.Csv.Models;

namespace Infrastructure.Persistance.Csv.Importers
{
    public class PublicationCsvImporter : AbstractCsvImporter, ICsvImporter
    {
        public PublicationCsvImporter(IRepository<Publication> publicationRepository, 
            IRepository<CaseType> caseTypeRepository,
            IRepository<Company> companyRepository,
            IRepository<CompanyRole> companyRoleRepository) 
            : base(companyRepository, companyRoleRepository, caseTypeRepository, publicationRepository)
        {
        }

        public void Import(CsvRow csvRow)
        {
            if (csvRow.Id == null) throw new DbImportException("Imported publications must always have an ID");
            if (publicationRepository.GetAll().Where(p => p.ImportOriginId == csvRow.Id).Any())
            {
                Console.WriteLine($"Publication with id {csvRow.Id} already imported - skipping.");
                return;
            }
            var publication = CreatePublication(csvRow);
            publicationRepository.Add(publication);           
        }
    }
}