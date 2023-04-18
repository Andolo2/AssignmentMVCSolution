namespace AssignmentMVC.ViewModels.GridViewModels
{
    public class GridCollectionItemViewModel
    {
        public string Id { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string Title { get; set; } = null!;

        public decimal Price
        {
            get; set;
        }
    }
}
