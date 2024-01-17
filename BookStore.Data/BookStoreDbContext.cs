namespace BookStore.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;

    using BookStore.Data.Models;
    using System.Reflection;

    public class BookStoreDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(BookStoreDbContext)) ??
                Assembly.GetExecutingAssembly();

            modelBuilder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}