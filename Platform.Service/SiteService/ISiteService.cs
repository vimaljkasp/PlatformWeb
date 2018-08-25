using Platform.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public interface ISiteService
    {
         List<SiteDTO> GetAllSites();

        SiteDTO GetSiteById(int siteId);

        void AddSite(SiteDTO customerDto);

        void UpdateSite(SiteDTO customerDto);

        void DeleteSite(int siteId);






    }
}
