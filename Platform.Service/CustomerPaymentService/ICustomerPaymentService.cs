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
         List<CustomerPaymentDTO> GetAllCustomerOrders();

        CustomerPaymentDTO GetCustomerPaymentById(int customerId);

        decimal? GetDuePaymentByOrderId(int orderId);
        
        void AddCustomerPayment(CustomerPaymentDTO customerPaymentDTO);

        void UpdateCustomerPayment(CustomerPaymentDTO customerPaymentDTO);

        void DeleteCustomerPayemt(int id);






    }
}
