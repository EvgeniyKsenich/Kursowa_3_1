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
    public class OrderReport
    {
        public int price { get; set; }

        public System.DateTime start_time { get; set; }

        public System.DateTime end_time { get; set; }

        public string LandName { get; set; }

        public string LandAddress { get; set; }

        public string LandSize { get; set; }

        public string CustomerName { get; set; }

        public string CustomerSurname { get; set; }

        public string DesignerName { get; set; }

        public string DesignerSurname { get; set; }

    }
}