using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Music_History_TAEN.Models
{
    public class Track
    {
        [Key]
        public int TrackId { get; set; }
        public string TrackTitle { get; set; }
        public string AlbumTitle { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
    }
}
