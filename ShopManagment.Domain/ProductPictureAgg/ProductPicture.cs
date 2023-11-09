using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Features.Domain;

namespace ShopManagment.Domain.ProductPictureAgg
{
    public class ProductPicture : EntityBase<long>
    {
        public long ProductId { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string PictureLink { get; private set; }
        public bool IsRemove { get; private set; }
        public Product.Product Product { get; private set; }

        protected ProductPicture()
        {
        }

        public ProductPicture(long productId, string picture, string pictureAlt, string pictureTitle, string pictureLink)
        {
            ProductId = productId;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            IsRemove = false;
            PictureLink = pictureLink;
        }

        public void Edit(long productId, string picture, string pictureAlt, string pictureTitle, string pictureLink)
        {
            ProductId = productId;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            PictureLink = pictureLink;
        }

        public void Remove()
        {
            IsRemove = true;
        }

        public void Restore()
        {
            IsRemove = false;
        }
    }
}
