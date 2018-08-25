using Platform.DTO;
using Platform.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public class SiteConfigurationConvertor
    {
        public static SiteConfigurationDTO ConvertToSiteConfigurationDto(SiteConfiguration siteConfiguration)
        {
            SiteConfigurationDTO siteConfigurationDTO = new SiteConfigurationDTO();
            siteConfigurationDTO.Id = siteConfiguration.Id;
            siteConfigurationDTO.KeyData = siteConfiguration.KeyData;
            siteConfigurationDTO.KeyName = siteConfiguration.KeyName;
            siteConfigurationDTO.DataVal = siteConfiguration.DataVal;
            siteConfigurationDTO.DefaultVal = siteConfiguration.DefaultVal;
            siteConfigurationDTO.Description = siteConfiguration.Description;

            return siteConfigurationDTO;


        }

        public static void ConvertToSiteConfigurationEntity(ref SiteConfiguration siteConfiguration, SiteConfigurationDTO siteConfigurationDTO, bool isUpdate)
        {
            if (isUpdate)
                siteConfiguration.Id = siteConfigurationDTO.Id;
            siteConfiguration.KeyData = siteConfigurationDTO.KeyData;
            siteConfiguration.KeyName = siteConfigurationDTO.KeyName;
            siteConfiguration.DataVal = siteConfigurationDTO.DataVal;
            siteConfiguration.DefaultVal = siteConfigurationDTO.DefaultVal;
            siteConfiguration.Description = siteConfigurationDTO.Description;


        }
    }
}
