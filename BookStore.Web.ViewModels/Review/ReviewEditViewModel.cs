namespace BookStore.Web.ViewModels.Review
{
    using System.ComponentModel.DataAnnotations;

    public class ReviewEditViewModel
    {
        public int ReviewId { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        public int Rating { get; set; }
    }
}
