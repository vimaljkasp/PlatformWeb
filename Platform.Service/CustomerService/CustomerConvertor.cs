using Platform.DTO;
using Platform.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public class CustomerConvertor
    {
        public static CustomerDto ConvertToCustomerDto(Customer customer)
        {
            CustomerDto customerDto = new CustomerDto();
            customerDto.CustomerId = customer.CustomerId;
            customerDto.Name = customer.Name;
            customerDto.AddressLine1 = customer.AddressLine1;
            customerDto.AddressLine2 = customer.AddressLine2;
            customerDto.City = customer.City;
            customerDto.District = customer.District;
            customerDto.MobileNumber = customer.MobileNumber;
            customerDto.HomePhone = customer.HomePhone;
            customerDto.State = customer.State;
            customerDto.PostalCode = customer.PostalCode;
            return customerDto;


        }

        public static void ConvertToCustomerEntity(ref Customer customer, CustomerDto customerdto, bool isUpdate)
        {
            if (isUpdate)
                customer.CustomerId = customerdto.CustomerId;
            customer.Name = customerdto.Name;
            customer.AddressLine1 = customerdto.AddressLine1;
            customer.AddressLine2 = customerdto.AddressLine2;
            customer.City = customerdto.City;
            customer.District = customerdto.District;
            customer.MobileNumber = customerdto.MobileNumber;
            customer.HomePhone = customerdto.HomePhone;
            customer.State = customerdto.State;
            customer.PostalCode = customerdto.PostalCode;
            
            
        }
    }
}
