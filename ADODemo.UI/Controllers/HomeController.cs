using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADODemo.Data.Models;
using ADODemo.Data.Repositories;

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
            List<int> orderIDs = new List<int>();

            var repo = new NorthwindsRepo();

            orderIDs = repo.GetOrderList();
            return View(orderIDs);
        }
    }
}