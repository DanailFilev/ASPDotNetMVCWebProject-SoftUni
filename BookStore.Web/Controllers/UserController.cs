namespace BookStore.Web.Controllers
{
	using BookStore.Data.Models;
	using BookStore.Web.ViewModels.User;
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

		[HttpPost]
		public async Task<IActionResult> Register(RegisterFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			ApplicationUser user = new ApplicationUser()
			{
				Email = model.Email,
				FirstName = model.FirstName,
				LastName = model.LastName,
			};

			await this.userManager.SetEmailAsync(user, model.Email);
			await this.userManager.SetUserNameAsync(user, model.Email);

			IdentityResult result =
			await this.userManager.CreateAsync(user, model.Password);

			if(!result.Succeeded)
			{
				foreach (IdentityError error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}

				return View(model);
			}

			await this.signInManager.SignInAsync(user, isPersistent: false);

			return RedirectToAction("Index", "Home");

		}
	}
}
