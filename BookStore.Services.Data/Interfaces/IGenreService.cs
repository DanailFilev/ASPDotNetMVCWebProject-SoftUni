namespace BookStore.Services.Data.Interfaces
{
    using BookStore.Web.ViewModels.Genre;

    public interface IGenreService
    {
        Task<List<GenreViewModel>> GetGenresAsync();
        Task<GenreViewModel> GetGenreByIdAsync(int genreId);
    }
}
