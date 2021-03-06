﻿using Platform.DTO;
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

       
      
        public IEnumerable<ProductOrderDTO> Get()
        {

            return _productOrderService.GetAllProductOrders();

        }


        [Route("api/ProductOrders/{id}")]
        public ProductOrderDTO Get(int id)
        {
            return _productOrderService.GetProductOrderById(id);
        }

      
      
        public IHttpActionResult Post([FromBody]ProductOrderDTO productOrderDTO)
        {
            if (productOrderDTO == null)
                return BadRequest("Argument Null");
      
            _productOrderService.AddProductOrder(productOrderDTO);

            return Ok();

        }

        //Put api/Customer/5
        [Route("api/ProductOrders/{id}")]
        public IHttpActionResult Put(int id, [FromBody]ProductOrderDTO productOrderDTO)
        {
            if (productOrderDTO == null)
                return BadRequest("Argument Null");
     
            _productOrderService.UpdateProductOrder(productOrderDTO);

            return Ok();
        }

        [Route("api/ProductOrders/id/{id}")]
        public void Delete(int id)
        {
        
            _productOrderService.DeleteProductOrder(id);
        }




    }
}
