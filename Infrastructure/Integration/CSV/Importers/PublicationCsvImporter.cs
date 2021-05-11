using System;
using Application.Interfaces;
using Domain.Enumerations;
using Infrastructure.Integration.CSV.Models;

namespace Infrastructure.Integration.CSV.Importers
{
    public class PublicationCsvImporter : AbstractCsvImporter, ICsvImporter
    {
        public PublicationCsvImporter(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {
        }

        public void Import(CsvRow csvRow)
        {
            if (unitOfWork.Publications.GetPublicationByImportOriginId((int)ImportOriginEnum.CustomCsv, csvRow.Id) != null)
            {
                Console.WriteLine($"Publication with id {csvRow.Id} already imported - skipping.");
                return;
            }
            var publication = CreatePublication(csvRow);
            unitOfWork.Publications.Add(publication);           
        }
    }
}