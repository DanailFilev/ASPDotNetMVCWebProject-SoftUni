namespace BookStore.Web.ViewModels.Book
{
    public class DetailsViewModel
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public string AuthorFullName { get; set; }

        public string GenreName { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int StockQuantity { get; set; }
    }
}
