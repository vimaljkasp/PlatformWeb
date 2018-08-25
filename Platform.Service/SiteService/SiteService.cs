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
    public class SiteService : ISiteService,IDisposable
    {
        private  UnitOfWork unitOfWork=new UnitOfWork();


            public List<SiteDTO> GetAllSites()
            {
                List<SiteDTO> siteList = new List<SiteDTO>();
                var sites = unitOfWork.SiteRepository.GetAll();
                if (sites != null)
                {
                    foreach (var site in sites)
                    {
                    siteList.Add(SiteConvertor.ConvertToSiteDTO(site));
                    }

                }

                return siteList;

            }


            public SiteDTO GetSiteById(int siteId)
            {
            SiteDTO siteDTO = null;
                var site = unitOfWork.SiteRepository.GetById(siteId);
                if (site != null)
                {
                siteDTO = SiteConvertor.ConvertToSiteDTO(site);
                }
                return siteDTO;
            }



            public void AddSite(SiteDTO siteDTO)
            {
               Site site = new Site();

                SiteConvertor.ConvertToSiteEntity(ref site, siteDTO, false);
                UnitOfWork unitOfWork = new UnitOfWork();
                unitOfWork.SiteRepository.Add(site);
                unitOfWork.SaveChanges();


            }
        

            public void UpdateSite(SiteDTO siteDTO)
            {
                Site site = new Site();
                SiteConvertor.ConvertToSiteEntity(ref site, siteDTO, true);
                UnitOfWork unitOfWork = new UnitOfWork();
                unitOfWork.SiteRepository.Update(site);
                unitOfWork.SaveChanges();
            }

            public void DeleteSite(int id)
        { 
                UnitOfWork unitOfWork = new UnitOfWork();
                unitOfWork.SiteRepository.Delete(id);
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

