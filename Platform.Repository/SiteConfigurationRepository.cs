using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Platform.Sql;

namespace Platform.Repository
{
    public class SiteConfigurationRepository
    {

        PlatformDBEntities _repository;
        public SiteConfigurationRepository(PlatformDBEntities repository)
        {
            _repository = repository;
        }
        public List<SiteConfiguration> GetAll()
        {

            List<SiteConfiguration> siteConfigurationList = new List<SiteConfiguration>();
            siteConfigurationList = _repository.SiteConfigurations.ToList<Sql.SiteConfiguration>();


            return siteConfigurationList;
        }

        public SiteConfiguration GetById(int siteConfigurationId)
        {
            SiteConfiguration siteConfiguration = new SiteConfiguration();

            siteConfiguration = _repository.SiteConfigurations.FirstOrDefault(x => x.Id == siteConfigurationId);



            return siteConfiguration;
        }

        public string GetSiteConfigurationByKeyTypeAndKeyName(string keyData, string KeyName, string DefaultVal)
        {
          var  siteConfiguration = _repository.SiteConfigurations.FirstOrDefault(x => x.KeyData == keyData && x.KeyName==KeyName);
            if (siteConfiguration == null)
                return DefaultVal;
            else
                return siteConfiguration.DataVal;

        }


        public void Add(SiteConfiguration siteConfiguration)
        {




            if (siteConfiguration != null)
            {
                _repository.SiteConfigurations.Add(siteConfiguration);
             //   _repository.SaveChanges();

            }




        }

        public void Update(SiteConfiguration siteConfiguration)
        {

            if (siteConfiguration != null)
            {
                _repository.Entry<Sql.SiteConfiguration>(siteConfiguration).State = System.Data.Entity.EntityState.Modified;
             //   _repository.SaveChanges();

            }


        }

        public void Delete(int siteConfigurationId)
        {
            var site = _repository.SiteConfigurations.Where(x => x.Id == siteConfigurationId).FirstOrDefault();
            if (site != null)
                _repository.SiteConfigurations.Remove(site);

           // _repository.SaveChanges();

        }

        


    }
}
