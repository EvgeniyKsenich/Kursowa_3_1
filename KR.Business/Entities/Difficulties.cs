using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KR.Business.Entities
{
    public class Difficulties
    {

        //public Difficulties()
        //{
        //    this.zakaz = new HashSet<Zakaz>();
        //}

        public int id { get; set; }
        public string subj { get; set; }
        public int price { get; set; }

        //public virtual ICollection<Zakaz> zakaz { get; set; }

    }
}