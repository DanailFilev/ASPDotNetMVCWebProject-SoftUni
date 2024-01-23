namespace BookStore.Web.Controllers
{
    using BookStore.Services.Data.Interfaces;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

    public class GenreController : BaseController
    {
        private readonly IGenreService genreService;

        public GenreController(IGenreService genreService)
        {
            this.genreService = genreService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var genres = await genreService.GetGenresAsync();
            return View(genres);
        }

		[AllowAnonymous]
		public async Task<IActionResult> Details(int id)
        {
            var genre = await genreService.GetGenreByIdAsync(id);

            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }
    }
}
