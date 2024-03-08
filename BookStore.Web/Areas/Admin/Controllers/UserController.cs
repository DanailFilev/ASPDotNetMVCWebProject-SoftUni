namespace BookStore.Web.Areas.Admin.Controllers
{
    using BookStore.Services.Data.Interfaces;
    using BookStore.Web.ViewModels.User;
    using Microsoft.AspNetCore.Mvc;

    public class UserController : BaseAdminController
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
                this.userService = userService;
        }
        public async Task<IActionResult> All()
        {
            IEnumerable<UserViewModel> model = await this.userService.AllAsync();

            return View(model);
        }
    }
}
