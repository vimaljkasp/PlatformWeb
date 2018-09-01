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
            productOrderDTO.OrderId = productOrder.OrderId;
            productOrderDTO.OrderNumber = productOrder.OrderNumber;
            productOrderDTO.ProductMappingId = productOrder.ProductOrderDetails.FirstOrDefault().ProductMappingId.GetValueOrDefault();
            productOrderDTO.ProductOrderDetailId = productOrder.ProductOrderDetails.FirstOrDefault().ProductOrderDetailId;
            productOrderDTO.ProductName = productOrder.ProductOrderDetails.FirstOrDefault().ProductSiteMapping.Product.ProductName;
            productOrderDTO.Quantity = productOrder.ProductOrderDetails.FirstOrDefault().Quantity.GetValueOrDefault();
            productOrderDTO.Amount= productOrder.OrderTotalPrice.GetValueOrDefault();
            productOrderDTO.OrderStatus =((OrderStatus)(productOrder.ProductOrderDetails.FirstOrDefault().OrderStatus)).ToString();
            productOrderDTO.CustomerId = productOrder.Customer.CustomerId;
            productOrderDTO.CustomerName = productOrder.Customer.Name;
            productOrderDTO.CustomerMobileNumber = productOrder.Customer.MobileNumber;
            productOrderDTO.OrderDate = productOrder.OrderPurchaseDtm;
            productOrderDTO.OrderCustomerId = productOrder.OrderCustomerId.GetValueOrDefault();
            productOrderDTO.OrderPrice = productOrder.OrderPrice;
            productOrderDTO.OrderTax =productOrder.OrderTax.GetValueOrDefault();
            productOrderDTO.OrderTotalPrice = productOrder.OrderTotalPrice.GetValueOrDefault();
            productOrderDTO.OrderPriority = productOrder.OrderPriority;
            productOrderDTO.OrderComments = productOrder.OrderComments;
            productOrderDTO.OrderAddress = productOrder.ProductOrderDetails.FirstOrDefault().OrderAddress;
            productOrderDTO.ExpectedDeliveryDate = productOrder.ProductOrderDetails.FirstOrDefault().DeliveryExpectedDate;
            productOrderDTO.Ref1 = productOrder.Ref1;
            productOrderDTO.Ref2 = productOrder.Ref2;
            
            return productOrderDTO;

    }

        public static void ConvertToProductOrderEntity(ref ProductOrder productOrder, ProductOrderDTO productOrderDTO, bool isUpdate)
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
