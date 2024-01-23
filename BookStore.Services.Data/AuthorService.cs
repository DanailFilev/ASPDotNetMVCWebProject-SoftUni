namespace BookStore.Services.Data
{
	using BookStore.Data;
	using BookStore.Data.Models;
	using BookStore.Services.Data.Interfaces;
	using Microsoft.EntityFrameworkCore;

	public class AuthorService : IAuthorService
	{
		private readonly BookStoreDbContext dbContext;

        public AuthorService(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

		public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
		{
			return await this.dbContext.Authors.ToListAsync();
		}

		public async Task<Author> GetAuthorByIdAsync(int id)
		{
			return await this.dbContext.Authors.FindAsync(id);
		}

		public async Task CreateAuthorAsync(Author author)
		{
			this.dbContext.Authors.Add(author);
			await this.dbContext.SaveChangesAsync();
		}

		public async Task UpdateAuthorAsync(Author author)
		{
			this.dbContext.Entry(author).State = EntityState.Modified;
			await this.dbContext.SaveChangesAsync();
		}

		public async Task DeleteAuthorAsync(int id)
		{
			var author = await this.dbContext.Authors.FindAsync(id);
			if (author != null)
			{
				this.dbContext.Authors.Remove(author);
				await this.dbContext.SaveChangesAsync();
			}
		}

	}
}
