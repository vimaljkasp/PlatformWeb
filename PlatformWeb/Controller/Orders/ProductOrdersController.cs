using Platform.DTO;
using Platform.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace PlatformWeb.Controller
{
    [Route("api/ProductOrders")]
    public class ProductOrdersController : ApiController
    {

        private readonly IProductOrderService _productOrderService;

        public ProductOrdersController(IProductOrderService productOrderService)
        {
            _productOrderService = productOrderService;
        }

       
      
        public IEnumerable<ProductOrders> Get()
        {

            return _productOrderService.GetAllProductOrders();

        }


   
        public ProductOrderDTO Get(int productOrderId)
        {
            return _productOrderService.GetProductOrderById(productOrderId);
        }

      
      
        public IHttpActionResult Post([FromBody]ProductOrderDTO productOrderDTO)
        {
            if (productOrderDTO == null)
                return BadRequest("Argument Null");
      
            _productOrderService.AddProductOrder(productOrderDTO);

            return Ok();

        }

        //Put api/Customer/5
        public IHttpActionResult Put(int customerid, [FromBody]ProductOrderDTO productOrderDTO)
        {
            if (productOrderDTO == null)
                return BadRequest("Argument Null");
     
            _productOrderService.UpdateProductOrder(productOrderDTO);

            return Ok();
        }

        public void Delete(int id)
        {
        
            _productOrderService.DeleteProductOrder(id);
        }




    }
}
