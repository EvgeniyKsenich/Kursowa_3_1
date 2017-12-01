using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KR.Business.Entities
{
    public class Work
    {
        //public Work()
        //{
        //    this.zakaz = new HashSet<Zakaz>();
        //}

        public int id { get; set; }
        public string typee { get; set; }
        public int countt { get; set; }
        public int price { get; set; }

        //public virtual ICollection<Zakaz> zakaz { get; set; }
    }
}