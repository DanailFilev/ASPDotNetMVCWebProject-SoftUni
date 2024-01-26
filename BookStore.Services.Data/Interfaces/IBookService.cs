namespace BookStore.Services.Data.Interfaces
{
    using BookStore.Web.ViewModels.Book;

    public interface IBookService
    {
        Task<IEnumerable<AllBookViewModel>> GetAllAsync();

        Task<AddBookViewModel> GetNewAddBookModelAsync();

        Task AddBookAsync(AddBookViewModel model);

        Task<BookViewModel?> GetBookByIdAsync(int Id);

        void DeleteBook(int bookId);

        Task<DetailsViewModel> GetBookDetailsAsync(int bookId);

        Task<EditBookViewModel?> GetBookByIdForEditAsync(int id);

        Task EditBookAsync(EditBookViewModel model, int id);
    }
}
