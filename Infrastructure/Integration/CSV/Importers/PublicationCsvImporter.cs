using System;
using Application.Interfaces;
using Domain.Enumerations;
using Infrastructure.Integration.CSV.Models;

namespace Infrastructure.Integration.CSV.Importers
{
    public class PublicationCsvImporter : AbstractCsvImporter, ICsvImporter
    {
        public PublicationCsvImporter(IPublicationRepository publicationRepository) 
            : base(publicationRepository)
        {
        }

        public void Import(CsvRow csvRow)
        {
            if (publicationRepository.GetPublicationByImportOriginId((int)ImportOriginEnum.CustomCsv, csvRow.Id) != null)
            {
                Console.WriteLine($"Publication with id {csvRow.Id} already imported - skipping.");
                return;
            }
            var publication = CreatePublication(csvRow);
            publicationRepository.Add(publication);           
        }
    }
}