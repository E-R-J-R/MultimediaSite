using System;

namespace AnimeSatellite.Domain.Entities
{
    public partial class NEWS
    {
        public int NEWSID { get; set; }
        public string HEADLINE { get; set; }
        public string CONTENT { get; set; }
        public string CONTENTTYPE { get; set; }
        public string EMBEDCODE { get; set; }
        public DateTime NEWSDATE { get; set; }
        public DateTime PUBLISHEDDATE { get; set; }
        public string SOURCENAME { get; set; }
        public string SOURCEURL { get; set; }
        public string IMAGEFILENAME { get; set; }
    }
}
