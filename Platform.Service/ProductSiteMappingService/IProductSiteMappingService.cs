using Platform.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public interface IProductSiteMappingService
    {
         List<ProductSiteMappingDTO> GetAllProductSiteMapping();

        ProductSiteMappingDTO GetProductSiteMappinById(int productSiteMappingId);

        void AddProductSiteMapping(ProductSiteMappingDTO productSiteMappingDTO);

        void UpdateProductSiteMapping(ProductSiteMappingDTO productSiteMappingDTO);

        void DeleteProductSiteMapping(int productSiteMappingId);






    }
}
