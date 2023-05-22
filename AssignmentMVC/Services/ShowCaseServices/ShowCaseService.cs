using AssignmentMVC.Models.Models;

namespace AssignmentMVC.Services.ShowCaseServices
{
    public class ShowCaseService
    {
        public class ShowCaseServices
        {
            private readonly List<ShowCaseModel> _showCases = new List<ShowCaseModel>()
        {
            new ShowCaseModel()
            {
                Ingress = "Welcome to bmarketo SHOP",
                Title = "Exclusise chair gold Collection",
                ImageUrl = "images/placeholders/625x647.jpg",
                Button = new LinkButtonModel() {Content = "Shop now", Url = "/products"}

            }


        };

            public ShowCaseModel GetLatest()
            {
                return _showCases.LastOrDefault()!;
            }
        }
    }
}