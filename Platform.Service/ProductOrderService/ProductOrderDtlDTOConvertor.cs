using Platform.DTO;
using Platform.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public class ProductOrderDtlDTOConvertor
    {
        public static ProductOrderDtlDTO ConvertToProductOrderDtlDto(ProductOrderDetail productOrderDetail)
        {
            ProductOrderDtlDTO productOrderDtlDTO = new ProductOrderDtlDTO();
            productOrderDtlDTO.ProductOrderDetailId = productOrderDetail.ProductOrderDetailId;
            productOrderDtlDTO.CustomerId = productOrderDetail.ProductOrder.OrderCustomerId.GetValueOrDefault();
            productOrderDtlDTO.CustomerName = productOrderDetail.ProductOrder.Customer.Name;

            productOrderDtlDTO.OrderId = productOrderDetail.ProductOrder.OrderId;
            productOrderDtlDTO.OrderNumber = productOrderDetail.ProductOrder.OrderNumber;
            productOrderDtlDTO.ProductMappingId = productOrderDetail.ProductMappingId.GetValueOrDefault();
            productOrderDtlDTO.ProductName = productOrderDetail.ProductSiteMapping.Product.ProductName;
            productOrderDtlDTO.UnitPrice = productOrderDetail.ProductSiteMapping.Product.ProductPrice.HasValue ? productOrderDetail.ProductSiteMapping.Product.ProductPrice.Value : 0;
            
            productOrderDtlDTO.Quantity = productOrderDetail.Quantity.GetValueOrDefault();
            productOrderDtlDTO.OrderPrice = productOrderDetail.ProductOrder.OrderPrice;
            productOrderDtlDTO.OrderTax = productOrderDetail.ProductOrder.OrderTax.GetValueOrDefault();
            productOrderDtlDTO.CGSTTax = productOrderDetail.ProductOrder.CGSTTax.GetValueOrDefault();
            productOrderDtlDTO.SGSTTax = productOrderDetail.ProductOrder.SGSTTax.GetValueOrDefault();
            productOrderDtlDTO.OrderDiscount = productOrderDetail.ProductOrder.OrderDiscount.GetValueOrDefault();
            productOrderDtlDTO.OrderAmountPaid = productOrderDetail.ProductOrder.OrderPaidAmount.GetValueOrDefault();
            productOrderDtlDTO.TotalPrice = productOrderDetail.ProductOrder.OrderTotalPrice.GetValueOrDefault();

            productOrderDtlDTO.OrderStatus = productOrderDetail.OrderStatus.ToString();
            productOrderDtlDTO.DeliveryExpectedDate = productOrderDetail.DeliveryExpectedDate;
            productOrderDtlDTO.DeliveredDate = productOrderDetail.DeliveredDate.GetValueOrDefault();
            productOrderDtlDTO.DeliveredBy = productOrderDetail.DeliveredBy;
            productOrderDtlDTO.VehicleNumber = productOrderDetail.VehicleNumber;
            productOrderDtlDTO.DriverName = productOrderDetail.DriverName;
            productOrderDtlDTO.DriverNumber = productOrderDetail.DriverNumber;
            productOrderDtlDTO.JCBDriverName = productOrderDetail.JCBDriverName;
            productOrderDtlDTO.RoyaltyNumber = productOrderDetail.RoyaltyNumber;

            productOrderDtlDTO.ChallanNumber = productOrderDetail.ChalanNumber;
            productOrderDtlDTO.OrderAddress = productOrderDetail.OrderAddress;

            productOrderDtlDTO.Ref1 = productOrderDetail.Ref1;
            productOrderDtlDTO.Ref2 = productOrderDetail.Ref2;


            return productOrderDtlDTO;


        }

        public static void ConvertToProductOrderDetailEntity(ref ProductOrderDetail productOrderDetail, ProductOrderDtlDTO productOrderDtlDTO, bool isUpdate)
        {
            if (isUpdate)
            {
                productOrderDetail.DeliveredDate = productOrderDtlDTO.DeliveredDate;
                productOrderDetail.DeliveredBy = productOrderDtlDTO.DeliveredBy;
                productOrderDetail.VehicleNumber = productOrderDtlDTO.VehicleNumber;
                productOrderDetail.DriverName = productOrderDtlDTO.DriverName;
                productOrderDetail.DriverNumber = productOrderDtlDTO.DriverNumber;
                productOrderDetail.JCBDriverName = productOrderDtlDTO.JCBDriverName;
                productOrderDetail.RoyaltyNumber = productOrderDtlDTO.RoyaltyNumber;
                productOrderDetail.ChalanNumber = productOrderDtlDTO.ChallanNumber;
                productOrderDetail.OrderAddress = productOrderDtlDTO.OrderAddress;
            }
            else
            {
                productOrderDetail.OrderId = productOrderDtlDTO.OrderId;
                productOrderDetail.ProductMappingId = productOrderDtlDTO.ProductMappingId;
                productOrderDetail.Quantity = productOrderDtlDTO.Quantity;
                productOrderDetail.TotalPrice = productOrderDtlDTO.TotalPrice;
                productOrderDetail.DeliveryExpectedDate = productOrderDtlDTO.DeliveryExpectedDate;


            }
            productOrderDetail.OrderStatus = (int)((OrderStatus)Enum.Parse(typeof(OrderStatus), productOrderDtlDTO.OrderStatus));

            productOrderDetail.Ref1 = productOrderDtlDTO.Ref1;
            productOrderDetail.Ref2 = productOrderDtlDTO.Ref2;


        }
    }
}
