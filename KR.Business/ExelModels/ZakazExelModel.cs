using KR.Business.Entities;
using KR.Business.ExelHelpers;
using System.Collections.Generic;

namespace KR.Business.ExelModels
{
    public class ZakazExelModel
    {
        public IEnumerable<Zakaz> Orders { get; set; }

        public IEnumerable<Designer> Designers { get; set; }

        public IEnumerable<Work> Works { get; set; }

        public IEnumerable<Land> Lands { get; set; }

        public IEnumerable<Customer> Customers { get; set; }

        public IEnumerable<Difficulties> Difficults { get; set; }

        public IEnumerable<OrderInfo> OrdersInfo { get; set; }
    }
}