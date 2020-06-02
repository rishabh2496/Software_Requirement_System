using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Software_Requirement_System.Models
{
    public class Software_Project_Task
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Software_ProjectID { get; set; }

        public Software_Project Software_Project { get; set; }
    }
}