namespace BookStore.Data.Configurations
{
    using BookStore.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AuthorEntityConfiguration : IEntityTypeConfiguration<Author> 
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.AuthorId);

            // Configure Author-Book relationship with Restrict delete behavior
            builder.HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

        }
    }
}
