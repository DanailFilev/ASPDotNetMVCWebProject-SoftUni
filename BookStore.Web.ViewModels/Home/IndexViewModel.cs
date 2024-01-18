namespace BookStore.Web.ViewModels.Home
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            this.FeaturedItems = new List<FeaturedItemViewModel>();
        }
        public List<FeaturedItemViewModel> FeaturedItems { get; set; }
    }
}
