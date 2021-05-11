using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Infrastructure.Integration.CSV.Models;

namespace Infrastructure.Integration.CSV.Importers.MediaItemsStrategy
{
    public class SingleMediaTypeStrategy : IMediaItemsStrategy
    {
        public List<MediaItem> Create(CsvRow csvRow)
        {
            List<MediaItem> mediaItems = new();
            for(int i = 0; i < csvRow.Discs; i++)
            {
                mediaItems.Add(new MediaItem
                {
                    MediaTypeId = (int) csvRow.MediaType.First(),
                    ConditionClassId = (int) csvRow.Condition
                });
            }
            return mediaItems;
        }
    }
}