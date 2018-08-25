using Platform.DTO;
using Platform.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public class ProductOrderConvertor
    {
        public static ProductOrderDTO ConvertToProductOrderDto(ProductOrder productOrder)
        {
            ProductOrderDTO productOrderDTO = new ProductOrderDTO();
            productOrderDTO.OrderDate = productOrder.OrderPurchaseDtm;
            productOrderDTO.OrderCustomerId = productOrder.OrderCustomerId.GetValueOrDefault();
            productOrderDTO.OrderPrice = productOrder.OrderPrice;
            productOrderDTO.OrderTax =productOrder.OrderTax.GetValueOrDefault();
            productOrderDTO.OrderTotalPrice = productOrder.OrderTotalPrice.GetValueOrDefault();
            productOrderDTO.OrderPriority = productOrder.OrderPriority;
            productOrderDTO.OrderComments = productOrder.OrderComments;
            productOrderDTO.Ref1 = productOrder.Ref1;
            productOrderDTO.Ref2 = productOrder.Ref2;
            
            return productOrderDTO;


   

    }

        public static void ConvertToProductOrderEntity(ref ProductOrder productOrder, ProductOrderDTO productOrderDTO, bool isUpdate)
        {
        if (isUpdate)
        {
            productOrderDTO.OrderId = productOrder.OrderId;
                productOrder.OrderPrice = productOrderDTO.OrderPrice;
                productOrder.OrderTax = productOrderDTO.OrderTax;
                productOrder.OrderTotalPrice = productOrderDTO.OrderTotalPrice;

            }
            else
        {
            productOrder.OrderPurchaseDtm = productOrderDTO.OrderDate;
            productOrder.OrderCustomerId = productOrderDTO.OrderCustomerId;
            productOrder.OrderPriority = productOrderDTO.OrderPriority;
            productOrder.OrderComments = productOrderDTO.OrderComments;
            
            productOrder.Ref1 = productOrderDTO.Ref1;
            productOrder.Ref2 = productOrderDTO.Ref2;

            }

        



        }
    }
}
