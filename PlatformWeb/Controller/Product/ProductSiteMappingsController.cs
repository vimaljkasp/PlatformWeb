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
    [Route("api/ProductSiteMappings")]
    public class ProductSiteMappingsController : ApiController
    {

        private readonly IProductSiteMappingService _productSiteMappingService;

        public ProductSiteMappingsController(IProductSiteMappingService productSiteMappingService)
        {
            _productSiteMappingService = productSiteMappingService;
        }



        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_productSiteMappingService.GetAllProductSiteMapping());
            }
            catch (PlatformModuleException ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [Authorize]
        [Route("api/ProductSiteMappings/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(_productSiteMappingService.GetProductSiteMappinById(id));
            }
            catch (PlatformModuleException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Authorize]
        public IHttpActionResult Post([FromBody]ProductSiteMappingDTO productSiteMappingDTO)
        {
            try
            {
                if (productSiteMappingDTO == null)
                    return BadRequest("Argument Null");

                _productSiteMappingService.AddProductSiteMapping(productSiteMappingDTO);

                return Ok();
            }
            catch (PlatformModuleException ex)
            {
                //Write Log Here
                return BadRequest(ex.Message);
            }
        }


        [Authorize]
        [Route("api/ProductSiteMappings/{id}")]
        public IHttpActionResult Put(int id, [FromBody]ProductSiteMappingDTO productSiteMappingDTO)
        {
            try
            {
                productSiteMappingDTO.ProductMappingId = id;
                if (productSiteMappingDTO == null)
                    return BadRequest("Argument Null");

                _productSiteMappingService.UpdateProductSiteMapping(productSiteMappingDTO);

                return Ok();
            }
            catch (PlatformModuleException ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [Route("api/ProductSiteMappings/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {

                _productSiteMappingService.DeleteProductSiteMapping(id);
                return Ok();
            }
            catch (PlatformModuleException ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
