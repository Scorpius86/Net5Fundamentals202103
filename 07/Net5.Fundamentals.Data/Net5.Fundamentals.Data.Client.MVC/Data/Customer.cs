using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.Fundamentals.Data.Client.MVC.Data
{
    public class Customer
    {
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string District { get; set; }
        public DateTime Birthday { get; set; }
        public string Sex { get; set; }
        public string Dni { get; set; }
        public string Ruc { get; set; }
        public int Telephone { get; set; }
        public int Mobile { get; set; }

    }
}
