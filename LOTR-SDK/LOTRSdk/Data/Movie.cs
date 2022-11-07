using System.Text.Json.Serialization;

namespace LOTRSdk.Data
{
    public class Movie : BaseItem
    {
        [JsonPropertyName("runtimeInMinutes")]
        public int RuntimeInMinutes { get; set; }
        [JsonPropertyName("budgetInMillions")]
        public decimal BudgetInMillions { get; set; }
        [JsonPropertyName("boxOfficeRevenueInMillions")]
        public decimal BoxOfficeRevenueInMillions { get; set; }
        [JsonPropertyName("academyAwardNominations")]
        public int AcademyAwardNominations { get; set; }
        [JsonPropertyName("academyAwardWins")]
        public int AcademyAwardWins { get; set; }
        [JsonPropertyName("rottenTomatoesScore")]
        public decimal RottenTomatoesScore { get; set; }
    }
}