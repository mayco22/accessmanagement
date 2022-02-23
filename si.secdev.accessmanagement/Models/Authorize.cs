using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace si.secdev.accessmanagement.Models
{
    public class Authorize
    {
        [JsonProperty("client_id")]
        [FromQuery(Name = "client_id")]
        public string? ClientId { get; set; }

        [JsonProperty("client_secret")]
        [FromQuery(Name = "client_secret")]
        public string? ClientSecret { get; set; }

        [JsonProperty("scope")]
        [FromQuery(Name = "scope")]
        public string? Scope { get; set; }

        [JsonProperty("state")]
        [FromQuery(Name = "state")]
        public string? State { get; set; }

        [JsonProperty("redirect_uri")]
        [FromQuery(Name = "redirect_uri")]
        public string? RedirectUri { get; set; }
    }
}
