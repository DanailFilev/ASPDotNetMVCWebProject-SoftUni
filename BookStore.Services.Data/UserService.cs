namespace BookStore.Services.Data
{
	using BookStore.Data;
	using BookStore.Data.Models;
	using BookStore.Services.Data.Interfaces;
	using Microsoft.EntityFrameworkCore;
	using System.Threading.Tasks;

	public class UserService : IUserService
	{
		private readonly BookStoreDbContext dbContext;

        public UserService(BookStoreDbContext dbContext)
        {
			this.dbContext = dbContext;	
        }

        public async Task<string> GetFullNameByEmailAsync(string email)
		{
			ApplicationUser? user = await this.dbContext
				.Users
				.FirstOrDefaultAsync(u => u.Email == email);

			if (user == null)
			{
				return string.Empty;
			}

			return $"{user.FirstName} {user.LastName}";
		}
	}
}
