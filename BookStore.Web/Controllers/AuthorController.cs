namespace BookStore.Web.Controllers
{
    using BookStore.Data.Models;
    using BookStore.Services.Data;
	using BookStore.Services.Data.Interfaces;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;

	public class AuthorController : BaseController
	{
		private readonly IAuthorService authorService;

        public AuthorController(IAuthorService authorService)
        {
            this.authorService = authorService;
		}

		public async Task<IActionResult> Index()
		{
			var authors = await this.authorService.GetAllAuthorsAsync();
			return View(authors);
		}

		public async Task<IActionResult> Details(int id)
		{
			var author = await this.authorService.GetAuthorByIdAsync(id);
			if (author == null)
			{
				return NotFound();
			}

			return View(author);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("FirstName,LastName,Biography")] Author author)
		{
			if (ModelState.IsValid)
			{
				await this.authorService.CreateAuthorAsync(author);
				return RedirectToAction(nameof(Index));
			}
			return View(author);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var author = await this.authorService.GetAuthorByIdAsync(id);
			if (author == null)
			{
				return NotFound();
			}

			return View(author);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("AuthorId,FirstName,LastName,Biography")] Author author)
		{
			if (id != author.AuthorId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					await this.authorService.UpdateAuthorAsync(author);
                    return RedirectToAction(nameof(Details), new { id = author.AuthorId });
                }
				catch (DbUpdateConcurrencyException)
				{
					if (!AuthorExists(author.AuthorId))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
			}
			return View(author);
		}

		public async Task<IActionResult> Delete(int id)
		{
			var author = await this.authorService.GetAuthorByIdAsync(id);
			if (author == null)
			{
				return NotFound();
			}

			return View(author);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await this.authorService.DeleteAuthorAsync(id);
			return RedirectToAction(nameof(Index));
		}

		private bool AuthorExists(int id)
		{
			// Check if an author with the given id exists
			return this.authorService.GetAuthorByIdAsync(id) != null;
		}
	}
}
