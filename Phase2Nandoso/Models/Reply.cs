using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Phase2Nandoso.Models
{
    public class Reply
    {
        public int ID { get; set; }
        public int FeedbackID { get; set; }
        public int EmployeeID { get; set; }
        public string Content { get; set; }

        public virtual Feedback Feedback { get; set; }
        public virtual Employee Employee { get; set; }

    }
}