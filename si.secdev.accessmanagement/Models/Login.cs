using Newtonsoft.Json;

namespace si.secdev.accessmanagement.Models
{
    public class Login
    {
        [JsonProperty("code")]
        public string? Code { get; set; }

        [JsonProperty("state")]
        public string? State { get; set; }

        [JsonProperty("session_state")]
        public string? Session_state { get; set; }
    }
}
