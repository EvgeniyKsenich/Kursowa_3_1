using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
namespace KR.Business.Entities
{
    public class ZakazInfo
    {
        [DisplayName("Order")]
        public Zakaz zakaz { get; set; }

        [DisplayName("Designer")]
        public Designer designer { get; set; }

        [DisplayName("Customer")]
        public Customer customer { get; set; }

        [DisplayName("Work")]
        public Work work { get; set; }

        [DisplayName("Difficults")]
        public Difficulties difficults { get; set; }

        [DisplayName("Land")]
        public Land land { get; set; }
    }
}