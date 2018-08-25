using Platform.DTO;
using Platform.Repository;
using Platform.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public class ProductSiteMappingService : IProductSiteMappingService, IDisposable
    {
        private UnitOfWork unitOfWork =new UnitOfWork();

        


        public void AddProductSiteMapping(ProductSiteMappingDTO productSiteMappingDTO)
        {
            ProductSiteMapping productSiteMapping = new ProductSiteMapping();

            ProductSiteMappingConvertor.ConvertToProductSiteMappingEntity(ref productSiteMapping, productSiteMappingDTO, false);
            unitOfWork.ProductSiteMappingRepository.Add(productSiteMapping);
        }

        public void DeleteProductSiteMapping(int productSiteMappingId)
        {
            unitOfWork.ProductSiteMappingRepository.Delete(productSiteMappingId);
        }

        public List<ProductSiteMappingDTO> GetAllProductSiteMapping()
        {
            List<ProductSiteMappingDTO> productSiteMappingList = new List<ProductSiteMappingDTO>();
            var productSiteMappings = unitOfWork.ProductSiteMappingRepository.GetAll();
            if (productSiteMappings != null)
            {
                foreach (var productSiteMapping in productSiteMappings)
                {
                    productSiteMappingList.Add(ProductSiteMappingConvertor.ConvertToProductSiteMappingDto(productSiteMapping));
                }

            }

            return productSiteMappingList;
        }

        public ProductSiteMappingDTO GetProductSiteMappinById(int productSiteMappingId)
        {
            ProductSiteMappingDTO productSiteMappingDTO = null;
            var productSiteMapping = unitOfWork.ProductSiteMappingRepository.GetById(productSiteMappingId);
            if (productSiteMapping != null)
            {
                productSiteMappingDTO = ProductSiteMappingConvertor.ConvertToProductSiteMappingDto(productSiteMapping);
            }
            return productSiteMappingDTO;
        }

        public void UpdateProductSiteMapping(ProductSiteMappingDTO productSiteMappingDTO)
        {
            ProductSiteMapping productSiteMapping = new ProductSiteMapping();
            ProductSiteMappingConvertor.ConvertToProductSiteMappingEntity(ref productSiteMapping, productSiteMappingDTO, true);
            unitOfWork.ProductSiteMappingRepository.Update(productSiteMapping);
        }
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (unitOfWork != null)
                {
                    unitOfWork.Dispose();
                    unitOfWork = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
