using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Software_Requirement_System.Models
{
    public class Software_Task_Order
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Software_ContractID { get; set; }
        public string Code { get; set; }

        public Software_Contract Software_Contract { get; set; }
        public List<Software_Task_Order_Labor_Cat> Software_Task_Order_Labor_Cats { get; set; }
        public List<Software_Project> Software_Projects { get; set; }
    }
}