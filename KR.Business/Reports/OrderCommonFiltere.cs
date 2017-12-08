using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KR.Business.Reports
{
    public class OrderCommonFiltere
    {
        public string Period { get; set; }

        public int AvgPrice { get; set; }

        public int AvgWorkCount { get; set; }

        public int AvgDifficultsCount { get; set; }

        public string MaxDifficults { get; set; }
    }
}