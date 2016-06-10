using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_History_TAEN.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }

        public ICollection<Album> AlbumList { get; set; }
    }
}
