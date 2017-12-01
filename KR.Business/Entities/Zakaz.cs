using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KR.Business.Entities
{
    public class Zakaz
    {

        public Zakaz()
        {
            //this.difficulties = new HashSet<Difficulties>();
            //this.work = new HashSet<Work>();
        }

        public int id { get; set; }
        public int designer_id { get; set; }
        public int land_id { get; set; }
        public int price { get; set; }
        public System.DateTime start_time { get; set; }
        public System.DateTime end_time { get; set; }

        //public virtual Designer designer { get; set; }
        //public virtual Land land { get; set; }
        //public virtual ICollection<Difficulties> difficulties { get; set; }
        //public virtual ICollection<Work> work { get; set; }

    }
}