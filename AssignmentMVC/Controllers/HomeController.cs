using AssignmentMVC.ViewModels.GridViewModels;
using AssignmentMVC.ViewModels.HomeViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult HomeIndex()
        {


            var viewModel = new HomeIndexViewModel
            {
                BestCollection = new GridCollectionViewModel
                {
                    Title = "Best Collection",
                    Categories = new List<string> { "All", "Bags", "Dress", "Decoration", "Essentials", "Interior", "Laptop", "Mobile", "Beuty" },
                    GridItems = new List<GridCollectionItemViewModel>
                    {
                        new GridCollectionItemViewModel { Id = "1", Title = "A generic lamp..", Price = 40, ImageUrl = "images/placeholders/270/lamp.jpg" },
                        new GridCollectionItemViewModel { Id = "2", Title = "A generic lamp..", Price = 40, ImageUrl = "images/placeholders/270/lamp.jpg" },
                        new GridCollectionItemViewModel { Id = "3", Title = "A generic lamp..", Price = 40, ImageUrl = "images/placeholders/270/lamp.jpg" },
                        new GridCollectionItemViewModel { Id = "4", Title = "A generic lamp..", Price = 40, ImageUrl = "images/placeholders/270/lamp.jpg" },
                        new GridCollectionItemViewModel { Id = "5", Title = "A generic lamp..", Price = 40, ImageUrl = "images/placeholders/270/lamp.jpg" },
                        new GridCollectionItemViewModel { Id = "6", Title = "A generic lamp..", Price = 40, ImageUrl = "images/placeholders/270/lamp.jpg" },
                        new GridCollectionItemViewModel { Id = "7", Title = "A generic lamp..", Price = 40, ImageUrl = "images/placeholders/270/lamp.jpg" },
                        new GridCollectionItemViewModel { Id = "8", Title = "A generic lamp..", Price = 40, ImageUrl = "images/placeholders/270/lamp.jpg" }

                    }
                },

                UpToSale = new GridCollectionViewModel
                {
                    Title = "Up to Sale",

                    GridItems = new List<GridCollectionItemViewModel>
                    {
                        new GridCollectionItemViewModel { Id = "1", Title = "", Price = 10, ImageUrl = "images/placeholders/369x310.svg" },


                    }
                },

                TopSelling = new GridCollectionViewModel
                {
                    Title = "Top Selling Products this week",

                    GridItems = new List<GridCollectionItemViewModel>
                    {
                        new GridCollectionItemViewModel  { Id = "1", Title = "", Price = 30, ImageUrl = "images/placeholders/270/lamp.jpg" },
                        new GridCollectionItemViewModel  { Id = "2", Title = "", Price = 30, ImageUrl = "images/placeholders/270/lamp.jpg" },
                        new GridCollectionItemViewModel  { Id = "3", Title = "", Price = 30, ImageUrl = "images/placeholders/270/lamp.jpg" },
                        new GridCollectionItemViewModel  { Id = "4", Title = "", Price = 30, ImageUrl = "images/placeholders/270/lamp.jpg" },
                        new GridCollectionItemViewModel  { Id = "5", Title = "", Price = 30, ImageUrl = "images/placeholders/270/lamp.jpg" },
                        new GridCollectionItemViewModel  { Id = "6", Title = "", Price = 30, ImageUrl = "images/placeholders/270/lamp.jpg" },
                }


                },

                //TopSellingButtom = new MediumGridCollectionViewModel
                //{
                //    Title = "",
                //    GridItems = new List<MediumGridCollectionItemViewModel>
                //     {
                //         new MediumGridCollectionItemViewModel  { Id = "1", Title = "", Text = "Best dress for everyone ed totam velit risus viverranobis donec recusandae perspiciatis incididuno", ImageUrl = "images/placeholders/369/lamps.jpg", CommentBy ="Comments:  13", Posted ="POSTED BY: Admin" },
                //         new MediumGridCollectionItemViewModel  { Id = "1", Title = "", Text = "Best dress for everyone ed totam velit risus viverranobis donec recusandae perspiciatis incididuno", ImageUrl = "images/placeholders/369/lamps.jpg", CommentBy ="Comments:  13", Posted ="POSTED BY: Admin" },
                //         new MediumGridCollectionItemViewModel  { Id = "1", Title = "", Text = "Best dress for everyone ed totam velit risus viverranobis donec recusandae perspiciatis incididuno", ImageUrl = "images/placeholders/369/lamps.jpg", CommentBy ="Comments:  13", Posted ="POSTED BY: Admin" },


                //     }
                //}








            };
            return View(viewModel);





        }
    }
}
