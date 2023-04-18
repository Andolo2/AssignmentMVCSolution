using AssignmentMVC.Models.Models;

namespace AssignmentMVC.Services.UpToSaleService
{
    public class UpToSaleService
    {
        private readonly List<UpToSaleModel> _upToSale = new List<UpToSaleModel>()
        {
            new UpToSaleModel()
            {
                RedTitle = "Up To Sale",

                Title = "50% OFF",

                Ingress = "Get the Best Price",

                Text = "Get the best daily offer et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren no sea taki",

                Link = "Discover More!!!"
            }
        };

        public UpToSaleModel GetLatest()
        {
            return _upToSale.LastOrDefault()!;
        }
    }
}
