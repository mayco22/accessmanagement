namespace si.secdev.accessmanagement.Models
{
    using Newtonsoft.Json;
    public class Logout
    {
        [JsonProperty("callback")]
        public string? Callback { get; set; }

        [JsonProperty("token")]
        public string? Token { get; set; }
    }
}
