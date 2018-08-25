using Platform.DTO;
using Platform.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public interface ICustomerWalletService
    {
         List<CustomerWalletDTO> GetAllCustomersWallet();

        CustomerWalletDTO GetCustomerWalletById(int customerId);

        void AddCustomerWallet(CustomerWalletDTO customerDto);

        void UpdateCustomerWallet(CustomerWalletDTO customerDto);

        void DeleteCustomerWallet(int id);

       






    }
}
