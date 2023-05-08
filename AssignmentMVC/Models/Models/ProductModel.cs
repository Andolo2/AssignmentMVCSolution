
using AssignmentMVC.Models.Entities;

namespace AssignmentMVC.Models.Models
{
    public class ProductModel
    {


        public int Id { get; set; }


        public string? ImageUrl { get; set; }

        public string Title { get; set; } = null!;


        public decimal Price { get; set; }

        public bool IsNew { get; set; }
        public bool IsPopular { get; set; }
        public bool IsFeatured { get; set; }




    }
}
