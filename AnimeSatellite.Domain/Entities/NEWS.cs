﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeSatellite.Domain.Entities
{
    public partial class NEWS
    {
        public int NEWSID { get; set; }
        public string HEADLINE { get; set; }
        public string CONTENT { get; set; }
        public DateTime NEWSDATE { get; set; }
        public DateTime PUBLISHEDDATE { get; set; }
        public string SOURCE { get; set; }
        public string IMAGEFILENAME { get; set; }
    }
}
