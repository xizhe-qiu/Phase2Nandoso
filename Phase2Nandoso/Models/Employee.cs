using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Phase2Nandoso.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string EmployeeName { get; set; }

        public virtual ICollection<Reply> Replys { get; set; }

    }
}