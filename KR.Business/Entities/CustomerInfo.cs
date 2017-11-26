using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KR.Business.Entities
{
    public class CustomerInfo
    {
        public Customer Customer { get; set; }

        public IEnumerable<Land> Lands { get; set; }
    }
}