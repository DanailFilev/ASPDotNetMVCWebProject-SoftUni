namespace BookStore.Services.Data.Interfaces
{
    using BookStore.Web.ViewModels.Book;

    public interface IBookService
    {
        Task<IEnumerable<AllBookViewModel>> GetAllAsync();
    }
}
