using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Software_Requirement_System.Models
{
    public class Software_Project
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Software_Task_OrderID { get; set; }

        public Software_Task_Order Software_Task_Order { get; set; }
        public List<Software_Project_Task> Software_Project_Tasks { get; set; }
    }
}