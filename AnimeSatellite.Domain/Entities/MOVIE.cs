using System;

namespace AnimeSatellite.Domain.Entities
{
    public partial class MOVIE
    {
        public int MOVIEID { get; set; }
        public string TITLE { get; set; }
        public string SYNOPSIS { get; set; }
        public string LENGTH { get; set; }
        public DateTime RELEASEDATE { get; set; }
        public string PRODUCER { get; set; }
        public string IMAGEFILENAME { get; set; }
    }
}
