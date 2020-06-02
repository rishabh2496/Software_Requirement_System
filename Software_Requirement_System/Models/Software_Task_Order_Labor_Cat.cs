using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Software_Requirement_System.Models
{
    public class Software_Task_Order_Labor_Cat
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Software_Task_OrderID { get; set; }
        public string LaborCategory { get; set; }

        public Software_Task_Order Software_Task_Order { get; set; }
    }
}