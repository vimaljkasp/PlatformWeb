using Platform.Repository;
using Platform.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public class UnitOfWork : IDisposable
    {
        private  SiteRepository siteRepository;
        private SiteConfigurationRepository siteConfigurationRepository;
        private ProductRepository productRepository;
        private ProductOrderRepository productOrderRepository;
        private ProductOrderDtlRepository productOrderDtlRepository;
        
        private ModuleDashboardRepository moduleDashboardRepository;
        private ProductSalesRepository productSalesRepository;

        private CustomerRepository customerRepository;
        private CustomerWalletRepository customerWalletRepositoy;
        private CustomerPaymentRepository customerPaymentRepository;
        private CustomerSessionRepository customerSessionRepository;

        private ProductSiteMappingRepository productSiteMappingRepository;
        private DashboardRepository dashboardRepository;


        private EmployeeRepository employeeRepository;
        private EmployeeRoleRepository employeeRoleRepository;
        private EmployeeSessionRepository employeeSessionRepository;

        private ItemRepository itemRepository;
        PlatformDBEntities _repository;
        public UnitOfWork()
        {
            _repository= new PlatformDBEntities();
        }

        public SiteRepository SiteRepository
        {
            get
            {
                if (SiteRepository == null)
                    return siteRepository = new SiteRepository(_repository);
              
                else
                {
                    return siteRepository;
                }
            }

        }

        public SiteConfigurationRepository SiteConfigurationRepository
        {
            get
            {
                if (siteConfigurationRepository == null)
                    return siteConfigurationRepository = new SiteConfigurationRepository(_repository);
                else
                {
                    return siteConfigurationRepository;

                }
            }

        }

        public CustomerRepository CustomerRepository
        {
            get
            {
                if (customerRepository == null)
                    return customerRepository = new CustomerRepository(_repository);

                else
                {
                    return customerRepository;
                }
            }

        }

        public ProductRepository ProductRepository
        {
            get
            {
                if (productRepository == null)
                    return productRepository = new ProductRepository(_repository);
                else
                {
                    return productRepository;

                }
            }

        }

        public ProductSalesRepository ProductSalesRepository
        {
            get
            {
                if (productSalesRepository == null)
                    return productSalesRepository = new ProductSalesRepository(_repository);
                else
                {
                    return productSalesRepository;

                }
            }

        }

        public ProductOrderRepository ProductOrderRepository
        {
            get
            {
                if (productOrderRepository == null)
                    return productOrderRepository = new ProductOrderRepository(_repository);
                else
                {
                    return productOrderRepository;

                }
            }

        }

        public ProductOrderDtlRepository ProductOrderDtlRepository
        {
            get
            {
                if (productOrderDtlRepository == null)
                    return productOrderDtlRepository = new ProductOrderDtlRepository(_repository);

                else
                {
                    return productOrderDtlRepository;

                }
            }

        }


        public ModuleDashboardRepository ModuleDashboardRepository
        {
            get
            {
                if (moduleDashboardRepository == null)
                    return moduleDashboardRepository = new ModuleDashboardRepository(_repository);

                else
                {
                    return moduleDashboardRepository;

                }
            }

        }


        public CustomerWalletRepository CustomerWalletRepository
        {
            get
            {
                if (customerWalletRepositoy == null)
                    return customerWalletRepositoy = new CustomerWalletRepository(_repository);
                else
                    return customerWalletRepositoy;
            }
        }

        public CustomerPaymentRepository CustomerPaymentRepository
        {
            get
            {
                if (customerPaymentRepository == null)
                    return customerPaymentRepository = new CustomerPaymentRepository(_repository);
                else
                    return customerPaymentRepository;
            }
        }

        public CustomerSessionRepository CustomerSessionRepository
        {
            get
            {
                if (customerSessionRepository == null)
                    return customerSessionRepository = new CustomerSessionRepository(_repository);
                else
                    return customerSessionRepository;
            }
        }


        public ProductSiteMappingRepository ProductSiteMappingRepository
        {
            get
            {
                if (productSiteMappingRepository == null)
                    return productSiteMappingRepository = new ProductSiteMappingRepository(_repository);
                else
                    return productSiteMappingRepository;
            }
        }

        public EmployeeRoleRepository EmployeeRoleRepository
        {
            get
            {
                if (employeeRoleRepository == null)
                    return employeeRoleRepository = new EmployeeRoleRepository(_repository);
                else
                    return employeeRoleRepository;
            }
        }

        public EmployeeRepository EmployeeRepository
        {
            get
            {
                if (employeeRepository == null)
                    return employeeRepository = new EmployeeRepository(_repository);
                else
                    return employeeRepository;
            }
        }

        public EmployeeSessionRepository EmployeeSessionRepository
        {
            get
            {
                if (employeeSessionRepository == null)
                    return employeeSessionRepository = new EmployeeSessionRepository(_repository);
                else
                    return employeeSessionRepository;
            }
        }


        public DashboardRepository DashboardRepository
        {
            get
            {
                if (dashboardRepository == null)
                    return dashboardRepository = new DashboardRepository(_repository);
                else
                    return dashboardRepository;
            }
        }

        public ItemRepository ItemRepository
        {
            get
            {
                if (itemRepository == null)
                    return itemRepository = new ItemRepository(_repository);
                else
                    return itemRepository;
            }
        }

        //To save multiple repository and maintain consistency
        public void SaveChanges()
        {
            this._repository.SaveChanges();
        }


        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_repository != null)
                {
                    _repository.Dispose();
                    _repository = null;
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
