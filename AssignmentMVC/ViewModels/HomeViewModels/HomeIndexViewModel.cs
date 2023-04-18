using AssignmentMVC.ViewModels.GridViewModels;

namespace AssignmentMVC.ViewModels.HomeViewModels
{
    public class HomeIndexViewModel
    {
        public string ViewTitle { get; set; } = "Home";
        public GridCollectionViewModel BestCollection { get; set; } = null!;
        public GridCollectionViewModel UpToSale { get; set; } = null!;

        public GridCollectionViewModel TopSelling { get; set; } = null!;

        //public MediumGridCollectionViewModel TopSellingButtom { get; set; } = null!;
    }
}
