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
            customerPaymentDTO.PaymentMode = customerPaymentTransaction.Ref2;
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
            customerPaymentTransaction.Ref2 = customerPaymentDTO.PaymentMode;
          


        }
    }
}
