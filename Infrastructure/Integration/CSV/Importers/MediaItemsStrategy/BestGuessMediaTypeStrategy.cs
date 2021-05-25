using System.Collections.Generic;
using Domain.Entities;
using Infrastructure.Integration.CSV.Models;

namespace Infrastructure.Integration.CSV.Importers.MediaItemsStrategy
{
    public class BestGuessMediaTypeStrategy : IMediaItemsStrategy
    {
        public List<MediaItem> Create(CsvRow csvRow)
        {
            // Let's not try to guess after all
            return new();
        }
    }
}