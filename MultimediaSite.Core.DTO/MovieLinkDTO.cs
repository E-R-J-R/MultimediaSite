using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultimediaSite.Core.DTO
{
    public class MovieLinkDTO
    {
        public int MovieLinkId { get; set; }
        public int MovieId { get; set; }
        public string LinkUrl { get; set; }
        public string LinkType { get; set; }
        public Boolean AutoPlay { get; set; }
        public Boolean FullScreen { get; set; }
        public string EmbedCode { get; set; }
    }
}
