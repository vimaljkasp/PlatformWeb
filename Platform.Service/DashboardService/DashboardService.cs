
using Platform.DTO;

using Platform.Repository;
using Platform.Service;
using Platform.Sql;
using Platform.Utilities.Encryption;
using Platform.Utilities.ExceptionHandler;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public class DashboardService : IDashboardService,IDisposable
    {
        private UnitOfWork unitOfWork=new UnitOfWork(); 
        

        public DashboardDTO GetDashboardDetails()
        {
            DateTime saleDate = DateTime.Now.Date;
            DashboardDTO dashboardDTO = unitOfWork.DashboardRepository.GetDashBoardDetails(saleDate);
           
            return dashboardDTO;
        }

        public List<ProductOrders> GetProductOrders()
        {
            
           return unitOfWork.DashboardRepository.GetProductOrders();

          
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
