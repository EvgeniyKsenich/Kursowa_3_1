using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KR.Business.Reports
{
    public class OrderCommonDate
    {
        public string Period { get; set; }

        public int AvgLandSize { get; set; }

        public int MaxLandSize { get; set; }

        public int MinLandSize { get; set; }

        public int AvgWorkCount { get; set; }

        public int MaxWorkCount { get; set; }

        public int MinWorkCount { get; set; }
    }
}