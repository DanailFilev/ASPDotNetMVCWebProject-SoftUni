namespace BookStore.Services.Data
{
    using BookStore.Data;
    using BookStore.Services.Data.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using BookStore.Web.ViewModels.Book;
    using BookStore.Data.Models;

    public class BookService : IBookService
    {
        private readonly BookStoreDbContext dbContext;
        public BookService(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllBookViewModel>> GetAllAsync()
        {
            return await dbContext
                       .Books
                       .Select(x => new AllBookViewModel()
                           {
                               Id = x.BookId,
                               Title = x.Title,
                               Author = $"{x.Author.FirstName} {x.Author.LastName}",
                               ImageUrl = x.ImageUrl,
                               ShortDescription = GetShortDescription(x.Description)
                       })
                           .ToListAsync();
        }

        private static string GetShortDescription(string fullDescription)
        {
            const int maxLength = 100; // You can adjust the character limit for short description
            return fullDescription?.Length > maxLength ? fullDescription.Substring(0, maxLength) + "..." : fullDescription ?? string.Empty;
        }

        public async Task<AddBookViewModel> GetNewAddBookModelAsync()
        {
            var genres = await this.dbContext
                .Genres
                .Select(g => new GenreViewModel()
                {
                    Id = g.GenreId,
                    Name = g.Name,
                })
                .ToListAsync();

            var model = new AddBookViewModel
            {
                Genres = genres
            };

            return model;
        }

        public async Task AddBookAsync(AddBookViewModel model)
        {
            // Check if the author exists based on the provided AuthorId
            Author author = await this.dbContext.Authors.FindAsync(model.AuthorId);

            if (author == null)
            {
                // If the author doesn't exist, create a new author record
                author = new Author
                {
                    // Assuming you have FirstName and LastName properties in your AddBookViewModel
                    FirstName = model.AuthorFirstName,
                    LastName = model.AuthorLastName,
                    // Other author properties as needed
                };

                // Add the new author to the context
                await this.dbContext.Authors.AddAsync(author);
            }

            // Create the book and associate it with the author
            Book book = new Book()
            {
                Title = model.Title,
                Author = author, // Associate the book with the author
                Description = model.Description,
                ImageUrl = model.Url,
                GenreId = model.GenreId
            };

            // Add the new book to the context
            await this.dbContext.Books.AddAsync(book);

            // Save changes to the database
            await this.dbContext.SaveChangesAsync();
        }
    }
}
