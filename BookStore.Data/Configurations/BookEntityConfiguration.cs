namespace BookStore.Data.Configurations
{
    using BookStore.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BookEntityConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.BookId);

            // Configure Book-OrderItem relationship with Restrict delete behavior
            builder.HasMany(b => b.OrderItems)
                .WithOne(oi => oi.Book)
                .HasForeignKey(oi => oi.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Review-Book relationship with Restrict delete behavior
            builder.HasMany(b => b.Reviews)
                .WithOne(r => r.Book)
                .HasForeignKey(r => r.BookId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
