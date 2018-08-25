
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Platform.Service;
using Platform.Utilities.ExceptionHandler;
using System.Configuration;
using Platform.DTO;

namespace PlatformWeb.Controller
{

    [Route("api/login")]
    public class LoginController : ApiController
    {
        private readonly IEmployeeService _employeeService;

        public LoginController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [AllowAnonymous]
        public IHttpActionResult Post([FromBody]LoginDto loginDto)
        {
            try
            {
                if (loginDto == null)
                    return BadRequest();
                bool isValid = _employeeService.ValidateLoginAndCreateEmployeeSession(loginDto);
                if (isValid)
                {

                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("PlatformSecretKey"));
                    var signingCredientials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    string baseAddress = ConfigurationManager.AppSettings["BaseUri"].ToString();
                    var tokenOptions = new JwtSecurityToken(
                        issuer: baseAddress,
                        audience: baseAddress,
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(6),
                        signingCredentials: signingCredientials);
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                    return Ok(new { Token = tokenString });
                }
                else
                {
                    return BadRequest("User Name or Password is InCorrect");
                }


               
                   
            }
            catch(PlatformModuleException ex)
            {
                //Write Log Here
                return BadRequest(ex.Message);
            }
        }
    }
}
