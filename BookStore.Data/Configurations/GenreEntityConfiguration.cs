namespace BookStore.Data.Configurations
{
    using BookStore.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class GenreEntityConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(g => g.GenreId);

            // Configure Genre-Book relationship with Restrict delete behavior
            builder.HasMany(g => g.Books)
                .WithOne(b => b.Genre)
                .HasForeignKey(b => b.GenreId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            // Add other configurations as needed...
        }
    }
}
