namespace BookStore.Services.Data
{
    using BookStore.Data;
    using BookStore.Services.Data.Interfaces;
    using BookStore.Web.ViewModels.Genre;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class GenreService : IGenreService
    {
        private readonly BookStoreDbContext dbContext;

        public GenreService(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<GenreViewModel>> GetGenresAsync()
        {
            return await dbContext.Genres
                .Select(g => new GenreViewModel
                {
                    Id = g.GenreId,
                    Name = g.Name,
                    // Add other properties as needed
                })
                .ToListAsync();
        }

        public async Task<GenreViewModel?> GetGenreByIdAsync(int genreId)
        {
            return await dbContext.Genres
                .Where(g => g.GenreId == genreId)
                .Select(g => new GenreViewModel
                {
                    Id = g.GenreId,
                    Name = g.Name,
                    // Add other properties as needed
                })
                .FirstOrDefaultAsync();
        }

    }
}
