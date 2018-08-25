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
    [Route("api/Employees")]
    public class EmployeesController : ApiController
    {

        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET api/Customer

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_employeeService.GetAllEmployees());
            }
            catch (PlatformModuleException ex)
            {
                return BadRequest(ex.Message);
            }

        }


        //GET api/Customer/id
        [Route("api/Employees/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(_employeeService.GetEmployeeById(id));
            }
            catch (PlatformModuleException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Post api/Customer

        public IHttpActionResult Post([FromBody]EmployeeDTO employeeDTO)
        {
            try
            {
                if (employeeDTO == null)
                    return BadRequest("Argument Null");
            
                _employeeService.AddEmployee(employeeDTO);

                return Ok();
            }
            catch (PlatformModuleException ex)
            {
                //Write Log Here
                return BadRequest(ex.Message);
            }
        }

        [Route("api/Employees/{id}")]
        public IHttpActionResult Put(int id, [FromBody]EmployeeDTO employeeDTO)
        {
            try
            {
                employeeDTO.EmployeeId = id;
                if (employeeDTO == null)
                    return BadRequest("Argument Null");
             
                _employeeService.UpdateEmployee(employeeDTO);

                return Ok();
            }
            catch (PlatformModuleException ex)
            {
                //Write Log Here
                return BadRequest(ex.Message);
            }
        }

        [Route("api/Employees/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
              
                _employeeService.DeleteEmployee(id);
                return Ok();
            }
            catch (PlatformModuleException ex)
            {
                //Write Log Here
                return BadRequest(ex.Message);
            }
        }
    }
}
