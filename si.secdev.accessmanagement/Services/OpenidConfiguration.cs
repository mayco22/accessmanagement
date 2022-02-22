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
        public string? ScopesSupported { get; set; }

        [JsonProperty("comapny")]
        public string? Comapny { get; set; }

        [JsonProperty("response_modes_supported")]
        public string? ResponseModesSupported { get; set; }

        [JsonProperty("response_types_supported")]
        public string? ResponseTypesSupported { get; set; }

        public OpenidConfiguration() { }

        public OpenidConfiguration(string name, JToken objJson)
        {
            Comapny = name;
            TokenEndpoint = (string?)objJson["token_endpoint"];
            LogoutEndpoint = (string?)objJson["end_session_endpoint"];
            AuthorizationEndpoint = (string?)objJson["authorization_endpoint"];
            ScopesSupported = string.Join(" ", JArray.Parse(objJson["scopes_supported"].ToString()));
            ResponseModesSupported = string.Join(" ", JArray.Parse(objJson["response_modes_supported"].ToString()));
            ResponseTypesSupported = string.Join(" ", JArray.Parse(objJson["response_types_supported"].ToString()));
        }
    }
}
