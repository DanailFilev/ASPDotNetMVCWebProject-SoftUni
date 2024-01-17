namespace BookStore.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Represents registered users of the application.
    /// </summary>
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Orders = new HashSet<Order>(); 
            this.Reviews = new HashSet<Review>();
            this.Carts = new HashSet<Cart>();
        }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
    }
}
