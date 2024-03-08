namespace BookStore.Services.Data
{
	using BookStore.Data;
	using BookStore.Data.Models;
	using BookStore.Services.Data.Interfaces;
    using BookStore.Web.ViewModels.User;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UserService : IUserService
	{
		private readonly BookStoreDbContext dbContext;

        public UserService(BookStoreDbContext dbContext)
        {
			this.dbContext = dbContext;	
        }

        public async Task<IEnumerable<UserViewModel>> AllAsync()
        {
            var users = await this.dbContext.Users
          .Select(u => new UserViewModel
          {
              // Map user properties to UserViewModel properties
              Id = u.Id.ToString(),
              Email = u.Email,
              FullName = $"{u.FirstName} {u.LastName}",
              // Map other properties as needed
          })
          .ToListAsync();

            return users;
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

        public async Task<string> GetFullNameByIdAsync(string userId)
        {
            ApplicationUser? user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            if (user == null)
            {
                return string.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
        }
    }
}
