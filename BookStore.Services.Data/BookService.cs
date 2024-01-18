namespace BookStore.Services.Data
{
    using BookStore.Data;
    using BookStore.Services.Data.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using BookStore.Web.ViewModels.Book;
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
    }
}
