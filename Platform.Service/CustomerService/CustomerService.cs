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
