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
    public class CustomerService : ICustomerService,IDisposable
    {
        private  UnitOfWork unitOfWork=new UnitOfWork();
     

        public List<CustomerDto> GetAllCustomers()
        { 
            List<CustomerDto> customerList = new List<CustomerDto>();
            var customers = unitOfWork.CustomerRepository.GetAll();
            if (customers != null)
            {
                foreach (var customer in customers)
                {
                    customerList.Add(CustomerConvertor.ConvertToCustomerDto(customer));
                }

            }

            return customerList;

        }


        public CustomerDto GetCustomerById(int customerId)
        {
            CustomerDto customerDto = null;
            var customer = unitOfWork.CustomerRepository.GetById(customerId);
            if (customer != null)
            {
                customerDto = CustomerConvertor.ConvertToCustomerDto(customer);
            }
            return customerDto;
        }

        

        public void AddCustomer(CustomerDto customerDto)
        {
          //  this.CheckForExisitngCustomer(customerDto.MobileNumber);
            Customer customer = new Customer();
            customer.CustomerId = unitOfWork.DashboardRepository.NextNumberGenerator("Customer");
            CustomerConvertor.ConvertToCustomerEntity(ref customer, customerDto, false);
            unitOfWork.CustomerRepository.Add(customer);
            //creating customer wallet with customer 
            CustomerWallet customerWallet = new CustomerWallet();
            customerWallet.WalletId = unitOfWork.DashboardRepository.NextNumberGenerator("CustomerWallet");
            customerWallet.CustomerId = customer.CustomerId;
            customerWallet.WalletBalance = 0;
            customerWallet.AmountDueDate = DateTime.Now.AddDays(10);
            unitOfWork.CustomerWalletRepository.Add(customerWallet);
           
            unitOfWork.SaveChanges();
           
            
        }

        private void CheckForExisitngCustomer(string mobileNumber)
        {
            var existingCustomer = unitOfWork.CustomerRepository.GetCustomerByMobileNumber(mobileNumber);
            if (existingCustomer != null)
                throw new PlatformModuleException("Customer Account Already Exist with given Mobile Number");
        }

        public void UpdateCustomer(CustomerDto customerDto)
        {

            var customer = unitOfWork.CustomerRepository.GetById(customerDto.CustomerId);
            CustomerConvertor.ConvertToCustomerEntity(ref customer, customerDto, true);
           
            unitOfWork.CustomerRepository.Update(customer);
            unitOfWork.SaveChanges();
        }

        public void DeleteCustomer(int id)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            //get customer
            var customer = unitOfWork.CustomerRepository.GetById(id);
            if((customer.ProductOrders !=null && customer.ProductOrders.Count()>0) || (customer.CustomerWallets !=null && 
                customer.CustomerWallets.Count()>0 && customer.CustomerWallets.FirstOrDefault().WalletBalance>0))
                {
                throw new PlatformModuleException("Customer Account Cannot be deleted as it is associated with orders");
            }
            unitOfWork.CustomerRepository.Delete(id);
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
