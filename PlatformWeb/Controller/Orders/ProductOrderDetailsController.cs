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
    [Route("api/ProductOrderDetails")]
    public class ProductOrderDetailsController : ApiController
    {

        private readonly IProductOrderDtlService _productOrderDtlService;

        public ProductOrderDetailsController(IProductOrderDtlService productOrderDtlService)
        {
            _productOrderDtlService = productOrderDtlService;
        }



        public IEnumerable<ProductOrderDtlDTO> Get()
        {

            return _productOrderDtlService.GetAllProductOrderDtl();

        }



        public ProductOrderDtlDTO Get(int id)
        {
            return _productOrderDtlService.GetProductOrderDtlById(id);
        }



        //public IHttpActionResult Post([FromBody]ProductOrderDTO productOrderDTO)
        //{
        //    if (_productOrderDtlService == null)
        //        return BadRequest("Argument Null");

        //    _productOrderDtlService.AddProductOrder(productOrderDTO);

        //    return Ok();

        //}

        //Put api/Customer/5
        [Route("api/ProductOrderDetails/{id}")]
        public IHttpActionResult Put(int id, [FromBody]ProductOrderDtlDTO productOrderDtlDTO)
        {
            if (productOrderDtlDTO == null)
                return BadRequest("Argument Null");
            productOrderDtlDTO.ProductOrderDetailId = id;

            _productOrderDtlService.UpdateProductOrderDtl(productOrderDtlDTO);

            return Ok();
        }

        public void Delete(int id)
        {

            _productOrderDtlService.DeleteProductOrderDtl(id);
        }




    }
}
