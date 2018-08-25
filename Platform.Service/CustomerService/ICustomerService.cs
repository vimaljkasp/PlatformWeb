using Platform.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public interface ICustomerService
    {
         List<CustomerDto> GetAllCustomers();

        CustomerDto GetCustomerById(int customerId);

        void AddCustomer(CustomerDto customerDto);

        void UpdateCustomer(CustomerDto customerDto);

        void DeleteCustomer(int id);






    }
}
