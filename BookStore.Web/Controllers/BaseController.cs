namespace BookStore.Web.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using System.Security.Claims;

	public class BaseController : Controller
    {
        protected string GetUserId()
        {
            string userId = string.Empty;

            if (User != null)
            {
                userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            return userId;
        }

        protected Guid GetCurrentUserId()
        {
            // Access the ClaimsPrincipal from the HttpContext
            ClaimsPrincipal user = HttpContext.User;

            // Find the claim containing the user ID
            Claim userIdClaim = user?.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim != null && Guid.TryParse(userIdClaim.Value, out Guid userId))
            {
                // Successfully parsed the user ID from the claim
                return userId;
            }

            // Default value or error handling
            return Guid.Empty;
        }
    }
}
