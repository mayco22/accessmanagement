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
        public async Task<ActionResult> Authorize(string company, [FromQuery] Authorize @event)
        {
            try
            {
                if (!_configuration.GetSection("COMPANY_" + company.ToUpper()).Exists())
                    return Unauthorized("The company is not implemented");

                AuthorizeResponse authorizeResponse = new AuthorizeResponse(_configuration);
                string Url = await authorizeResponse.GetAuthorizeResponse(company, @event);
                
                return Redirect(Url);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex);
            }
        }

        [HttpGet("{company}/authorize/login")]
        public async Task<ActionResult> Login(string company, [FromQuery] Login @event)
        {
            try
            {
                if (!_configuration.GetSection("COMPANY_" + company.ToUpper()).Exists())
                    return Unauthorized("The company is not implemented");

                LoginResponse loginResponse = new LoginResponse(_configuration);
                var redirectUri = await loginResponse.GetLoginResponse(company, @event);
                
                return Redirect(redirectUri.ToString());
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpGet("{company}/callback")]
        public async void Callback(string company, string code)
        {

        }

        [HttpPost("{company}/token")]
        public async Task<ActionResult> GetToken(string company, [FromQuery] Login @event)
        {
            try
            {
                if (!_configuration.GetSection("COMPANY_" + company.ToUpper()).Exists())
                    return Unauthorized("The company is not implemented");

                string jsonContent = "{ 'access_token': '', 'token_type': '', 'expires_in': '', 'refresh_token': '' }";
                Token tok = JsonConvert.DeserializeObject<Token>(jsonContent);
                return Ok(tok);
            }
            catch(Exception ex)
            {
                return Unauthorized(ex);
            }
        }

        [HttpGet("{company}/logout")]
        public async Task<ActionResult> Logout(string company, [FromQuery] Logout @event)
        {
            if (!_configuration.GetSection("COMPANY_" + company.ToUpper()).Exists())
                return Unauthorized("The company is not implemented");

            LougoutResponse logoutResponse = new(_configuration);
            string responseRedirectUrl = logoutResponse.GetLougoutResponse(company, @event);

            return Redirect(responseRedirectUrl);
        }
    }
}
