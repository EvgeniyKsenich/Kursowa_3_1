﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KR.Business.Entities
{
    public class Designer
    {
        //public Designer()
        //{
        //    this.zakaz = new HashSet<Zakaz>();
        //}

        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }

       // public virtual ICollection<Zakaz> zakaz { get; set; }
    }
}