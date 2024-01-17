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

            builder.HasData(this.GenerateAuthors());
        }

        private Author[] GenerateAuthors()
        {
            ICollection<Author> authors = new HashSet<Author>();

            Author author;

            author = new Author()
            {
                AuthorId = 1,
                FirstName = "Stephen",
                LastName = "King",
                Biography = "Stephen Edwin King is an American author of horror, supernatural fiction, suspense, crime, science-fiction, and fantasy novels. Called the \"King of Horror\", his books have sold more than 350 million copies as of 2006, and many have been adapted into films, television series, miniseries, and comic books.",
            };
            authors.Add(author);

            author = new Author()
            {
                AuthorId = 2,
                FirstName = "Dan",
                LastName = "Brown",
                Biography = "Daniel Gerhard Brown is an American author best known for his thriller novels, including the Robert Langdon novels Angels & Demons, The Da Vinci Code, The Lost Symbol, Inferno, and Origin. His novels are treasure hunts that usually take place over a period of 24 hours.",
            };
            authors.Add(author);

            author = new Author()
            {
                AuthorId = 3,
                FirstName = "Joanne",
                LastName = "Rowling",
                Biography = "Joanne Rowling CH OBE FRSL, better known by her pen name J. K. Rowling, is a British author and philanthropist. She wrote Harry Potter, a seven-volume fantasy series published from 1997 to 2007.",
            };
            authors.Add(author);

            author = new Author()
            {
                AuthorId = 4,
                FirstName = "Nicholas",
                LastName = "Sparks",
                Biography = "Nicholas Charles Sparks is an American romance novelist, screenwriter, and film producer. He has published twenty-three novels, all New York Times bestsellers, and two works of non-fiction, with over 115 million copies sold worldwide in more than 50 languages.",
            };
            authors.Add(author);

            author = new Author()
            {
                AuthorId = 5,
                FirstName = "Gillian",
                LastName = "Flynn",
                Biography = "Gillian Schieber Flynn is an American author, screenwriter, and producer. She is known for writing the thriller and mystery novels Sharp Objects, Dark Places, and Gone Girl, which are all critically acclaimed",
            };
            authors.Add(author);

            author = new Author()
            {
                AuthorId = 6,
                FirstName = "William",
                LastName = "Shakespeare",
                Biography = "William Shakespeare was an English playwright, poet and actor. He is widely regarded as the greatest writer in the English language and the world's pre-eminent dramatist. He is often called England's national poet and the \"Bard of Avon\".",
            };
            authors.Add(author);


            return authors.ToArray();
        }
    }
}
