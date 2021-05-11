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
            return new BestGuessMediaTypeStrategy();
        }
    }
}