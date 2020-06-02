using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Software_Requirement_System.Models
{
    public class Software_Contract_Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Software_ContractID { get; set; }
        public Software_Contract Software_Contract { get; set; }
    }
}