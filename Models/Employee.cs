using System;
using System.Collections.Generic;

#nullable disable

namespace LMS.Models
{
    public partial class Employee
    {
        public Employee()
        {
            InverseManager = new HashSet<Employee>();
            Leaves = new HashSet<Leave>();
        }

        public int Empid { get; set; }
        public string Empname { get; set; }
        public string Empemail { get; set; }
        public string Department { get; set; }
        public string Empaddress { get; set; }
        public string Phnumber { get; set; }
        public string Empusername { get; set; }
        public string Emppassword { get; set; }
        public int? Leaveinhand { get; set; }
        public int? Managerid { get; set; }

        public virtual Employee Manager { get; set; }
        public virtual ICollection<Employee> InverseManager { get; set; }
        public virtual ICollection<Leave> Leaves { get; set; }
    }
}
