namespace BookStore.Web.Infrastructure.Extensions
{
	using System.Security.Claims;
	using static BookStore.Common.GeneralApplicationConstants;
	public static class ClaimsPrincipalExtension
	{
		public static string? GetId(this ClaimsPrincipal user) 
		{
			return user.FindFirstValue(ClaimTypes.NameIdentifier);
		} 

		public static bool IsAdmin(this ClaimsPrincipal user)
		{
			return user.IsInRole(AdminRoleName);
		}
	}
}
