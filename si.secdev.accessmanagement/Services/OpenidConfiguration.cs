namespace si.secdev.accessmanagement.Services
{
    using Newtonsoft.Json;
    public class OpenidConfiguration
    {
        [JsonProperty("token_endpoint")]
        public string? TokenEndpoint { get; set; }

        [JsonProperty("end_session_endpoint")]
        public string? LogoutEndpoint { get; set; }

        [JsonProperty("authorization_endpoint")]
        public string? AuthorizationEndpoint { get; set; }

        [JsonProperty("scopes_supported")]
        public string[]? ScopesSuported { get; set; }
    }
}
