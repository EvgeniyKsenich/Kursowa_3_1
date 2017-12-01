﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KR.Business.Entities
{
    public class Designer
    {
        [Editable(false)]
        public int id { get; set; }

        [MaxLength(36)]
        [DisplayName("Name")]
        public string name { get; set; }

        [MaxLength(36)]
        [DisplayName("Surname")]
        public string surname { get; set; }

        [Range(0, 170)]
        [DisplayName("Age")]
        public int age { get; set; }
    }
}