using Platform.DTO;
using Platform.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public class ProductSiteMappingConvertor
    {
        public static ProductSiteMappingDTO ConvertToProductSiteMappingDto(ProductSiteMapping productSiteMapping)
        {
            ProductSiteMappingDTO productSiteMappingDTO = new ProductSiteMappingDTO();
            productSiteMappingDTO.ProductMappingId = productSiteMapping.ProductMappingId;
            productSiteMappingDTO.SiteId = productSiteMapping.SiteId;
            productSiteMappingDTO.ItemId = productSiteMapping.ItemId;
            productSiteMappingDTO.ProductId = productSiteMapping.ProductId;

            return productSiteMappingDTO;


        }

        public static void ConvertToProductSiteMappingEntity(ref ProductSiteMapping productSiteMapping, ProductSiteMappingDTO productSiteMappingDTO, bool isUpdate)
        {
            if(isUpdate)
                productSiteMapping.ProductMappingId = productSiteMappingDTO.ProductMappingId;

            productSiteMapping.SiteId = productSiteMappingDTO.SiteId;
            productSiteMapping.ItemId = productSiteMappingDTO.ItemId;
            productSiteMapping.ProductId = productSiteMappingDTO.ProductId;


        }
    }
}
