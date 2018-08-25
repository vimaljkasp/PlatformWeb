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
    [Route("api/Products")]
    public class ProductsController : ApiController
    {

        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }



        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_productService.GetAllProducts());
            }
            catch (PlatformModuleException ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [Authorize]
        [Route("api/Products/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(_productService.GetProductById(id));
            }
            catch (PlatformModuleException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Authorize]
        public IHttpActionResult Post([FromBody]ProductDTO productDTO)
        {
            try
            {
                if (productDTO == null)
                    return BadRequest("Argument Null");

                _productService.AddProduct(productDTO);

                return Ok();
            }
            catch (PlatformModuleException ex)
            {
                //Write Log Here
                return BadRequest(ex.Message);
            }
        }


        [Authorize]
        [Route("api/Products/{id}")]
        public IHttpActionResult Put(int id, [FromBody]ProductDTO productDTO)
        {
            try
            {
                productDTO.ProductId = id;
                if (productDTO == null)
                    return BadRequest("Argument Null");

                _productService.UpdateProduct(productDTO);

                return Ok();
            }
            catch (PlatformModuleException ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [Route("api/Products/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {

                _productService.DeleteProduct(id);
                return Ok();
            }
            catch (PlatformModuleException ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
