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
    [Route("api/ProductSales")]
    public class ProductSalesController : ApiController
    {

        private readonly IProductSalesService _productSalesService;

        public ProductSalesController(IProductSalesService productSalesService)
        {
            _productSalesService = productSalesService;
        }

   

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_productSalesService.GetAllProductSales());
            }
            catch (PlatformModuleException ex)
            {
                return BadRequest(ex.Message);
            }

        }


         [Authorize]
        [Route("api/ProductSales/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(_productSalesService.GetProductSalesById(id));
            }
            catch (PlatformModuleException ex)
            {
                return BadRequest(ex.Message);
            }
        }

       
        [Authorize]
        public IHttpActionResult Post([FromBody]ProductSalesDTO productSalesDTO)
        {
            try
            {
                if (productSalesDTO == null)
                    return BadRequest("Argument Null");
            
                _productSalesService.AddProductSales(productSalesDTO);

                return Ok();
            }
            catch (PlatformModuleException ex)
            {
                //Write Log Here
                return BadRequest(ex.Message);
            }
        }

        
        [Authorize]
        [Route("api/ProductSales/{id}")]
        public IHttpActionResult Put(int id, [FromBody]ProductSalesDTO productSalesDTO)
        {
            try
            {
                productSalesDTO.SalesId = id;
                if (productSalesDTO == null)
                    return BadRequest("Argument Null");

                _productSalesService.UpdateProductSales(productSalesDTO);

                return Ok();
            }
            catch (PlatformModuleException ex)
            {
             
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [Route("api/ProductSales/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {

                _productSalesService.DeleteProductSales(id);
                return Ok();
            }
            catch (PlatformModuleException ex)
            {
           
                return BadRequest(ex.Message);
            }
        }

        [Route("api/ProductSales/")]
        public IHttpActionResult Get([FromUri] string saleDate)
        {
            try
            {

                _productSalesService.GetProductSalesById(1);
                return Ok();
            }
            catch (PlatformModuleException ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Route("api/ProductSales/")]
        public IHttpActionResult Get([FromUri] string fromSale,[FromUri] string toSale)
        {
            try
            {

                _productSalesService.GetProductSalesById(1);
                return Ok();
            }
            catch (PlatformModuleException ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
