using Platform.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public interface IProductOrderDtlService
    {
         List<ProductOrderDtlDTO> GetAllProductOrderDtl();

        ProductOrderDtlDTO GetProductOrderDtlById(int productOrderDtlId);

        void AddProductOrderDtl(ProductOrderDtlDTO customerDto);

        void UpdateProductOrderDtl(ProductOrderDtlDTO customerDto);

        void DeleteProductOrderDtl(int productOrderDtlId);






    }
}
