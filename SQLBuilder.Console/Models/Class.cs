﻿using SQLBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLBuilder
{
    [Table("Base_Class")]
    public class Class
    {
        [Column(Insert = false)]
        public int CityId { get; set; }
        [Column(Update = false)]
        public int UserId { get; set; }
        public string Name { get; set; }
    }
}
