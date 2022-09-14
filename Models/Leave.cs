using System;
using System.Collections.Generic;

#nullable disable

namespace LMS.Models
{
    public partial class Leave
    {
        public int Leaveid { get; set; }
        public int? Empid { get; set; }
        public int? Manid { get; set; }
        public DateTime? Leavefrom { get; set; }
        public DateTime? Leaveto { get; set; }
        public int? Noofdays { get; set; }
        public string Leavestatus { get; set; }
        public string Leavetype { get; set; }

        public virtual Employee Emp { get; set; }
    }
}
