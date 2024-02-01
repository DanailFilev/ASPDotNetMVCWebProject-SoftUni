namespace BookStore.Web.ViewModels.User
{
	using System.ComponentModel.DataAnnotations;
	using static BookStore.Common.EntityValidationConstants.User;
	public class RegisterFormModel
	{
		[Required]
		[EmailAddress]
		[Display(Name = "Email")]
		public string Email { get; set; }

		[Required]
		[StringLength(PasswordMaxLength, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = PasswordMinLength)]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }

		[Required]
		[StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        public string FirstName { get; set; }

		[Required]
		[StringLength(LastNameMaxLength, MinimumLength = LastNameMaxLength)]
        public string LastName { get; set; }
    }
}
