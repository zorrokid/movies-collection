using System.Collections.Generic;

namespace Domain.Entities
{
    /// <summary>
    /// Publication item represents a production in publication. Production can be spread over multiple media items of different type.
    /// e.g. movie can have two DVD's or one DVD and one Blu-ray disc. PublicationItem is always part of Publication.
    /// </summary>
    public class PublicationItem : BaseEntity
    {
        public int PublicationId { get; set; }
        public Publication Publication { get; set; }

        public int ProductionId { get; set; }
        public Production Production { get; set; }
        public string Title { get; set; }
        public List<MediaItem> MediaItems { get; } = new List<MediaItem>();
        public List<SubtitleLanguage> SubtitleLanguages { get; } = new List<SubtitleLanguage>();

    }
}