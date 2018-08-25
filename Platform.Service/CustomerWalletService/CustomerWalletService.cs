using Platform.DTO;
using Platform.Repository;
using Platform.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public class CustomerWalletService : ICustomerWalletService,IDisposable
    {

        private UnitOfWork unitOfWork=new UnitOfWork();

       

        public void AddCustomerWallet(CustomerWalletDTO customerWalletDTO)
        {
            CustomerWallet customerWallet = new CustomerWallet();
            CustomerWalletConvertor.ConvertToCustomerWalletEntity(ref customerWallet, customerWalletDTO, false);
            unitOfWork.CustomerWalletRepository.Add(customerWallet);
        }

        public void DeleteCustomerWallet(int id)
        {
            throw new NotImplementedException();
        }

        public List<CustomerWalletDTO> GetAllCustomersWallet()
        {
            throw new NotImplementedException();
        }

        public CustomerWalletDTO GetCustomerWalletById(int customerId)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomerWallet(CustomerWalletDTO customerDto)
        {
            throw new NotImplementedException();
        }


       public  CustomerWalletRepository AddOrUpdateCustomerWallet(int customerId, double balance)
        {
            //check if customer wallet already exist;
            var customerWallet = unitOfWork.CustomerWalletRepository.GetByCustomerId(customerId);
            if(customerWallet!=null)
            {
                customerWallet.WalletBalance += (long)balance * 100;
                unitOfWork.CustomerWalletRepository.Update(customerWallet);
            }
            else
            {
                 customerWallet = new CustomerWallet();
                customerWallet.CustomerId = customerId;
                customerWallet.WalletBalance= (long)balance * 100;
                customerWallet.AmountDueDate = DateTime.Now.AddDays(10);
                unitOfWork.CustomerWalletRepository.Add(customerWallet);
            }

            return unitOfWork.CustomerWalletRepository;
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
