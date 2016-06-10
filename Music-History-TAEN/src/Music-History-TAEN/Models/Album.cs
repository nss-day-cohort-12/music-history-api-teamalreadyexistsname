using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_History_TAEN.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string AlbumTitle { get; set; }
        public string Artist { get; set; }
        public int YearReleased { get; set; }

        public ICollection<Track> TrackList { get; set; }
    }
}
