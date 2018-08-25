using Platform.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public interface IProductService
    {
         List<ProductDTO> GetAllProducts();

        ProductDTO GetProductById(int productId);

        void AddProduct(ProductDTO productDTO);

        void UpdateProduct(ProductDTO productDTO);

        void DeleteProduct(int productId);






    }
}
