using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADODemo.Data.Models;

namespace ADODemo.UI.Models
{
    public class AllOrdersVM
    {
        public List<int> OrderList { get; set; }
        public int OrderCount { get; set;  }

        public AllOrdersVM()
        {
            OrderList = new List<int>();
        }
    }
}