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
            productOrderDtlDTO.OrderId = productOrderDetail.OrderId.GetValueOrDefault();
            productOrderDtlDTO.ProductMappingId = productOrderDetail.ProductMappingId.GetValueOrDefault();
            productOrderDtlDTO.Quantity = productOrderDetail.Quantity.GetValueOrDefault();

            productOrderDtlDTO.TotalPrice = productOrderDetail.TotalPrice.GetValueOrDefault();

            productOrderDtlDTO.OrderStatus = productOrderDetail.OrderStatus.ToString();
            productOrderDtlDTO.DeliveryExpectedDate = productOrderDetail.DeliveryExpectedDate;
            productOrderDtlDTO.DeliveredDate = productOrderDetail.DeliveredDate.GetValueOrDefault();
            productOrderDtlDTO.DeliveredBy = productOrderDetail.DeliveredBy;
            productOrderDtlDTO.VehicleNumber = productOrderDetail.VehicleNumber;
            productOrderDtlDTO.DriverName = productOrderDetail.DriverName;
            productOrderDtlDTO.DriverNumber = productOrderDetail.DriverNumber;
            productOrderDtlDTO.JCBDriverNumber = productOrderDetail.JCBDriverNumber;
            productOrderDtlDTO.RoyaltyNumber = productOrderDetail.RoyaltyNumber;
            productOrderDtlDTO.OrderAddress = productOrderDetail.OrderAddress;

            productOrderDtlDTO.Ref1 = productOrderDtlDTO.Ref1;
            productOrderDtlDTO.Ref2 = productOrderDtlDTO.Ref2;


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
                productOrderDetail.JCBDriverNumber = productOrderDtlDTO.JCBDriverNumber;
                productOrderDetail.RoyaltyNumber = productOrderDtlDTO.RoyaltyNumber;
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
