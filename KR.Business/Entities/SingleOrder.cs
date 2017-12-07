using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KR.Business.Entities
{
    public class SingleOrder
    {
        public ZakazInfo ZakazInfo { get; set; }

        public List<Difficulties> AllPosibleDifficults { get; set; }
    }
}