namespace BookStore.Services.Data
{
    using BookStore.Data;
    using BookStore.Services.Data.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using BookStore.Web.ViewModels.Book;
    using BookStore.Web.ViewModels.Genre;
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
                               BookId = x.BookId,
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

        public async Task<BookViewModel?> GetBookByIdAsync(int bookId)
        {
            // Retrieve the book from the database by its ID
            var book = await dbContext.Books
                .Where(b => b.BookId == bookId)
                .FirstOrDefaultAsync();

            // If the book is not found, you can handle it accordingly
            if (book == null)
            {
                return null;
            }

            // Map the Book entity to a BookViewModel (adjust this based on your ViewModel structure)
            var bookViewModel = new BookViewModel
            {
                Id = book.BookId,
                Title = book.Title,
                Author = book.Author != null ? $"{book.Author.FirstName} {book.Author.LastName}" : "Unknown Author",
                Description = book.Description,
                ImageUrl = book.ImageUrl,
                GenreId = book.GenreId, 
                // Add other properties as needed
            };

            return bookViewModel;
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
            Author? author = await this.dbContext.Authors
                            .FirstOrDefaultAsync(a =>
                              a.FirstName == model.AuthorFirstName &&
                              a.LastName == model.AuthorLastName);

            if (author == null)
            {
                // If the author doesn't exist, create a new author record
                author = new Author
                {
                    FirstName = model.AuthorFirstName,
                    LastName = model.AuthorLastName,
                    Biography = model.AuthorBiography,
                };

                // Add the new author to the context
                await this.dbContext.Authors.AddAsync(author);
            }

            // Create the book and associate it with the author
            Book book = new Book()
            {
                Title = model.Title,
                Author = author, // Associate the book with the author
                Description = model.Description ?? string.Empty,
                ImageUrl = model.Url,
                GenreId = model.GenreId,
                Price = model.Price,
                StockQuantity = model.StockQuantity,
            };

            // Add the new book to the context
            await this.dbContext.Books.AddAsync(book);

            // Save changes to the database
            await this.dbContext.SaveChangesAsync();
        }
        public async Task<DetailsViewModel> GetBookDetailsAsync(int bookId)
        {
            var book = await this.dbContext.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(b => b.BookId == bookId);

            if (book == null)
            {
                // Handle the case where the book is not found
                return null;
            }

            var detailsViewModel = new DetailsViewModel
            {
                BookId = book.BookId,
                Title = book.Title,
                AuthorFullName = $"{book.Author.FirstName} {book.Author.LastName}",
                GenreName = book.Genre.Name,
                Price = book.Price,
                Description = book.Description,
                ImageUrl = book.ImageUrl
            };

            return detailsViewModel;
        }

        public void DeleteBook(int bookId)
        {
            var bookToDelete = this.dbContext.Books.Find(bookId);

            if (bookToDelete != null)
            {
                this.dbContext.Books.Remove(bookToDelete);
                this.dbContext.SaveChanges();
            }
            else
            {
                // Handle the case where the book with the specified ID was not found
               
            }
        }

        public async Task<EditBookViewModel?> GetBookByIdForEditAsync(int id)
        {
            var genres = await this.dbContext.Genres
                .Select(g => new GenreViewModel()
                {
                    Id = g.GenreId,
                    Name = g.Name,
                })
                .ToListAsync();

            var model = await this.dbContext.Books
                .Where(b => b.BookId == id)
                .Include(b => b.Author) 
                .Select(b => new EditBookViewModel()
                {
                    BookId = b.BookId,
                    Title = b.Title,
                    AuthorFirstName = b.Author.FirstName,
                    AuthorLastName = b.Author.LastName,
                    AuthorId = b.AuthorId,
                    Description = b.Description,
                    AuthorBiography = b.Author.Biography ?? string.Empty,
                    Price = b.Price,
                    Url = b.ImageUrl,
                    GenreId = b.GenreId,
                    StockQuantity = b.StockQuantity,
                    Genres = genres
                })
                .FirstOrDefaultAsync();

            return model;
        }

        public async Task EditBookAsync(EditBookViewModel model, int id)
        {
            var book = await this.dbContext.Books.FindAsync(id);

            if (book != null)
            {
                book.Title = model.Title;
                book.Author.FirstName = model.AuthorFirstName;
                book.Author.LastName = model.AuthorLastName;
                book.Author.Biography = model.AuthorBiography;
                book.Description = model.Description;
                book.ImageUrl = model.Url;
                book.GenreId = model.GenreId;
                book.Price = model.Price;
                book.StockQuantity = model.StockQuantity;

                await this.dbContext.SaveChangesAsync();
            }
        }
    }
}
