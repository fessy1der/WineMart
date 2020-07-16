using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WineMart.Web.ViewModels;

namespace WineMart.Web.Mappings
{
    public class ProductMapping
    {
        public static ProductViewModel SerializeProductModel(Data.Models.Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                DateCreated = product.DateCreated,
                DateUpdated = product.DateUpdated,
                Price = product.Price,
                Name = product.Name,
                Description = product.Description,
                IsTaxable = product.IsTaxable,
                IsArchived = product.IsArchived
            };
        }

        public static Data.Models.Product SerializeProductModel(ProductViewModel product)
        {
            return new Data.Models.Product
            {
                Id = product.Id,
                DateCreated = product.DateCreated,
                DateUpdated = product.DateUpdated,
                Price = product.Price,
                Name = product.Name,
                Description = product.Description,
                IsTaxable = product.IsTaxable,
                IsArchived = product.IsArchived
            };
        }
    }
}
