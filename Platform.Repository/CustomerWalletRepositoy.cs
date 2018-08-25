using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Platform.Sql;

namespace Platform.Repository
{
    public class CustomerWalletRepository
    {


        PlatformDBEntities _repository;
        public CustomerWalletRepository(PlatformDBEntities repository)
        {
            _repository = repository;
        }
        public List<CustomerWallet> GetAll()
        {

            List<CustomerWallet> siteList = new List<CustomerWallet>();
            siteList = _repository.CustomerWallets.ToList<Sql.CustomerWallet>();


            return siteList;
        }

        public CustomerWallet GetById(int customerWalletId)
        {
            CustomerWallet customerWallet = new CustomerWallet();

            customerWallet = _repository.CustomerWallets.FirstOrDefault(x => x.WalletId == customerWalletId);



            return customerWallet;
        }


        public CustomerWallet GetByCustomerId(int customerId)
        {
          return _repository.CustomerWallets.FirstOrDefault(x => x.CustomerId == customerId);
        }


        public void Add(CustomerWallet customerWallet)
        {

            if (customerWallet != null)
            {
                _repository.CustomerWallets.Add(customerWallet);
            //    _repository.SaveChanges();

            }




        }

        public void Update(CustomerWallet customerPaymentTransaction)
        {

            if (customerPaymentTransaction != null)
            {
                _repository.Entry<Sql.CustomerWallet>(customerPaymentTransaction).State = System.Data.Entity.EntityState.Modified;
             //   _repository.SaveChanges();

            }


        }

        public void Delete(int customerWallerId)
        {
            var customerWallet = _repository.CustomerWallets.Where(x => x.WalletId == customerWallerId).FirstOrDefault();
            if (customerWallet != null)
                _repository.CustomerWallets.Remove(customerWallet);

            _repository.SaveChanges();

        }

      


    }
}
