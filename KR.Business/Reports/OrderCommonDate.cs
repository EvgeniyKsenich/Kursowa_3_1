using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KR.Business.Reports
{
    public class OrderCommonDate
    {
        public string Period { get; set; }

        public int AvgPrice { get; set; }

        public int AvgLandSize { get; set; }

        public int MaxPrice { get; set; }

        public int MaxLandSize { get; set; }

        public int MinPrice { get; set; }

        public int MinLandSize { get; set; }
    }
}