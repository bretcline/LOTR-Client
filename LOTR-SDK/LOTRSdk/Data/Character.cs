using System.Text.Json.Serialization;

namespace LOTRSdk.Data
{
    public class Character : BaseItem
    {
        [JsonPropertyName("height")]
        public string Height { get; set; }
        [JsonPropertyName("race")]
        public string Race { get; set; }
        [JsonPropertyName("gender")]
        public string Gender { get; set; }
        [JsonPropertyName("birth")]
        public string Birth { get; set; }
        [JsonPropertyName("spouse")]
        public string Spouse { get; set; }
        [JsonPropertyName("death")]
        public string Death { get; set; }
        [JsonPropertyName("realm")]
        public string Realm { get; set; }
        [JsonPropertyName("hair")]
        public string Hair { get; set; }
        [JsonPropertyName("wikiUrl")]
        public string WikiUrl { get; set; }
    }
}