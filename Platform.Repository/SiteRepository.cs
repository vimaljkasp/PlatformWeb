using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Platform.Sql;

namespace Platform.Repository
{
    public class SiteRepository 
    {

        PlatformDBEntities _repository;
        public SiteRepository(PlatformDBEntities repository)
        {
            _repository = repository;
        }
        public List<Site> GetAll()
        {

            List<Site> siteList = new List<Site>();
             siteList = _repository.Sites.ToList<Sql.Site>();


            return siteList;
        }

        public Site GetById(int siteId)
        {
            Site site = new Site();

             site = _repository.Sites.FirstOrDefault(x => x.SiteId == siteId);



            return site;
        }


        public void Add(Site site)
        {
            if (site != null)
            {
                _repository.Sites.Add(site);
               

            }
        }

        public void Update(Site site)
        {
          
                if (site != null)
                {
                    _repository.Entry<Sql.Site>(site).State = System.Data.Entity.EntityState.Modified;
                    

                }


        }

        public void Delete(int siteId)
        {
            var site = _repository.Sites.Where(x => x.SiteId == siteId).FirstOrDefault();
            if (site != null)
                _repository.Sites.Remove(site);

         

        }

   


    }
}
