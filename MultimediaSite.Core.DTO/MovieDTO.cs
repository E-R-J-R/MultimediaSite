using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultimediaSite.Core.DTO
{
    public class MovieDTO
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Synopsis{ get; set; }
        public string Length { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Producer { get; set; }
        public string ImageFileName { get; set; }
        public List<MovieLinkDTO> Links { get; set; }
    }
}
