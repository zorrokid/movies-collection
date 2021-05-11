using System.Collections.Generic;
using Domain.Entities;
using Infrastructure.Integration.CSV.Models;

namespace Infrastructure.Integration.CSV.Importers.MediaItemsStrategy
{
    public interface IMediaItemsStrategy
    {
         List<MediaItem> Create(CsvRow csvRow);
    }
}