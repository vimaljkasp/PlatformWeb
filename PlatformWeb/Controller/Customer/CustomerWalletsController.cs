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
    [Route("api/CustomerWallets")]
    public class CustomerWalletsController : ApiController
    {

        private readonly ICustomerWalletService _customerWalletService;

        public CustomerWalletsController(ICustomerWalletService customerWalletService)
        {
            _customerWalletService = customerWalletService;
        }



        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_customerWalletService.GetAllCustomersWallet());
            }
            catch (PlatformModuleException ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [Authorize]
        [Route("api/CustomerWallets/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(_customerWalletService.GetCustomerWalletById(id));
            }
            catch (PlatformModuleException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Authorize]
        public IHttpActionResult Post([FromBody]CustomerWalletDTO customerWalletDTO)
        {
            try
            {
                if (customerWalletDTO == null)
                    return BadRequest("Argument Null");

                _customerWalletService.AddCustomerWallet(customerWalletDTO);

                return Ok();
            }
            catch (PlatformModuleException ex)
            {
                //Write Log Here
                return BadRequest(ex.Message);
            }
        }


        [Authorize]
        [Route("api/CustomerWallets/{id}")]
        public IHttpActionResult Put(int id, [FromBody]CustomerWalletDTO customerWalletDTO)
        {
            try
            {
                customerWalletDTO.WalletId = id;
                if (customerWalletDTO == null)
                    return BadRequest("Argument Null");

                _customerWalletService.UpdateCustomerWallet(customerWalletDTO);

                return Ok();
            }
            catch (PlatformModuleException ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [Route("api/CustomerWallets/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {

                _customerWalletService.DeleteCustomerWallet(id);
                return Ok();
            }
            catch (PlatformModuleException ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
