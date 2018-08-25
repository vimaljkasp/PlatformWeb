using Platform.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public interface IProductSalesService
    {
         List<ProductSalesDTO> GetAllProductSales();

        ProductSalesDTO GetProductSalesById(int salesId);

        void AddProductSales(ProductSalesDTO customerDto);

        void UpdateProductSales(ProductSalesDTO customerDto);

        void DeleteProductSales(int salesId);






    }
}
