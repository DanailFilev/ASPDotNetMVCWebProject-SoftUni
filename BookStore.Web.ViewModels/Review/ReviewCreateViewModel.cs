namespace BookStore.Web.ViewModels.Review
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class ReviewCreateViewModel
    {
        [Required]
        public string Comment { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Please select a Book")]
        public int BookId { get; set; }

        // Property to hold the dropdown list
        public List<SelectListItem> Books { get; set; }
    }
}
