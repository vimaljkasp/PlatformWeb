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
    [Route("api/CustomerPayments")]
    public class CustomerPaymentsController : ApiController
    {

        private readonly ICustomerPaymentService _customerPaymentService;

        public CustomerPaymentsController(ICustomerPaymentService customerPaymentService)
        {
            _customerPaymentService = customerPaymentService;
        }



        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_customerPaymentService.GetAllCustomerPayments());
            }
            catch (PlatformModuleException ex)
            {
                return BadRequest(ex.Message);
            }

        }


      //  [Authorize]
        [Route("api/CustomerPayments/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(_customerPaymentService.GetCustomerPaymentById(id));
            }
            catch (PlatformModuleException ex)
            {
                return BadRequest(ex.Message);
            }
        }


     //   [Authorize]
        public IHttpActionResult Post([FromBody]CustomerPaymentDTO customerPaymentDTO)
        {
            try
            {
                if (customerPaymentDTO == null)
                    return BadRequest("Argument Null");

                _customerPaymentService.AddCustomerPayment(customerPaymentDTO);

                return Ok();
            }
            catch (PlatformModuleException ex)
            {
                //Write Log Here
                return BadRequest(ex.Message);
            }
        }


    //    [Authorize]
        [Route("api/CustomerPayments/{id}")]
        public IHttpActionResult Put(int id, [FromBody]CustomerPaymentDTO customerPaymentDTO)
        {
            try
            {
                customerPaymentDTO.CustomerPaymentId = id;
                if (customerPaymentDTO == null)
                    return BadRequest("Argument Null");

                _customerPaymentService.UpdateCustomerPayment(customerPaymentDTO);

                return Ok();
            }
            catch (PlatformModuleException ex)
            {

                return BadRequest(ex.Message);
            }
        }

   //     [Authorize]
        [Route("api/CustomerPayments/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {

                _customerPaymentService.DeleteCustomerPayemt(id);
                return Ok();
            }
            catch (PlatformModuleException ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
