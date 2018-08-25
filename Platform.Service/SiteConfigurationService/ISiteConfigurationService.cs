using Platform.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public interface ISiteConfigurationService
    {
         List<SiteConfigurationDTO> GetAllSiteConfigurations();

        SiteConfigurationDTO GetSiteConfigurationById(int siteConfigurationId);

        void AddSiteConfiguration(SiteConfigurationDTO siteConfigurationDTO);

        void UpdateSiteConfiguration(SiteConfigurationDTO siteConfigurationDTO);

        void DeleteSiteConfiguration(int siteConfigurationId);

      



    }
}
