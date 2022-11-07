using System.Text.Json.Serialization;

namespace LOTRSdk.Data
{
    public class Chapter : BaseItem
    {
        public override string Name { get => ChapterName; set => ChapterName = value; }

        [JsonPropertyName("chapterName")]
        public string ChapterName { get; set; }

        [JsonPropertyName("book")]
        public string Book { get; set; }
    }
}