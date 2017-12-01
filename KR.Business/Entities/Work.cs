using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KR.Business.Entities
{
    public class Work
    {
        [Editable(false)]
        public int id { get; set; }

        [MaxLength(36)]
        [DisplayName("Type")]
        public string typee { get; set; }

        [Range(0, 50)]
        [DisplayName("Count")]
        public int countt { get; set; }

        [Range(0, 100000)]
        [DisplayName("Price")]
        public int price { get; set; }
    }
}