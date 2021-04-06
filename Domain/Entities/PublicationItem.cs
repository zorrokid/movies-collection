using System.Collections.Generic;

namespace Domain.Entities
{
    public class PublicationItem : BaseEntity
    {
        public Publication Publication { get; set; }
        public Production Production { get; set; }
        public string Title { get; set; }
        public List<MediaItem> MediaItems { get; } = new List<MediaItem>();
        public int ImportOriginId { get; set; }
        public List<SubtitleLanguage> SubtitleLanguages { get; } = new List<SubtitleLanguage>();

    }
}