namespace BookStore.Services.Data.Interfaces
{
	using BookStore.Data.Models;

	public interface IAuthorService
	{
		Task<IEnumerable<Author>> GetAllAuthorsAsync();
		Task<Author> GetAuthorByIdAsync(int id);
		Task CreateAuthorAsync(Author author);
		Task UpdateAuthorAsync(Author author);
		Task DeleteAuthorAsync(int id);
	}
}
