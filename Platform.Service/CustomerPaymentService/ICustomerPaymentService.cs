using Platform.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public interface ICustomerPaymentService
    {
         List<CustomerPaymentDTO> GetAllCustomerPayments();

        CustomerPaymentDTO GetCustomerPaymentById(int customerId);

        void AddCustomerPayment(CustomerPaymentDTO customerPaymentDTO);

        void UpdateCustomerPayment(CustomerPaymentDTO customerPaymentDTO);

        void DeleteCustomerPayemt(int id);






    }
}
