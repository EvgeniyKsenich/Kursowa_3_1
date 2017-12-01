using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KR.Business.Entities
{
    public class Zakaz
    {
        [Editable(false)]
        public int id { get; set; }

        public int designer_id { get; set; }

        public int land_id { get; set; }

        [DisplayName("Price")]
        public int price { get; set; }

        [DisplayName("Start time")]
        public System.DateTime start_time { get; set; }

        [DisplayName("End time")]
        public System.DateTime end_time { get; set; }
    }
}