using Platform.DTO;
using Platform.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public class SiteConvertor
    {
        public static SiteDTO ConvertToSiteDTO(Site site)
        {
            SiteDTO siteDTO = new SiteDTO();
            siteDTO.SiteId = site.SiteId;
            siteDTO.SiteAddress = site.SiteAddress;
            siteDTO.SiteCode = site.SiteCode;
            siteDTO.SiteName = site.SiteName;
            siteDTO.SiteCity = site.SiteCity;
            siteDTO.SiteMobileNumber = site.SiteMobileNumber;
            siteDTO.SiteState = site.SiteState;
            siteDTO.SiteZipCode = site.SiteZipCode;
            siteDTO.IsActive = site.IsActive;
            
            return siteDTO;


        }

        public static void ConvertToSiteEntity(ref Site site, SiteDTO siteDTO, bool isUpdate)
        {
            if (isUpdate)
                site.SiteId = siteDTO.SiteId;
            site.SiteAddress = siteDTO.SiteAddress;
            site.SiteCode = siteDTO.SiteCode;
            site.SiteName = siteDTO.SiteName;
            site.SiteCity = siteDTO.SiteCity;
            site.SiteMobileNumber = siteDTO.SiteMobileNumber;
            site.SiteState = siteDTO.SiteState;
            site.SiteZipCode = siteDTO.SiteZipCode;
            site.IsActive = siteDTO.IsActive;


        }
    }
}
