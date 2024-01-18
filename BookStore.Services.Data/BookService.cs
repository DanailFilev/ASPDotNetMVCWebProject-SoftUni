namespace BookStore.Services.Data
{
    using BookStore.Data;
    using BookStore.Services.Data.Interfaces;

    public class BookService : IBookService
    {
        private readonly BookStoreDbContext dbContext;
        public BookService(BookStoreDbContext dbContext)
        {
                this.dbContext = dbContext;
        }
    }
}
