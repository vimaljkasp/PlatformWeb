using Platform.DTO;
using Platform.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public class CustomerWalletConvertor
    {
        public static CustomerWalletDTO ConvertToCustomerWalletDto(CustomerWallet customerWallet)
        {
            CustomerWalletDTO customerWalletDTO = new CustomerWalletDTO();
            customerWalletDTO.WalletId = customerWallet.WalletId;
            customerWalletDTO.CustomerId = customerWallet.CustomerId;
            customerWalletDTO.WalletBalance = customerWallet.WalletBalance;
            customerWalletDTO.AmountDueDate = customerWallet.AmountDueDate;
            return customerWalletDTO;

    }

        public static void ConvertToCustomerWalletEntity(ref CustomerWallet customerWallet, CustomerWalletDTO customerWalletDTO, bool isUpdate)
        {
            if(isUpdate)
                customerWallet.WalletId = customerWalletDTO.WalletId;
            customerWallet.CustomerId = customerWalletDTO.CustomerId;
            customerWallet.WalletBalance = customerWalletDTO.WalletBalance;
            customerWallet.AmountDueDate = customerWalletDTO.AmountDueDate;


        }
    }
}
