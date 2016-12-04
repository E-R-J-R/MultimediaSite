using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeSatellite.Core.DTO
{
    public class NewsDTO
    {
        public int NewsId { get; set; }
        public string Headline { get; set; }
        public string Content { get; set; }
        public string ContentType { get; set; }
        public string EmbedCode { get; set; }
        public DateTime NewsDate { get; set; }
        public DateTime PublishedDate { get; set; }
        public string SourceName { get; set; }
        public string SourceUrl { get; set; }
        public string ImageFileName { get; set; }
    }
}
