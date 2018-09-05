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
    public class CustomerPaymentService : ICustomerPaymentService,IDisposable
    {
        private  UnitOfWork unitOfWork = new UnitOfWork();


        public void AddCustomerPayment(CustomerPaymentDTO customerPaymentDTO)
        {

            CustomerPaymentTransaction customerPaymentTransaction = new CustomerPaymentTransaction();
            customerPaymentTransaction.CustomerPaymentId = unitOfWork.DashboardRepository.NextNumberGenerator("CustomerPaymentTransaction");
            CustomerPaymentConvertor.ConvertToCustomerPaymentEntity(ref customerPaymentTransaction, customerPaymentDTO, false);
            unitOfWork.CustomerPaymentRepository.Add(customerPaymentTransaction);
            this.UpdateCustomerWallet(customerPaymentDTO);
            
            this.UpdateAmountPaid(customerPaymentDTO);
            unitOfWork.SaveChanges();
        }

        private void UpdateAmountPaid(CustomerPaymentDTO customerPaymentDTO)
        {
            if (customerPaymentDTO.OrderId > 0)
            {
                var productOrder = unitOfWork.ProductOrderRepository.GetById(customerPaymentDTO.OrderId);
                if (productOrder != null)
                {
                    productOrder.OrderPaidAmount += customerPaymentDTO.PaymentCrAmount;
                    unitOfWork.ProductOrderRepository.Update(productOrder);
                }
            }
        }

        private void UpdateCustomerWallet(CustomerPaymentDTO customerPaymentDTO)
        {
            var customerWallet = unitOfWork.CustomerWalletRepository.GetByCustomerId(customerPaymentDTO.CustomerId);
            if (customerWallet != null)
            {
                customerWallet.WalletBalance -= customerPaymentDTO.PaymentCrAmount;
                if(customerWallet.WalletBalance>0)
                customerWallet.AmountDueDate = DateTime.Now.AddDays(10);
                unitOfWork.CustomerWalletRepository.Update(customerWallet);
               
            }
            else
            {
                customerWallet = new CustomerWallet();
                customerWallet.WalletId= unitOfWork.DashboardRepository.NextNumberGenerator("CustomerWallet");
                customerWallet.CustomerId = customerPaymentDTO.CustomerId;
                customerWallet.WalletBalance -= customerPaymentDTO.PaymentCrAmount;
                customerWallet.AmountDueDate = DateTime.Now.AddDays(10);
                unitOfWork.CustomerWalletRepository.Add(customerWallet);
              
            }
        }

        public void DeleteCustomerPayemt(int customerPaymentId)
        {
            unitOfWork.CustomerPaymentRepository.Delete(customerPaymentId);
            unitOfWork.SaveChanges();
        }

        public List<CustomerPaymentDTO> GetAllCustomerOrders()
        {
            List<CustomerPaymentDTO> customerPaymentsList = new List<CustomerPaymentDTO>();
            var productOrders = unitOfWork.ProductOrderRepository.GetAll();
            if (productOrders != null)
            {
                foreach (var productOrder in productOrders)
                {
                    if (productOrder.InActive == false || productOrder.InActive == null)
                        customerPaymentsList.Add(CustomerPaymentConvertor.ConvertToCustomerPaymentDto(productOrder));
                }

            }

            return customerPaymentsList;
        }

        public CustomerPaymentDTO GetCustomerPaymentById(int customerPaymentId)
        {
            CustomerPaymentDTO customerPaymentDTO = null;
            var customerPayment = unitOfWork.CustomerPaymentRepository.GetById(customerPaymentId);
            if (customerPayment != null)
            {
                customerPaymentDTO = CustomerPaymentConvertor.ConvertToCustomerPaymentDto(customerPayment);
            }
            return customerPaymentDTO;
        }

        public void UpdateCustomerPayment(CustomerPaymentDTO customerPaymentDTO)
        {
            CustomerPaymentTransaction customerPaymentTransaction = null;
            CustomerPaymentConvertor.ConvertToCustomerPaymentEntity(ref customerPaymentTransaction, customerPaymentDTO, true);
            unitOfWork.CustomerPaymentRepository.Update(customerPaymentTransaction);
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
