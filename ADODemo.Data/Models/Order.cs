using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADODemo.Data.Models
{
    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }

        public List<Product> Products { get; set; }

        [DataType(DataType.Currency)]
        public decimal Total { get; set; }

        public Order()
        {
            Products = new List<Product>();
        }
    }
}
