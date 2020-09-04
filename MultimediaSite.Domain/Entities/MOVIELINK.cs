using System;

namespace MultimediaSite.Domain.Entities
{
    public partial class MOVIELINK
    {
        public int MOVIELINKID { get; set; }
        public int MOVIEID { get; set; }
        public string LINKURL { get; set; }
        public string LINKTYPE { get; set; }
        public Boolean AUTOPLAY { get; set; }
        public Boolean FULLSCREEN { get; set; }
        public string EMBEDCODE { get; set; }
    }
}
