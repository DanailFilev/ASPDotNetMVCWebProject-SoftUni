namespace BookStore.Web.Areas.Admin.Controllers
{
    using BookStore.Data.Models;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseAdminController
    {
        public IActionResult Index()
        {
            ViewBag.TotalUsers = GetTotalUsers(); // Replace with your logic to get total users
            ViewBag.TotalOrders = GetTotalOrders(); // Replace with your logic to get total orders
            ViewBag.RecentOrders = GetRecentOrders(); // Replace with your logic to get recent orders
            return View();
        }

        // Example methods to retrieve data
        private int GetTotalUsers()
        {
            // Implement your logic to get total users from the database
            return 100; // For example
        }

        private int GetTotalOrders()
        {
            // Implement your logic to get total orders from the database
            return 500; // For example
        }

        private List<Order> GetRecentOrders()
        {
            // Implement your logic to get recent orders from the database
            // Return a list of Order objects or whatever your model is
            return new List<Order>();
            //  db.Orders.OrderByDescending(o => o.OrderDate).Take(10).ToList(); // For example
        }

    }
}
