namespace BookStore.Web.Controllers
{
    using BookStore.Data.Models;
    using BookStore.Services.Data;
    using BookStore.Services.Data.Interfaces;
    using BookStore.Web.ViewModels.Review;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class ReviewController : BaseController
    {
        private readonly IReviewService reviewService;

        public ReviewController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        // GET: Reviews
        public async Task<IActionResult> Index()
        {
            var reviews = await this.reviewService.GetAllReviewsAsync();
            return View(reviews);
        }

        // GET: Reviews/Create
        public IActionResult Create()
        {
            // Optional: If you need to load additional data for creating a review
            // For example, a list of books for a dropdown in the view
            // You can modify the Create view to use this data
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReviewViewModel reviewViewModel)
        {
            if (ModelState.IsValid)
            {
                await this.reviewService.CreateReviewAsync(reviewViewModel);
                return RedirectToAction(nameof(Index));
            }

            // Optional: If you need to load additional data for creating a review
            // For example, a list of books for a dropdown in the view
            // You can modify the Create view to use this data
            return View(reviewViewModel);
        }

    }
}
