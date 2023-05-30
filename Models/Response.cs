using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCRUD.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMassage { get; set; }

        public Employee Employee { get; set; }
        public List<Employee> ListEmployee { get; set; }


    }
}
