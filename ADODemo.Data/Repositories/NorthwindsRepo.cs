using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ADODemo.Data.Config;
using ADODemo.Data.Models;

namespace ADODemo.Data.Repositories
{ 
    public class NorthwindsRepo
    {

        public Order GetByIdStoredProcedure(int orderId)
        {
            Order order = new Order();

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "OrderInfoByID";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@OrderID", orderId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        if (order.OrderID == null)
                        {
                            order.OrderID = (int)(dr["OrderID"]);
                            order.CustomerID = dr["CustomerID"].ToString();
                            order.CompanyName = dr["CompanyName"].ToString();
                            order.OrderDate = (DateTime)(dr["OrderDate"]);
                        }

                        order.Products.Add(PopulateProductsFromDataReader(dr));
                    }

                    order.Total = order.Products.Sum(p => p.ProdTotalCost);
                }
            }

            return order;
        }

        private Product PopulateProductsFromDataReader(SqlDataReader dr)
        {
            Product product = new Product();
            
            product.ProductID = int.Parse(dr["ProductID"].ToString());
            product.ProductName = dr["ProductName"].ToString();
            product.UnitPrice = decimal.Parse(dr["UnitPrice"].ToString());
            product.QuantityOrdered = int.Parse(dr["Quantity"].ToString());
            product.Discount = decimal.Parse(dr["Discount"].ToString());
            product.ProdTotalCost = decimal.Parse(dr["ProdTotalCost"].ToString());

            return product;
        }
    }
}

