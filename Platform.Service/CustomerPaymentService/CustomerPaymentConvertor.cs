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

        public static CustomerPaymentDTO ConvertToCustomerPaymentDto(ProductOrder productOrder, List<CustomerPaymentTransaction> customerPayments)
        {
            //TODO : Vimal please verify this logic whether we are showing sum of all order amount or single at a time for payments. 
            // Means order payment can be done partially multiple time for single order or only one time ?
            decimal? totalCrAmountOfOrder = customerPayments.Sum(x => x.PaymentCrAmount);
            CustomerPaymentTransaction lastPaymentByCustomer = customerPayments.OrderByDescending(x => x.CustomerPaymentId).FirstOrDefault();

            CustomerPaymentDTO customerPaymentDTO = new CustomerPaymentDTO();

            customerPaymentDTO.CustomerId = productOrder.Customer.CustomerId;
            customerPaymentDTO.CustomerName = productOrder.Customer.Name;
            customerPaymentDTO.ProductName = productOrder.ProductOrderDetails.FirstOrDefault().ProductSiteMapping.Product.ProductName;
            customerPaymentDTO.OrderNumber = productOrder.OrderNumber;
            customerPaymentDTO.OrderId = productOrder.OrderId;
            customerPaymentDTO.PaidAmount = totalCrAmountOfOrder.Value;
            customerPaymentDTO.TotalAmount = productOrder.OrderTotalPrice.GetValueOrDefault();
            customerPaymentDTO.PaymentCrAmount = totalCrAmountOfOrder.Value;
            customerPaymentDTO.PaymentDate = lastPaymentByCustomer != null ? lastPaymentByCustomer.PaymentDate : DateTime.Now;
            PaymentMode modeOfPay = PaymentMode.Cash;
            if (lastPaymentByCustomer != null)
                Enum.TryParse(lastPaymentByCustomer.PaymentMode, out modeOfPay);
            customerPaymentDTO.PaymentMode = modeOfPay;
            customerPaymentDTO.PaymentReceivedBy = lastPaymentByCustomer != null ? lastPaymentByCustomer.PaymentReceivedBy : "NA";
            customerPaymentDTO.Ref2 = lastPaymentByCustomer != null ? lastPaymentByCustomer.Ref2 : "NA";
            customerPaymentDTO.CustomerPaymentId = lastPaymentByCustomer != null ? lastPaymentByCustomer.CustomerPaymentId : 0;
            customerPaymentDTO.PaymentComments = lastPaymentByCustomer != null ? lastPaymentByCustomer.Ref1 : "No Comments mentioned";
            customerPaymentDTO.OrderStatus = productOrder.ProductOrderDetails.FirstOrDefault().OrderStatus.ToString();
            return customerPaymentDTO;



        }


        public static void ConvertToCustomerPaymentEntity(ref CustomerPaymentTransaction customerPaymentTransaction, CustomerPaymentDTO customerPaymentDTO, bool isUpdate)
        {
            if (isUpdate)
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
