using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Data.Migrations
{
    public partial class SeedAuthors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "Biography", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Stephen Edwin King is an American author of horror, supernatural fiction, suspense, crime, science-fiction, and fantasy novels. Called the \"King of Horror\", his books have sold more than 350 million copies as of 2006, and many have been adapted into films, television series, miniseries, and comic books.", "Stephen", "King" },
                    { 2, "Daniel Gerhard Brown is an American author best known for his thriller novels, including the Robert Langdon novels Angels & Demons, The Da Vinci Code, The Lost Symbol, Inferno, and Origin. His novels are treasure hunts that usually take place over a period of 24 hours.", "Dan", "Brown" },
                    { 3, "Joanne Rowling CH OBE FRSL, better known by her pen name J. K. Rowling, is a British author and philanthropist. She wrote Harry Potter, a seven-volume fantasy series published from 1997 to 2007.", "Joanne", "Rowling" },
                    { 4, "Nicholas Charles Sparks is an American romance novelist, screenwriter, and film producer. He has published twenty-three novels, all New York Times bestsellers, and two works of non-fiction, with over 115 million copies sold worldwide in more than 50 languages.", "Nicholas", "Sparks" },
                    { 5, "Gillian Schieber Flynn is an American author, screenwriter, and producer. She is known for writing the thriller and mystery novels Sharp Objects, Dark Places, and Gone Girl, which are all critically acclaimed", "Gillian", "Flynn" },
                    { 6, "William Shakespeare was an English playwright, poet and actor. He is widely regarded as the greatest writer in the English language and the world's pre-eminent dramatist. He is often called England's national poet and the \"Bard of Avon\".", "William", "Shakespeare" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Name" },
                values: new object[] { 7, "Horror" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 7);
        }
    }
}
