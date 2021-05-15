using Domain.Enumerations;
using Infrastructure.Integration.CSV.Models;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Integration.CSV.Importers
{
    public class PublicationCsvImporter : AbstractCsvImporter, ICsvImporter<CsvRow>
    {
        public PublicationCsvImporter(IUnitOfWork unitOfWork, ILogger<PublicationCsvImporter> logger) 
            : base(unitOfWork, logger)
        {
        }

        public void Import(CsvRow csvRow)
        {
            if (unitOfWork.Publications.GetByImportOrigin((int)ImportOriginEnum.CustomCsv, csvRow.Id) != null)
            {
                logger.LogWarning($"Publication with id {csvRow.Id} already imported - skipping.");
                return;
            }
            var publication = CreatePublication(csvRow);
            unitOfWork.Publications.Add(publication);
        }
    }
}