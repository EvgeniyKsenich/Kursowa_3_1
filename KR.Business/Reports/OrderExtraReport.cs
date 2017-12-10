using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KR.Business.Reports
{
    public class OrderExtraReport
    {
        public string Period { get; set; }

        public int LandVariable { get; set; }

        public int MaxLandSize { get; set; }

        public int MinLandSize { get; set; }

        public int AvgLandSize { get; set; }

        public DateTime MaxStartTime { get; set; }

        public DateTime MinStartTime { get; set; }

        public int ZakazCount { get; set; }
    }
}