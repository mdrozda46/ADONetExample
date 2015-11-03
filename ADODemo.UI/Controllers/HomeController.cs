using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADODemo.Data.Models;
using ADODemo.Data.Repositories;
using ADODemo.UI.Models;

namespace ADODemo.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult GetOrder()
        {
            int orderID = int.Parse(Request.Form["orderID"]);

            var repo = new NorthwindsRepo();
            Order order = new Order();
            order = repo.GetByIdStoredProcedure(orderID);
            return View(order);

        }

        public ActionResult GetOrder(int orderID)
        {
            var repo = new NorthwindsRepo();
            Order order = new Order();
            order = repo.GetByIdStoredProcedure(orderID);
            return View(order);

        }

        public ActionResult DisplayOrderList()
        {
            var ordersVM = new AllOrdersVM();
            int numberOfOrders = 0; 

            var repo = new NorthwindsRepo();

            ordersVM.OrderList = repo.GetOrderList();
            ordersVM.OrderCount = repo.GetTotalOrderCount();
            
            return View(ordersVM);
        }
    }
}