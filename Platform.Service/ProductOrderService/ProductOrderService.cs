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
            productOrderDetail.Quantity = productOrderDTO.Quantity;
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

        public void DeleteProductOrder(int orderId)
        {
            var productOrder = unitOfWork.ProductOrderRepository.GetById(orderId);
            productOrder.InActive = true;
            unitOfWork.ProductOrderRepository.Update(productOrder);
            unitOfWork.SaveChanges();
        }

        public List<ProductOrders> GetAllProductOrders()
        {
         
           return unitOfWork.DashboardRepository.GetProductOrders();
        }

        public ProductOrders GetProductOrderById(int orderId)
        {
            return  unitOfWork.DashboardRepository.GetProductOrders().Where(o=>o.OrderId==orderId).FirstOrDefault();


        }


        public void UpdateProductOrder(ProductOrderDTO productOrderDTO)
        {
            ProductOrder productOrder = unitOfWork.ProductOrderRepository.GetById(productOrderDTO.OrderId);

            ProductOrderDetail productOrderDetail = unitOfWork.ProductOrderDtlRepository.GetByOrderId(productOrderDTO.OrderId);

            

            if (string.IsNullOrWhiteSpace(productOrderDTO.OrderAddress) == false)
                productOrderDetail.OrderAddress = productOrderDTO.OrderAddress;

            if (string.IsNullOrWhiteSpace(productOrderDTO.OrderComments) == false)
                productOrder.OrderComments = productOrderDTO.OrderComments;

            if (string.IsNullOrWhiteSpace(productOrderDTO.OrderPriority) == false)
                productOrder.OrderPriority = productOrderDTO.OrderPriority;

            if (productOrderDTO.ExpectedDeliveryDate != DateTime.MinValue)
                productOrderDetail.DeliveryExpectedDate = productOrderDTO.ExpectedDeliveryDate;

            if (productOrderDTO.Quantity > 0)
                productOrderDetail.Quantity = productOrderDTO.Quantity;
            unitOfWork.ProductOrderRepository.Update(productOrder);
            unitOfWork.ProductOrderDtlRepository.Update(productOrderDetail);

            unitOfWork.SaveChanges();
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
