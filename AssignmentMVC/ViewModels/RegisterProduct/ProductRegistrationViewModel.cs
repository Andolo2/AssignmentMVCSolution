using AssignmentMVC.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AssignmentMVC.ViewModels.RegisterProduct
{
    public class ProductRegistrationViewModel
    {





        ////[Required(ErrorMessage = "Add a product Image URL")]
        ////[DisplayName("Product Image: ")]
        ////public string ImageUrl { get; set; } = null!;


        [DataType(DataType.Upload)]
        public IFormFile? Image { get; set; }


        [Required(ErrorMessage = "Add a product Title")]
        [DisplayName("Product Title: ")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Add a product price")]
        [DisplayName("Product Price: ")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DisplayName("Is new: ")]
        public bool IsNew { get; set; }

        [DisplayName("Is popular: ")]
        public bool IsPopular { get; set; }

        [DisplayName("Is featured: ")]
        public bool IsFeatured { get; set; }

        public static implicit operator ProductEntity(ProductRegistrationViewModel productRegistrationViewModel)
        {
            var entity =  new ProductEntity
            {
                //ImageUrl = productRegistrationViewModel.ImageUrl,
                Title = productRegistrationViewModel.Title,
                Price = productRegistrationViewModel.Price,
                IsNew = productRegistrationViewModel.IsNew,
                IsPopular = productRegistrationViewModel.IsPopular,
                IsFeatured = productRegistrationViewModel.IsFeatured
            };

            if(productRegistrationViewModel.Image != null)
            {
                entity.ImageUrl = $"{productRegistrationViewModel.Image.FileName}";
            }

            return entity;
        }

        public ProductEntity ToProductEntity()
        {
            return new ProductEntity
            {
                ImageUrl = this.Image.FileName,
                Title = this.Title,
                Price = this.Price,
                IsNew = this.IsNew,
                IsPopular = this.IsPopular,
                IsFeatured = this.IsFeatured
            };
        }



    }

}
