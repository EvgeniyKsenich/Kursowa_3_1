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
    public class Land
    {
        [Editable(false)]
        public int id { get; set; }

        public string name { get; set; }

        [Editable(false)]
        public int customer_id { get; set; }

        public int size { get; set; }

        //public virtual customer customer { get; set; }
        //public virtual ICollection<zakaz> zakaz { get; set; }
        //public virtual ICollection<difficulties> difficulties { get; set; }
    }
}