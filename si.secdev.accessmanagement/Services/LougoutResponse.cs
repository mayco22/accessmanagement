using Newtonsoft.Json.Linq;
using si.secdev.accessmanagement.Models;

namespace si.secdev.accessmanagement.Services
{
    public sealed class LougoutResponse
    {
        private readonly IConfiguration _configuration;
        private static OpenidConfiguration? openidConfiguration;

        public LougoutResponse(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetLougoutResponse(string company, Logout @event)
        {
            if (openidConfiguration == null)
                openidConfiguration = GetConfiguration(company, _configuration.GetSection("COMPANY_" + company.ToUpper()).Value);

            var loginUrl = GererateRedirectLoginPageUrl(@event, openidConfiguration);
            //state.Scopes = @event.Scope?.Split(' ').ToList() ?? new List<string>();

            return loginUrl;
        }

        private OpenidConfiguration GetConfiguration(string name, string url)
        {
            using var client = new HttpClient();

            HttpResponseMessage resp = client.GetAsync(url).Result;
            if (!resp.IsSuccessStatusCode)
                throw new Exception(resp.Content.ReadAsStringAsync().Result);

            var objectConfig = JToken.Parse(resp.Content.ReadAsStringAsync().Result);
            OpenidConfiguration configuration = new OpenidConfiguration(name, objectConfig);

            return configuration;
        }

        private string GererateRedirectLoginPageUrl(Logout @event, OpenidConfiguration openidConfiguration)
        {
            string Url = $"{openidConfiguration.LogoutEndpoint}?post_logout_redirect_uri={@event.Callback}";

            return Url;
        }

    }
}
