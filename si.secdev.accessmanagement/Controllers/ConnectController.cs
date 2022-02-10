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
        [HttpGet("authorize")]
        public async Task<ActionResult> Authorize([FromQuery] Login @event)
        {
            try
            {
                //Valida scope e retorna a url de login
                AuthorizeResponse auth = new AuthorizeResponse();
                string Url = auth.getAuthorizeResponse(@event);
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
