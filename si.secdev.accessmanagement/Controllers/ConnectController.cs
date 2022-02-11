using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using si.secdev.accessmanagement.Models;
using si.secdev.accessmanagement.Services;

namespace si.secdev.accessmanagement.Controllers
{
    [Route("api/v2/[controller]")]
    [ApiController]
    public class ConnectController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        
        public ConnectController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        [HttpGet("{company}/authorize")]
        public async Task<ActionResult> Authorize(string company, [FromQuery] Login @event)
        {
            try
            {
                if (!_configuration.GetSection("COMPANY_" + company.ToUpper()).Exists())
                    return Unauthorized("The company is not implemented");
                
                AuthorizeResponse authorizeResponse = new(_configuration);
                string Url = await authorizeResponse.getAuthorizeResponse(company, @event);
                return Redirect(Url);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex);
            }
        }

        [HttpGet("token")]
        public async Task<ActionResult> GetToken()
        {
            try
            {
                string jsonContent = "{ 'access_token': '', 'token_type': '', 'expires_in': '', 'refresh_token': '' }";
                Token tok = JsonConvert.DeserializeObject<Token>(jsonContent);
                return Ok(tok);
            }
            catch(Exception ex)
            {
                return Unauthorized(ex);
            }
        }

        [HttpGet("logout")]
        public async Task<ActionResult> Logout([FromQuery] Logout @event)
        {
            return Redirect("");
        }
    }
}
