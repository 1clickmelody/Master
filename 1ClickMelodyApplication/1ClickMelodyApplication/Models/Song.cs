using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1ClickMelodyApplication.Models
{
    public class Song
    {
        public int trackId { get; set; }

        public string trackName { get; set; }

        public int trackRating { get; set; }

        public int trackLength { get; set; }

        public int lyricsId { get; set; }

        public int albumId { get;set; }

        public string albumName { get; set; }
    }
}
