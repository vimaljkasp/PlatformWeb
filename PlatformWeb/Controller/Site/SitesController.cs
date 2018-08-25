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
    [Route("api/Sites")]
    public class SitesController : ApiController
    {

        private readonly ISiteService _siteService;

        public SitesController(ISiteService productSalesService)
        {
            _siteService = productSalesService;
        }



        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_siteService.GetAllSites());
            }
            catch (PlatformModuleException ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [Authorize]
        [Route("api/Sites/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(_siteService.GetSiteById(id));
            }
            catch (PlatformModuleException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Authorize]
        public IHttpActionResult Post([FromBody]SiteDTO siteDTO)
        {
            try
            {
                if (siteDTO == null)
                    return BadRequest("Argument Null");

                _siteService.AddSite(siteDTO);

                return Ok();
            }
            catch (PlatformModuleException ex)
            {
                //Write Log Here
                return BadRequest(ex.Message);
            }
        }


        [Authorize]
        [Route("api/Sites/{id}")]
        public IHttpActionResult Put(int id, [FromBody]SiteDTO siteDTO)
        {
            try
            {
                siteDTO.SiteId = id;
                if (siteDTO == null)
                    return BadRequest("Argument Null");

                _siteService.UpdateSite(siteDTO);

                return Ok();
            }
            catch (PlatformModuleException ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [Route("api/Sites/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {

                _siteService.DeleteSite(id);
                return Ok();
            }
            catch (PlatformModuleException ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
