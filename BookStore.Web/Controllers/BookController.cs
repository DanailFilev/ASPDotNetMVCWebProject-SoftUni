namespace BookStore.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class BookController : Controller
    {
        [AllowAnonymous] 
        public async Task<IActionResult> All()
        {
            return View();
        }
    }
}
