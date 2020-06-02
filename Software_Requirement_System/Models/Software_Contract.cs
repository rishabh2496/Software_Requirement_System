using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Software_Requirement_System.Models
{
    public class Software_Contract
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int OptionYears { get; set; }

        public List<Software_Task_Order> Software_Task_Orders { get; set; }
        public List<Software_Contract_Category> Software_Contract_Categories { get; set; }
    }
}