using Platform.DTO;
using Platform.Service;
using Platform.Utilities.ExceptionHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace PlatformWeb.Controller
{
    [Route("api/SiteConfigurations")]
    public class SiteConfigurationsController : ApiController
    {

        private readonly ISiteConfigurationService _siteConfigurationService;

        public SiteConfigurationsController(ISiteConfigurationService siteConfigurationService)
        {
            _siteConfigurationService = siteConfigurationService;
        }



        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_siteConfigurationService.GetAllSiteConfigurations());
            }
            catch (PlatformModuleException ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [Authorize]
        [Route("api/SiteConfigurations/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(_siteConfigurationService.GetSiteConfigurationById(id));
            }
            catch (PlatformModuleException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Authorize]
        public IHttpActionResult Post([FromBody]SiteConfigurationDTO siteConfigurationDTO)
        {
            try
            {
                if (siteConfigurationDTO == null)
                    return BadRequest("Argument Null");

                _siteConfigurationService.AddSiteConfiguration(siteConfigurationDTO);

                return Ok();
            }
            catch (PlatformModuleException ex)
            {
                //Write Log Here
                return BadRequest(ex.Message);
            }
        }


        [Authorize]
        [Route("api/SiteConfigurations/{id}")]
        public IHttpActionResult Put(int id, [FromBody]SiteConfigurationDTO siteConfigurationDTO)
        {
            try
            {
                siteConfigurationDTO.Id = id;
                if (siteConfigurationDTO == null)
                    return BadRequest("Argument Null");

                _siteConfigurationService.UpdateSiteConfiguration(siteConfigurationDTO);

                return Ok();
            }
            catch (PlatformModuleException ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [Route("api/SiteConfigurations/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {

                _siteConfigurationService.DeleteSiteConfiguration(id);
                return Ok();
            }
            catch (PlatformModuleException ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
