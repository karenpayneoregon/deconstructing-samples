﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Switches.Models
{
    public partial class StudentGrade
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public decimal? Grade { get; set; }

        public virtual Course Course { get; set; }
        public virtual Person Student { get; set; }
    }
}