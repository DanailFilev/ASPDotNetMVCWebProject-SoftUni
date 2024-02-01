namespace BookStore.Web.Controllers
{
	using BookStore.Data.Models;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;

	public class UserController : BaseController
	{
		private readonly SignInManager<ApplicationUser> signInManager;
		private readonly UserManager<ApplicationUser> userManager;
		private readonly IUserStore<ApplicationUser> userStore;

        public UserController(SignInManager<ApplicationUser> signInManager,
			UserManager<ApplicationUser> userManager,
			IUserStore<ApplicationUser> userStore)
        {
            this.signInManager = signInManager;
			this.userManager = userManager;
			this.userStore = userStore;
        }

		[HttpGet]
        public IActionResult Register()
		{
			return View();
		}
	}
}
