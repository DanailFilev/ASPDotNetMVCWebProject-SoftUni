namespace BookStore.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
    using static BookStore.Common.EntityValidationConstants.User;
    /// <summary>
    /// Represents registered users of the application.
    /// </summary>
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.Orders = new HashSet<Order>(); 
            this.Reviews = new HashSet<Review>();
            this.Carts = new HashSet<Cart>();
        }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
    }
}
