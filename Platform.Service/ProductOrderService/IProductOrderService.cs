using Platform.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public interface IProductOrderService
    {
         List<ProductOrders> GetAllProductOrders();

        ProductOrderDTO GetProductOrderById(int productId);

        void AddProductOrder(ProductOrderDTO productOrderDTO);

        void UpdateProductOrder(ProductOrderDTO productOrderDTO);

        void DeleteProductOrder(int productId);






    }
}
