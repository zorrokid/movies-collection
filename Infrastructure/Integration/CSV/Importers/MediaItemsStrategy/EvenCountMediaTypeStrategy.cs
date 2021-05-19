using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Infrastructure.Integration.CSV.Models;

namespace Infrastructure.Integration.CSV.Importers.MediaItemsStrategy
{
    public class EvenCountMediaTypeStrategy : IMediaItemsStrategy
    {
        public List<MediaItem> Create(CsvRow csvRow)
        {
            var countForEactType = csvRow.Discs / csvRow.MediaType.Length;

            List<MediaItem> mediaItems = new();

            foreach(var mediaType in csvRow.MediaType)
            {
                for(int i = 0; i < countForEactType; i++)
                {
                    mediaItems.Add(new MediaItem
                    {
                        MediaTypeId = (int) mediaType,
                        ConditionClassId = (int) csvRow.Condition
                    });
                }
            }

            return mediaItems;
        }
    }
}