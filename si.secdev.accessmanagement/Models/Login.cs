using Newtonsoft.Json;

namespace si.secdev.accessmanagement.Models
{
    public class Login
    {
        [JsonProperty("client_id")]
        public string? ClientId { get; set; }

        [JsonProperty("client_secret")]
        public string? ClientSecret { get; set; }

        [JsonProperty("scope")]
        public string? Scope { get; set; }

        [JsonProperty("state")]
        public string? State { get; set; }

        [JsonProperty("redirect_uri")]
        public string? RedirectUri { get; set; }

        public override string ToString()
        {
            Dictionary<string, string> dJson = new Dictionary<string, string>() 
            {
                { "client_id", ClientId },
                { "client_secret", ClientSecret },
                { "scope", Scope },
                { "state", State },
                { "redirect_uri", RedirectUri },
            };
            return JsonConvert.SerializeObject(dJson);
        }
    }
}
