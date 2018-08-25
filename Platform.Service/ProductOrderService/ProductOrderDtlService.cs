using Platform.DTO;
using Platform.Repository;
using Platform.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public class ProductOrderDtlService : IProductOrderDtlService,IDisposable
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
       

        

        public void AddProductOrderDtl(ProductOrderDtlDTO customerDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteProductOrderDtl(int productOrderDtlId)
        {
            throw new NotImplementedException();
        }

        public List<ProductOrderDtlDTO> GetAllProductOrderDtl()
        {
            throw new NotImplementedException();
        }

        public ProductOrderDtlDTO GetProductOrderDtlById(int productOrderDtlId)
        {
            throw new NotImplementedException();
        }

       

        public void UpdateProductOrderDtl(ProductOrderDtlDTO productOrderDtlDTO)
        {
            this.CalcualteOrderTax(productOrderDtlDTO);
            ProductOrderDetail productOrderDetail = unitOfWork.ProductOrderDtlRepository.GetById(productOrderDtlDTO.ProductOrderDetailId);
            if (productOrderDetail != null)
            {
                productOrderDetail.ProductMappingId = productOrderDtlDTO.ProductMappingId;
                if (productOrderDtlDTO.Quantity > 0)
                    productOrderDetail.Quantity = productOrderDtlDTO.Quantity;

                if (productOrderDtlDTO.OrderPrice > 0)
                    productOrderDetail.TotalPrice = productOrderDtlDTO.OrderPrice;

                if (string.IsNullOrWhiteSpace(productOrderDtlDTO.OrderStatus) == false)
                    productOrderDetail.OrderStatus = (int)((OrderStatus)Enum.Parse(typeof(OrderStatus), productOrderDtlDTO.OrderStatus));

                if (string.IsNullOrWhiteSpace(productOrderDtlDTO.VehicleNumber) == false)
                    productOrderDetail.VehicleNumber = productOrderDtlDTO.VehicleNumber;

                if (string.IsNullOrWhiteSpace(productOrderDtlDTO.DriverName) == false)
                    productOrderDetail.DriverName = productOrderDtlDTO.DriverName;

                if (string.IsNullOrWhiteSpace(productOrderDtlDTO.DriverNumber) == false)
                    productOrderDetail.DriverNumber = productOrderDtlDTO.DriverNumber;

                if (string.IsNullOrWhiteSpace(productOrderDtlDTO.JCBDriverNumber) == false)
                    productOrderDetail.JCBDriverNumber = productOrderDtlDTO.JCBDriverNumber;

                if (string.IsNullOrWhiteSpace(productOrderDtlDTO.RoyaltyNumber) == false)
                    productOrderDetail.RoyaltyNumber = productOrderDtlDTO.RoyaltyNumber;

                if (string.IsNullOrWhiteSpace(productOrderDtlDTO.DeliveredBy) == false)
                    productOrderDetail.DeliveredBy = productOrderDtlDTO.DeliveredBy;

                if (productOrderDetail.DeliveredDate != DateTime.MinValue)
                    productOrderDetail.DeliveredDate = productOrderDtlDTO.DeliveredDate;

                unitOfWork.ProductOrderDtlRepository.Update(productOrderDetail);

                //Update product Order for tax and total price
                ProductOrder productOrder = unitOfWork.ProductOrderRepository.GetById(productOrderDtlDTO.OrderId);
                productOrder.OrderPrice = productOrderDtlDTO.OrderPrice;
                productOrder.OrderTax = productOrderDtlDTO.OrderTax;
                productOrder.OrderTotalPrice = productOrderDtlDTO.TotalPrice;
                unitOfWork.ProductOrderRepository.Update(productOrder);

                this.AddOrUpdateProductSales(productOrderDtlDTO);
                this.AddCustomerPayment(productOrderDtlDTO);
                this.AddOrUpdateCustomerWallet(productOrderDtlDTO);
                unitOfWork.SaveChanges();
            }
        }

        private void CalcualteOrderTax(ProductOrderDtlDTO productOrderDtlDTO)
        {

            bool isTaxEnable = Convert.ToBoolean(unitOfWork.SiteConfigurationRepository.GetSiteConfigurationByKeyTypeAndKeyName("OrderTax", "IsEnable", "False"));
            if (isTaxEnable)
            {
                decimal taxPrecentage = Convert.ToDecimal(unitOfWork.SiteConfigurationRepository.GetSiteConfigurationByKeyTypeAndKeyName("OrderTax", "Percentage", "7"));
                productOrderDtlDTO.OrderTax = ((productOrderDtlDTO.OrderPrice * taxPrecentage) / (decimal)100.00);
            }
            else
            {
                productOrderDtlDTO.OrderTax = 0;

            }

            productOrderDtlDTO.TotalPrice = productOrderDtlDTO.OrderPrice + productOrderDtlDTO.OrderTax;
        }

        private void AddOrUpdateProductSales(ProductOrderDtlDTO productOrderDtlDTO)
        {
         
                var sales = unitOfWork.ProductSalesRepository.GetByProductAndSalesDate(productOrderDtlDTO.ProductMappingId, DateTime.Now.Date);
                if (sales == null)
                {
                    ProductSale productSale = new ProductSale();
                    productSale.SalesId = unitOfWork.DashboardRepository.NextNumberGenerator("ProductSales");
                    productSale.SalesDate = DateTime.Now.Date;
                    productSale.TotalPrice = productOrderDtlDTO.TotalPrice;
                    productSale.ProductMappingId = productOrderDtlDTO.ProductMappingId;
                    productSale.Quantity = productOrderDtlDTO.Quantity;
                    unitOfWork.ProductSalesRepository.Add(productSale);
                }
                else
                {
                    sales.Quantity += productOrderDtlDTO.Quantity;
                    sales.TotalPrice += productOrderDtlDTO.TotalPrice;
                    unitOfWork.ProductSalesRepository.Update(sales);
                }
            
        }

        private void AddOrUpdateCustomerWallet(ProductOrderDtlDTO productOrderDtlDTO)
        {
            var customerWallet = unitOfWork.CustomerWalletRepository.GetByCustomerId(productOrderDtlDTO.CustomerId);
            if (customerWallet != null)
            {
                customerWallet.WalletBalance += productOrderDtlDTO.TotalPrice;
                unitOfWork.CustomerWalletRepository.Update(customerWallet);
            }
            else
            {
                customerWallet = new CustomerWallet();
                customerWallet.WalletId = unitOfWork.DashboardRepository.NextNumberGenerator("CustomerWallet");
                customerWallet.CustomerId = productOrderDtlDTO.CustomerId;
                customerWallet.WalletBalance = productOrderDtlDTO.TotalPrice;
                customerWallet.AmountDueDate = DateTime.Now.AddDays(10);
                unitOfWork.CustomerWalletRepository.Add(customerWallet);
            }
        }

        public void AddCustomerPayment(ProductOrderDtlDTO productOrderDtlDTO)
        {

            CustomerPaymentTransaction customerPaymentTransaction = new CustomerPaymentTransaction();
            customerPaymentTransaction.CustomerPaymentId = unitOfWork.DashboardRepository.NextNumberGenerator("CustomerPaymentTransaction");
            customerPaymentTransaction.CustomerId = productOrderDtlDTO.CustomerId;
            customerPaymentTransaction.OrderId = productOrderDtlDTO.OrderId;
            customerPaymentTransaction.PaymentCrAmount = 0;
            customerPaymentTransaction.PaymentDrAmount = productOrderDtlDTO.TotalPrice;
            customerPaymentTransaction.PaymentReceivedBy ="Order Placed";
            customerPaymentTransaction.PaymentDate = DateTime.Now.Date;
            unitOfWork.CustomerPaymentRepository.Add(customerPaymentTransaction);
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
