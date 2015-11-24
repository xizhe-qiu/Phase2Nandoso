using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Phase2Nandoso.Models
{
    public class Feedback
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public string Comment { get; set; }

        public virtual ICollection<Reply> Replys { get; set; }
    }
}