using System.Text.Json.Serialization;

namespace LOTRSdk.Data
{
    public class BaseItem
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public virtual string Name { get; set; }
    }


    public class ServerError
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }

}