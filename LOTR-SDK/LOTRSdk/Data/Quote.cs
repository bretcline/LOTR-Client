using System.Text.Json.Serialization;

namespace LOTRSdk.Data
{
    public class Quote : BaseItem
    {
        public override string Name { get => Dialog; set => Dialog = value; }

        [JsonPropertyName("dialog")]
        public string Dialog { get; set; }
        [JsonPropertyName("movie")]
        public string Movie { get; set; }
        [JsonPropertyName("character")]
        public string Character { get; set; }
    }
}