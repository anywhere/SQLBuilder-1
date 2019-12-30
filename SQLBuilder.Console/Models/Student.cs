﻿using SQLBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLBuilder
{
    [Table("T_Student")]
    public class Student
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public DateTime? CreateTime { get; set; } = DateTime.Now;
        public bool? IsEffective { get; set; } = true;
        public bool IsOnLine { get; set; }
    }
}
