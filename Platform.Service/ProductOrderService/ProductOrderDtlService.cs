﻿using Platform.DTO;
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

        public void AddProductOrderDtl(ProductOrderDtlDTO productOrderDtlDTO)
        {
            this.CalculateOrderAmount(productOrderDtlDTO);
            this.CalcualteOrderTax(productOrderDtlDTO);
            ProductOrderDetail productOrderDetail = unitOfWork.ProductOrderDtlRepository.GetById(productOrderDtlDTO.ProductOrderDetailId);
            if (productOrderDetail != null)
            {
                productOrderDetail.ProductMappingId = productOrderDtlDTO.ProductMappingId;
                if (productOrderDtlDTO.Quantity > 0)
                    productOrderDetail.Quantity = productOrderDtlDTO.Quantity;

                if (productOrderDtlDTO.OrderPrice > 0)
                    productOrderDetail.TotalPrice = productOrderDtlDTO.OrderPrice;

                if (string.IsNullOrWhiteSpace(productOrderDtlDTO.OrderStatus) == false )
                    productOrderDetail.OrderStatus = (int)((OrderStatus)Enum.Parse(typeof(OrderStatus), productOrderDtlDTO.OrderStatus));

                if (string.IsNullOrWhiteSpace(productOrderDtlDTO.VehicleNumber) == false)
                    productOrderDetail.VehicleNumber = productOrderDtlDTO.VehicleNumber;

                if (string.IsNullOrWhiteSpace(productOrderDtlDTO.DriverName) == false)
                    productOrderDetail.DriverName = productOrderDtlDTO.DriverName;

                if (string.IsNullOrWhiteSpace(productOrderDtlDTO.DriverNumber) == false)
                    productOrderDetail.DriverNumber = productOrderDtlDTO.DriverNumber;

                if (string.IsNullOrWhiteSpace(productOrderDtlDTO.JCBDriverName) == false)
                    productOrderDetail.JCBDriverName = productOrderDtlDTO.JCBDriverName;

                if (string.IsNullOrWhiteSpace(productOrderDtlDTO.RoyaltyNumber) == false)
                    productOrderDetail.RoyaltyNumber = productOrderDtlDTO.RoyaltyNumber;

                if (string.IsNullOrWhiteSpace(productOrderDtlDTO.ChallanNumber) == false)
                    productOrderDetail.ChalanNumber = productOrderDtlDTO.ChallanNumber;


                if (string.IsNullOrWhiteSpace(productOrderDtlDTO.DeliveredBy) == false)
                    productOrderDetail.DeliveredBy = productOrderDtlDTO.DeliveredBy;

                if (productOrderDetail.DeliveredDate != DateTime.MinValue)
                    productOrderDetail.DeliveredDate = productOrderDtlDTO.DeliveredDate;

                unitOfWork.ProductOrderDtlRepository.Update(productOrderDetail);

                //Update product Order for tax and total price
                ProductOrder productOrder = unitOfWork.ProductOrderRepository.GetById(productOrderDtlDTO.OrderId);
                productOrder.OrderPrice = productOrderDtlDTO.OrderPrice;
                productOrder.OrderTax = productOrderDtlDTO.OrderTax;
                productOrder.CGSTTax = productOrderDtlDTO.CGSTTax;
                productOrder.SGSTTax = productOrderDtlDTO.SGSTTax;
                productOrder.OrderDiscount = productOrderDtlDTO.OrderDiscount;
                productOrder.OrderPaidAmount = productOrderDtlDTO.OrderAmountPaid;
                productOrder.OrderTotalPrice = productOrderDtlDTO.TotalPrice - productOrderDtlDTO.OrderDiscount;
                unitOfWork.ProductOrderRepository.Update(productOrder);

                this.AddOrUpdateProductSales(productOrderDtlDTO);
                this.AddCustomerPayment(productOrderDtlDTO);
                this.AddOrUpdateCustomerWallet(productOrderDtlDTO);
                unitOfWork.SaveChanges();
            }
        }

        public void DeleteProductOrderDtl(int productOrderDtlId)
        {
            //not required as you need to delete parent order from order api
            throw new NotImplementedException();
        }

        public List<ProductOrderDtlDTO> GetAllProductOrderDtl()
        {
            
            var productOrderDtlList = unitOfWork.ProductOrderDtlRepository.GetAll();
            List<ProductOrderDtlDTO> productOrderDtlDTOList = new List<ProductOrderDtlDTO>();
         foreach (ProductOrderDetail productOrderDetail in productOrderDtlList)
            {
                if(productOrderDetail.ProductOrder.InActive==false || productOrderDetail.ProductOrder.InActive == null)
                productOrderDtlDTOList.Add(ProductOrderDtlDTOConvertor.ConvertToProductOrderDtlDto(productOrderDetail));
            }
            return productOrderDtlDTOList;
        }

        public ProductOrderDtlDTO GetProductOrderDtlById(int productOrderDtlId)
        {
            var productOrderDtl = unitOfWork.ProductOrderDtlRepository.GetById(productOrderDtlId);
            ProductOrderDtlDTO productOrderDtlDTO=ProductOrderDtlDTOConvertor.ConvertToProductOrderDtlDto(productOrderDtl);
            return productOrderDtlDTO;
        }

       

        public void UpdateProductOrderDtl(ProductOrderDtlDTO productOrderDtlDTO)
        {
            this.CalculateOrderAmount(productOrderDtlDTO);
            if (productOrderDtlDTO.OrderPrice>0)
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

                if (string.IsNullOrWhiteSpace(productOrderDtlDTO.JCBDriverName) == false)
                    productOrderDetail.JCBDriverName = productOrderDtlDTO.JCBDriverName;

                if (string.IsNullOrWhiteSpace(productOrderDtlDTO.RoyaltyNumber) == false)
                    productOrderDetail.RoyaltyNumber = productOrderDtlDTO.RoyaltyNumber;

                if (string.IsNullOrWhiteSpace(productOrderDtlDTO.ChallanNumber) == false)
                    productOrderDetail.ChalanNumber = productOrderDtlDTO.ChallanNumber;


                if (string.IsNullOrWhiteSpace(productOrderDtlDTO.DeliveredBy) == false)
                    productOrderDetail.DeliveredBy = productOrderDtlDTO.DeliveredBy;

                if (productOrderDetail.DeliveredDate != DateTime.MinValue)
                    productOrderDetail.DeliveredDate = productOrderDtlDTO.DeliveredDate;

                unitOfWork.ProductOrderDtlRepository.Update(productOrderDetail);

                //Update product Order for tax and total price
                ProductOrder productOrder = unitOfWork.ProductOrderRepository.GetById(productOrderDtlDTO.OrderId);
                productOrder.OrderPrice = productOrderDtlDTO.OrderPrice;
                productOrder.OrderTax = productOrderDtlDTO.OrderTax;
                productOrder.CGSTTax = productOrderDtlDTO.CGSTTax;
                productOrder.SGSTTax = productOrderDtlDTO.SGSTTax;
                productOrder.OrderDiscount = productOrderDtlDTO.OrderDiscount;
                productOrder.OrderPaidAmount = productOrderDtlDTO.OrderAmountPaid;
                productOrder.OrderTotalPrice = productOrderDtlDTO.TotalPrice-productOrderDtlDTO.OrderDiscount;
                unitOfWork.ProductOrderRepository.Update(productOrder);

            //    this.AddOrUpdateProductSales(productOrderDtlDTO);
            ///    this.AddCustomerPayment(productOrderDtlDTO);
            //    this.AddOrUpdateCustomerWallet(productOrderDtlDTO);
                unitOfWork.SaveChanges();
            }
        }

        private void CalcualteOrderTax(ProductOrderDtlDTO productOrderDtlDTO)
        {

            bool isTaxEnable = Convert.ToBoolean(unitOfWork.SiteConfigurationRepository.GetSiteConfigurationByKeyTypeAndKeyName("OrderTax", "IsEnable", "False"));
            if (isTaxEnable)
            {
                decimal SGSTTaxPrecentage = Convert.ToDecimal(unitOfWork.SiteConfigurationRepository.GetSiteConfigurationByKeyTypeAndKeyName("OrderTax", "SGSTPercentage", "7"));
                productOrderDtlDTO.SGSTTax = ((productOrderDtlDTO.OrderPrice * SGSTTaxPrecentage) / (decimal)100.00);
                decimal CGSTTaxPrecentage = Convert.ToDecimal(unitOfWork.SiteConfigurationRepository.GetSiteConfigurationByKeyTypeAndKeyName("OrderTax", "CGSTPercentage", "7"));
                productOrderDtlDTO.CGSTTax = ((productOrderDtlDTO.OrderPrice * CGSTTaxPrecentage) / (decimal)100.00);

            }
            else
            {
                productOrderDtlDTO.SGSTTax = 0;
                productOrderDtlDTO.CGSTTax = 0;



            }
            productOrderDtlDTO.OrderTax = productOrderDtlDTO.SGSTTax+ productOrderDtlDTO.CGSTTax;
            productOrderDtlDTO.TotalPrice = (productOrderDtlDTO.OrderPrice + productOrderDtlDTO.OrderTax);
        }

        private void CalculateOrderAmount(ProductOrderDtlDTO productOrderDtlDTO)
        {
            if (productOrderDtlDTO.Quantity > 0 && productOrderDtlDTO.ProductMappingId>0)
            {
                decimal productUnitPrice = unitOfWork.ProductSiteMappingRepository.GetById(productOrderDtlDTO.ProductMappingId).Product.ProductPrice.GetValueOrDefault();
                productOrderDtlDTO.OrderPrice = productUnitPrice * productOrderDtlDTO.Quantity;
            }
            else
            {
                productOrderDtlDTO.OrderPrice = 0;
            }


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
            customerPaymentTransaction.PaymentCrAmount = productOrderDtlDTO.OrderAmountPaid;
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
