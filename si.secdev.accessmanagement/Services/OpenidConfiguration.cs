namespace si.secdev.accessmanagement.Services
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class OpenidConfiguration
    {
        [JsonProperty("token_endpoint")]
        public string? TokenEndpoint { get; set; }

        [JsonProperty("end_session_endpoint")]
        public string? LogoutEndpoint { get; set; }

        [JsonProperty("authorization_endpoint")]
        public string? AuthorizationEndpoint { get; set; }

        [JsonProperty("scopes_supported")]
        public string? ScopesSuported { get; set; }

        [JsonProperty("comapny")]
        public string? Comapny { get; set; }

        public OpenidConfiguration() { }

        public OpenidConfiguration(string name, JToken objJson)
        {
            Comapny = name;
            TokenEndpoint = (string?)objJson["token_endpoint"];
            LogoutEndpoint = (string?)objJson["end_session_endpoint"];
            AuthorizationEndpoint = (string?)objJson["authorization_endpoint"];
            ScopesSuported = string.Join(" ", JArray.Parse(objJson["scopes_supported"].ToString()));
        }
    }
}
