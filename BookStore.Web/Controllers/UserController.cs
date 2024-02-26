namespace BookStore.Web.Controllers
{
	using BookStore.Data.Models;
	using BookStore.Web.ViewModels.User;
	using Griesoft.AspNetCore.ReCaptcha;
	using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;


	public class UserController : BaseController
	{
		private readonly SignInManager<ApplicationUser> signInManager;
		private readonly UserManager<ApplicationUser> userManager;

        public UserController(SignInManager<ApplicationUser> signInManager,
			UserManager<ApplicationUser> userManager)
        {
            this.signInManager = signInManager;
			this.userManager = userManager;
        }

		[HttpGet]
        public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[ValidateRecaptcha(Action = nameof(Register),
			ValidationFailedAction = ValidationFailedAction.ContinueRequest)]
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

		[HttpGet]
		public async Task<IActionResult> Login(string? returnUrl = null)
		{
			await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

			LoginFormModel model = new LoginFormModel()
			{
				ReturnUrl = returnUrl,
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var result = await this.signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

			if(!result.Succeeded)
			{
				TempData["ErrorMessage"] = "There was an error while logging you in. Please try again later or contact administrator";

				return View(model);
			}

			return Redirect(model.ReturnUrl ?? "/Home/Index");

		}
	}
}
