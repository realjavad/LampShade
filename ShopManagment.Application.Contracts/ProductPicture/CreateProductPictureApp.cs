using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Features.Application;
using ShopManagment.Application.Contracts.Product;

namespace ShopManagment.Application.Contracts.ProductPicture
{
    public class CreateProductPictureApp
    {
        [Range(1,10000)]
        public long ProductId { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Picture { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string PictureAlt { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string PictureTitle { get; set; }
        public List<ProductViewModel> ProductViewModels { get; set; }
    }
}
