namespace BookStore.Web.Controllers
{
    using BookStore.Data.Models;
    using BookStore.Services.Data.Interfaces;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ReviewController : BaseController
    {
        private readonly IReviewService reviewService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReviewController(IReviewService reviewService, UserManager<ApplicationUser> userManager)
        {
            this.reviewService = reviewService;
            _userManager = userManager;
        }

        // GET: Reviews
        public IActionResult Index(int bookId)
        {
            var reviews = this.reviewService.GetReviewsByBook(bookId);
            return View(reviews);
        }

        // GET: Reviews/Create
        public IActionResult Create()
        {
            var model = new ReviewCreateViewModel
            {
                // Populate dropdown or provide necessary data for creating a new review
                // For example, you might need a list of books to associate with the review
            };

            return View(model);
        }

        // POST: Reviews/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReviewCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Get the currently logged-in user
                var user = await _userManager.GetUserAsync(User);

                // Map ViewModel to Review entity and save to database
                var review = new Review
                {
                    BookId = model.BookId,
                    UserId = user?.Id,
                    Comment = model.Comment,
                    Rating = model.Rating
                };

                this.reviewService.AddReview(review);

                return RedirectToAction("Index", new { bookId = model.BookId });
            }

            // If ModelState is not valid, return to the create view with the model
            return View(model);
        }
    }
}
