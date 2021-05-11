using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Infrastructure.Integration.CSV.Models;

namespace Infrastructure.Integration.CSV.Importers.MediaItemsStrategy
{
    public class MultipleMatchingCountMediaTypeStrategy : IMediaItemsStrategy
    {
        public List<MediaItem> Create(CsvRow csvRow)
        {   
            List<MediaItem> mediaItems = csvRow.MediaType.Select(mt => new MediaItem
            {
                MediaTypeId = (int) mt,
                ConditionClassId = (int) csvRow.Condition
            }).ToList();
            
            return mediaItems;
        }
    }
}