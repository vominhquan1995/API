using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAPI.Models
{
    public class Products
    {
        public int id { set; get; }
        public string name { set; get; }
        public string description { set; get; }
        public decimal price { set; get; }
        public string unit { set; get; }
        public int catid { set; get; }
    }
}