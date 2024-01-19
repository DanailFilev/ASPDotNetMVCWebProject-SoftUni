namespace BookStore.Web.Controllers
{
    using BookStore.Services.Data.Interfaces;
    using BookStore.Web.ViewModels.Book;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class BookController : BaseController
    {
        private readonly IBookService bookService;
        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var model = await bookService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddBookViewModel model = await this.bookService.GetNewAddBookModelAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel model)
        {
            //decimal rating;

            //if (!decimal.TryParse(model.Rating, out rating) || rating < 0 || rating > 10)
            //{
            //    ModelState.AddModelError(nameof(model.Rating), "Rating must be a number between 0.00 and 10.00.");

            //    return View(model);
            //}

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await bookService.AddBookAsync(model);

            return RedirectToAction(nameof(All));
        }
    }
}
