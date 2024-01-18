namespace BookStore.Services.Data.Interfaces
{

    public interface IBookService
    {
        IEnumerable<BookViewModel> GetAllBooks();
    }
}
