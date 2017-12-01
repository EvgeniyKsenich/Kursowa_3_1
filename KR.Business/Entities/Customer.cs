using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KR.Business.Entities
{
    public class Customer
    {
        //public Customer()
        //{
        //    this.land = new HashSet<Land>();
        //}


        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }

        //public virtual ICollection<Land> land { get; set; }
    }
}