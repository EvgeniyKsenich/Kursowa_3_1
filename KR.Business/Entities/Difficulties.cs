using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KR.Business.Entities
{
    public class Difficulties
    {
        [Editable(false)]
        public int id { get; set; }

        [MaxLength(36)]
        [DisplayName("Subject")]
        public string subj { get; set; }

        
        public int price { get; set; }
    }
}