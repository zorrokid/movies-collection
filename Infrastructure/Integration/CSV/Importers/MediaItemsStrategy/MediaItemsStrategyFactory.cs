using Infrastructure.Integration.CSV.Models;

namespace Infrastructure.Integration.CSV.Importers.MediaItemsStrategy
{
    public static class MediaItemsStrategyFactory
    {
        public static IMediaItemsStrategy GetStrategy(CsvRow csvRow)
        {
            if (csvRow.MediaType.Length == 1)
            {
                return new SingleMediaTypeStrategy();
            }
            if (csvRow.MediaType.Length == csvRow.Discs)
            {
                return new MultipleMatchingCountMediaTypeStrategy();
            }
            if (csvRow.Discs % csvRow.MediaType.Length == 0)
            {
                return new EvenCountMediaTypeStrategy();
            }
            if (csvRow.MediaType.Length > csvRow.Discs)
            {
                // discs are not set, use:
                return new MultipleMatchingCountMediaTypeStrategy();
            }
            return new BestGuessMediaTypeStrategy();
        }
    }
}