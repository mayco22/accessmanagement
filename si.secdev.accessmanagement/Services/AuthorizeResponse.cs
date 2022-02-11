using Newtonsoft.Json.Linq;
using si.secdev.accessmanagement.Models;

namespace si.secdev.accessmanagement.Services
{
    public sealed class AuthorizeResponse
    {
        private readonly IConfiguration _configuration;
        private static OpenidConfiguration? openidConfiguration;

        public AuthorizeResponse(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GetAuthorizeResponse(string company, Login @event)
        {
            if (openidConfiguration == null)
                openidConfiguration = GetConfiguration(company , _configuration.GetSection("COMPANY_" + company.ToUpper()).Value);

            var loginUrl = GererateRedirectLoginPageUrl(@event, openidConfiguration);
            //state.Scopes = @event.Scope?.Split(' ').ToList() ?? new List<string>();

            string Url = "";
            return Url;
        }

        private OpenidConfiguration GetConfiguration(string name, string url)
        {
            using var client = new HttpClient();
            
            HttpResponseMessage resp = client.GetAsync(url).Result;
            if (!resp.IsSuccessStatusCode)
                throw new Exception(resp.Content.ReadAsStringAsync().Result);
            
            var objectConfig = JToken.Parse(resp.Content.ReadAsStringAsync().Result);
            OpenidConfiguration configuration = new(name, objectConfig);
            
            return configuration;
        }

        private string GererateRedirectLoginPageUrl(Login @event, OpenidConfiguration openidConfiguration)
        {

        }
    }
}
