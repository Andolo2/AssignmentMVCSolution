using AssignmentMVC.Models.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentMVC.Models.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string Title { get; set; } = null!;
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }
        public bool IsNew { get; set; }
        public bool IsPopular { get; set; }
        public bool IsFeatured { get; set; }

        public static implicit operator ProductModel(ProductEntity entity)
        {
            return new ProductModel
            {
                Id = entity.Id,
                ImageUrl = entity.ImageUrl,
                Title = entity.Title,
                Price = entity.Price,
                IsNew = entity.IsNew,
                IsPopular = entity.IsPopular,
                IsFeatured = entity.IsFeatured
            };
        }
    }


}
