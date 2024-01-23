namespace BookStore.Web.Controllers
{
    using System.Diagnostics;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
    using ViewModels.Home;

    public class HomeController : BaseController
    {
        public HomeController()
        {
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = new IndexViewModel
            {
                FeaturedItems = new List<FeaturedItemViewModel>
            {
                new FeaturedItemViewModel
                {
                    Title = "Special Offer",
                    Description = "Get 20% off on selected books!",
                    ImageUrl = "/images/special_offer.jpg"
                },
                new FeaturedItemViewModel
                {
                    Title = "New Arrivals",
                    Description = "Explore our latest book arrivals.",
                    ImageUrl = "/images/new_arrivals.png"
                },
                // Add more featured items as needed
            }
                // Populate other properties as needed
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}