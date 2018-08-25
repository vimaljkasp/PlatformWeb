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
    [Route("api/Dashboard")]
    public class DashboardController : ApiController
    {

        private readonly IDashboardService _dashBoardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashBoardService = dashboardService;
        }

        // GET api/Customer

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_dashBoardService.GetDashboardDetails());
            }
            catch (PlatformModuleException ex)
            {
                return BadRequest(ex.Message);
            }

        }


        
    }
}
