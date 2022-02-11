using si.secdev.accessmanagement.Models;

namespace si.secdev.accessmanagement.Services
{
    public sealed class AuthorizeResponse
    {
        private readonly IConfiguration _configuration;

        public AuthorizeResponse(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GetAuthorizeResponse(string company, Login @event)
        {
            _configuration.GetSection("COMPANY_" + company.ToUpper());

            //var loginUrl = _login.GererateRedirectLoginPageUrl(state.Id.ToString());
            //state.Scopes = @event.Scope?.Split(' ').ToList() ?? new List<string>();
            //state.MfaScopes = @event.MfaScope?.Split(' ').ToList() ?? new List<string>();

            string Url = "";
            return Url;
        }

        private OpenidConfiguration GetConfiguration(string name, string url)
        {

        }
    }
}
