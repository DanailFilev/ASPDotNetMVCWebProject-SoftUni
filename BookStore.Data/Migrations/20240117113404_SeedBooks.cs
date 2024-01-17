using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Data.Migrations
{
    public partial class SeedBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "Description", "GenreId", "ImageUrl", "Price", "StockQuantity", "Title" },
                values: new object[,]
                {
                    { 1, 1, "It is a 1986 horror novel by American author Stephen King. It was his 22nd book and the 17th novel written under his own name. The story follows the experiences of seven children as they are terrorized by an evil entity that exploits the fears of its victims to disguise itself while hunting its prey.", 7, "https://d28hgpri8am2if.cloudfront.net/book_images/onix/cvr9781982127794/it-9781982127794_xlg.jpg", 29.99m, 20, "It" },
                    { 2, 2, "Angels & Demons is a 2000 bestselling mystery-thriller novel written by American author Dan Brown and published by Pocket Books and then by Corgi Books. The novel introduces the character Robert Langdon, who recurs as the protagonist of Brown's subsequent novels.", 5, "https://bookvilleworld.com/wp-content/uploads/2020/03/Dan-Brown-Angels-and-Demons-1.jpeg", 19.99m, 20, "Angels & Demons" },
                    { 3, 3, "Harry Potter has never even heard of Hogwarts when the letters start dropping on the doormat at number four, Privet Drive. Addressed in green ink on yellowish parchment with a purple seal, they are swiftly confiscated by his grisly aunt and uncle. Then, on Harry's eleventh birthday, a great beetle-eyed giant of a man called Rubeus Hagrid bursts in with some astonishing news: Harry Potter is a wizard, and he has a place at Hogwarts School of Witchcraft and Wizardry. An incredible adventure is about to begin!", 4, "https://www.dymocks.com.au/Pages/ImageHandler.ashx?q=9781408855652&w=&h=570", 16.99m, 20, "Harry Potter" },
                    { 4, 4, "Every so often a love story so captures our hearts that it becomes more than a story-it becomes an experience to remember forever. The Notebook is such a book. It is a celebration of how passion can be ageless and timeless, a tale that moves us to laughter and tears and makes us believe in true love all over again...", 3, "https://m.media-amazon.com/images/I/71rzGw1-HAL._SL1294_.jpg", 22.99m, 20, "The Notebook" },
                    { 5, 5, "On a warm summer morning in North Carthage, Missouri, it is Nick and Amy Dunne’s fifth wedding anniversary. Presents are being wrapped and reservations are being made when Nick’s clever and beautiful wife disappears. Husband-of-the-Year Nick isn’t doing himself any favors with cringe-worthy daydreams about the slope and shape of his wife’s head, but passages from Amy's diary reveal the alpha-girl perfectionist could have put anyone dangerously on edge. Under mounting pressure from the police and the media—as well as Amy’s fiercely doting parents—the town golden boy parades an endless series of lies, deceits, and inappropriate behavior. Nick is oddly evasive, and he’s definitely bitter—but is he really a killer?", 2, "https://m.media-amazon.com/images/I/71FZo7-3BnL._SL1500_.jpg", 31.99m, 20, "Gone Girl" },
                    { 6, 6, "A young prince meets with his father's ghost, who alleges that his own brother, now married to his widow, murdered him. The prince devises a scheme to test the truth of the ghost's accusation, feigning wild madness while plotting a brutal revenge until his apparent insanity begins to wreak havoc on innocent and guilty alike.", 6, "https://m.media-amazon.com/images/I/91KG9kdRyXL._SL1500_.jpg", 49.99m, 20, "Hamlet" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 6);
        }
    }
}
