using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADODemo.Data.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }

        public int? QuantityOrdered { get; set; }
        public decimal Discount { get; set; }

        [DataType(DataType.Currency)]
        public decimal ProdTotalCost { get; set; }

    }
}
