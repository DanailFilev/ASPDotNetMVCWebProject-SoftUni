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

            builder.HasData(this.GenerateGenres());
        }

        private Genre[] GenerateGenres()
        {
            ICollection<Genre> genres = new HashSet<Genre>();

            Genre genre;

            genre = new Genre()
            {
               GenreId = 1,
               Name = "Science Fiction"
            };
            genres.Add(genre);

            genre = new Genre()
            {
                GenreId = 2,
                Name = "Mystery",
            };
            genres.Add(genre);

            genre = new Genre()
            {
                GenreId = 3,
                Name = "Romance",
            };
            genres.Add(genre);

            genre = new Genre()
            {
                GenreId = 4,
                Name = "Fantasy",
            };
            genres.Add(genre);

            genre = new Genre()
            {
                GenreId = 5,
                Name = "Thriller",
            };
            genres.Add(genre);

            genre = new Genre()
            {
                GenreId = 6,
                Name = "Drama",
            };
            genres.Add(genre);


            return genres.ToArray();
        }
    }
}
