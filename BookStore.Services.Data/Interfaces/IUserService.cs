﻿namespace BookStore.Services.Data.Interfaces
{
    using BookStore.Web.ViewModels.User;

    public interface IUserService
	{
		Task<string> GetFullNameByEmailAsync(string email);

		Task<string> GetFullNameByIdAsync(string userId);

		Task<IEnumerable<UserViewModel>> AllAsync();
	}
}
