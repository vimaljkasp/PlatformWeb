using Platform.DTO;
using Platform.Repository;
using Platform.Sql;
using Platform.Utilities.ExceptionHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public class ProductOrderService : IProductOrderService,IDisposable
    {
        private UnitOfWork unitOfWork =new UnitOfWork();
       
        

        public void AddProductOrder(ProductOrderDTO productOrderDTO)
        {
            ProductOrder productOrder = new ProductOrder();
            productOrder.OrderId = unitOfWork.DashboardRepository.NextNumberGenerator("ProductOrder");
            productOrder.OrderNumber = "OD" + productOrder.OrderId.ToString();

            List<ProductOrderDetail> productOrderDetails = new List<ProductOrderDetail>();
            ProductOrderConvertor.ConvertToProductOrderEntity(ref productOrder, productOrderDTO, false);
            ProductOrderDetail productOrderDetail = new ProductOrderDetail();
            productOrderDetail.ProductOrderDetailId= unitOfWork.DashboardRepository.NextNumberGenerator("ProductOrderDetail");
            productOrderDetail.OrderId = productOrder.OrderId;
            productOrderDetail.ProductMappingId = productOrderDTO.ProductMappingId;
            productOrderDetail.Quantity = productOrderDTO.Qunatity;
            productOrderDetail.OrderAddress = productOrderDTO.OrderAddress;
            if(productOrderDTO.ExpectedDeliveryDate==DateTime.MinValue)
                productOrderDetail.DeliveryExpectedDate = DateTime.Now.AddDays(10);
            else
            productOrderDetail.DeliveryExpectedDate = productOrderDTO.ExpectedDeliveryDate;
            productOrderDetails.Add(productOrderDetail);
            productOrder.ProductOrderDetails = productOrderDetails;
            unitOfWork.ProductOrderRepository.Add(productOrder);
            unitOfWork.SaveChanges();           
        }

        public void DeleteProductOrder(int productId)
        {
            throw new NotImplementedException();
        }

        public List<ProductOrders> GetAllProductOrders()
        {
         
           return unitOfWork.DashboardRepository.GetProductOrders();
        }

        public ProductOrderDTO GetProductOrderById(int productId)
        {
            var productOrder = unitOfWork.ProductOrderRepository.GetById(productId);

            return ProductOrderConvertor.ConvertToProductOrderDto(productOrder);

        }

        public void UpdateProductOrder(ProductOrderDTO productOrderDTO)
        {
            throw new NotImplementedException();
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
