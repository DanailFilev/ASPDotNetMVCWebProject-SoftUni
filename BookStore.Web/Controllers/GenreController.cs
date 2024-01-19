namespace BookStore.Web.Controllers
{
    using BookStore.Services.Data.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    public class GenreController : Controller
    {
        private readonly IGenreService genreService;

        public GenreController(IGenreService genreService)
        {
            this.genreService = genreService;
        }


        public async Task<IActionResult> All()
        {
            var genres = await genreService.GetGenresAsync();
            return View(genres);
        }

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
