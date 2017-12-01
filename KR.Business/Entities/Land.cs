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
        //public Land()
        //{
        //    this.zakaz = new HashSet<Zakaz>();
        //}

        [Editable(false)]
        public int id { get; set; }

        [MaxLength(36)]
        public string name { get; set; }

        [Editable(false)]
        public int customer_id { get; set; }

        public int size { get; set; }

        [MaxLength(70)]
        public string addres { get; set; }

        //public virtual Customer customer { get; set; }
        //public virtual ICollection<Zakaz> zakaz { get; set; }
    }
}