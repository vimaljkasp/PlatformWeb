using Platform.DTO;
using Platform.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public class ProductSalesConvertor
    {
        public static ProductSalesDTO ConvertToProductSaleDto(ProductSale sale)
        {
            ProductSalesDTO productSalesDTO = new ProductSalesDTO();
            productSalesDTO.SalesId = sale.SalesId;
            productSalesDTO.SalesDate = sale.SalesDate;
            productSalesDTO.ProductMappingId = sale.ProductMappingId;
            productSalesDTO.SalesQuantity = sale.Quantity;
            productSalesDTO.SalesPrice = sale.TotalPrice;
            productSalesDTO.Ref1 = sale.Ref1;
            productSalesDTO.Ref2 = sale.Ref2;
   
            return productSalesDTO;


        }

        public static void ConvertToProductSaleEntity(ref ProductSale sale, ProductSalesDTO productSalesDTO, bool isUpdate)
        {
            if(isUpdate)
            sale.SalesId = productSalesDTO.SalesId;

            sale.SalesDate = productSalesDTO.SalesDate;
            sale.ProductMappingId = productSalesDTO.ProductMappingId;
            sale.Quantity = productSalesDTO.SalesQuantity;
            sale.TotalPrice = productSalesDTO.SalesPrice;
            sale.Ref1 = productSalesDTO.Ref1;
            sale.Ref2 = productSalesDTO.Ref2;


        }
    }
}
