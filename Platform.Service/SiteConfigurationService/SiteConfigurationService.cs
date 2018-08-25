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
    public class SiteConfigurationService : ISiteConfigurationService, IDisposable
    {
        private UnitOfWork unitOfWork;

            public SiteConfigurationService()
            {
                unitOfWork = new UnitOfWork();
            }

            public List<SiteConfigurationDTO> GetAllSiteConfigurations()
            {
                List<SiteConfigurationDTO> siteConfgurationList = new List<SiteConfigurationDTO>();
                var siteConfigurations = unitOfWork.SiteConfigurationRepository.GetAll();
                if (siteConfigurations != null)
                {
                    foreach (var siteConfiguration in siteConfigurations)
                    {
                    siteConfgurationList.Add(SiteConfigurationConvertor.ConvertToSiteConfigurationDto(siteConfiguration));
                    }

                }

                return siteConfgurationList;

            }


            public SiteConfigurationDTO GetSiteConfigurationById(int siteConfigurationId)
            {
            SiteConfigurationDTO siteConfigurationDTO = null;
                var siteConfiguration = unitOfWork.SiteConfigurationRepository.GetById(siteConfigurationId);
                if (siteConfiguration != null)
                {
                siteConfigurationDTO = SiteConfigurationConvertor.ConvertToSiteConfigurationDto(siteConfiguration);
                }
                return siteConfigurationDTO;
            }

       

        



            public void AddSiteConfiguration(SiteConfigurationDTO siteConfigurationDTO)
            {
                SiteConfiguration siteConfiguration = new SiteConfiguration();

                SiteConfigurationConvertor.ConvertToSiteConfigurationEntity(ref siteConfiguration, siteConfigurationDTO, false);
                UnitOfWork unitOfWork = new UnitOfWork();
                unitOfWork.SiteConfigurationRepository.Add(siteConfiguration);
                unitOfWork.SaveChanges();


            }


            public void UpdateSiteConfiguration(SiteConfigurationDTO siteConfigurationDTO)
            {
                SiteConfiguration siteConfiguration = new SiteConfiguration();
            SiteConfigurationConvertor.ConvertToSiteConfigurationEntity(ref siteConfiguration, siteConfigurationDTO, true);
                UnitOfWork unitOfWork = new UnitOfWork();
                unitOfWork.SiteConfigurationRepository.Update(siteConfiguration);
                unitOfWork.SaveChanges();
            }

            public void DeleteSiteConfiguration(int id)
            {
                UnitOfWork unitOfWork = new UnitOfWork();
                unitOfWork.SiteConfigurationRepository.Delete(id);
                unitOfWork.SaveChanges();

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



