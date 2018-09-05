using Platform.DTO;
using Platform.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public class CustomerPaymentConvertor
    {
        public static CustomerPaymentDTO ConvertToCustomerPaymentDto(CustomerPaymentTransaction customerPaymentTransaction)
        {
            CustomerPaymentDTO customerPaymentDTO = new CustomerPaymentDTO();
            customerPaymentDTO.CustomerPaymentId = customerPaymentTransaction.CustomerPaymentId;
            customerPaymentDTO.CustomerId = customerPaymentTransaction.CustomerId;
            customerPaymentDTO.OrderId = customerPaymentTransaction.OrderId;
            customerPaymentDTO.PaymentCrAmount = customerPaymentTransaction.PaymentCrAmount.GetValueOrDefault();
            customerPaymentDTO.PaymentDrAmount = customerPaymentTransaction.PaymentDrAmount.GetValueOrDefault();
            customerPaymentDTO.PaymentDate = customerPaymentTransaction.PaymentDate;
            customerPaymentDTO.PaymentReceivedBy = customerPaymentTransaction.PaymentReceivedBy;
            customerPaymentDTO.PaymentComments = customerPaymentTransaction.Ref1;
            customerPaymentDTO.PaymentMode = (PaymentMode)Enum.Parse(typeof(PaymentMode), customerPaymentTransaction.PaymentMode);
            return customerPaymentDTO;




    }

        public static CustomerPaymentDTO ConvertToCustomerPaymentDto(ProductOrder productOrder)
        {
            CustomerPaymentDTO customerPaymentDTO = new CustomerPaymentDTO();
          
            customerPaymentDTO.CustomerId = productOrder.Customer.CustomerId;
            customerPaymentDTO.CustomerName = productOrder.Customer.Name;
            customerPaymentDTO.ProductName = productOrder.ProductOrderDetails.FirstOrDefault().ProductSiteMapping.Product.ProductName;
            customerPaymentDTO.OrderNumber = productOrder.OrderNumber;
            customerPaymentDTO.OrderId = productOrder.OrderId;
            customerPaymentDTO.PaidAmount = productOrder.OrderPaidAmount.GetValueOrDefault();
            customerPaymentDTO.TotalAmount = productOrder.OrderTotalPrice.GetValueOrDefault();

            return customerPaymentDTO;

        

        }
     

        public static void ConvertToCustomerPaymentEntity(ref CustomerPaymentTransaction customerPaymentTransaction, CustomerPaymentDTO customerPaymentDTO, bool isUpdate)
        {
            if(isUpdate)
            customerPaymentTransaction.CustomerPaymentId = customerPaymentDTO.CustomerPaymentId;

            customerPaymentTransaction.CustomerId = customerPaymentDTO.CustomerId;
            customerPaymentTransaction.OrderId = customerPaymentDTO.OrderId;
            customerPaymentTransaction.PaymentCrAmount = customerPaymentDTO.PaymentCrAmount;
            customerPaymentTransaction.PaymentDrAmount = customerPaymentDTO.PaymentDrAmount;
            customerPaymentTransaction.PaymentDate = customerPaymentDTO.PaymentDate;
            customerPaymentTransaction.PaymentReceivedBy = customerPaymentDTO.PaymentReceivedBy;
            customerPaymentTransaction.Ref1 = customerPaymentDTO.PaymentComments;
            customerPaymentTransaction.PaymentMode = customerPaymentDTO.PaymentMode.ToString();
          


        }
    }
}
