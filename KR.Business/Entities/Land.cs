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

        [MaxLength(36)]
        [DisplayName("Name")]
        public string name { get; set; }

        [Editable(false)]
        public int customer_id { get; set; }

        [Range(0,100000)]
        [DisplayName("Size")]
        public int size { get; set; }

        [MaxLength(70)]
        [DisplayName("Address")]
        public string addres { get; set; }
    }
}