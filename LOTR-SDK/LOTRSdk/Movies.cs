using LOTRSdk.Data;

namespace LOTRSdk
{
    public class Movies : BaseRequest<Movies,Movie>
    {
        public Movies(string accessToken) : base(accessToken) { }
        public override string Path => "movie";
        public List<Quote> GetQuoteByMovie(string movieId)
        {
            var rc = QueryAPI<Quote>(movieId, "quote");
            return rc.docs;
        }
    }
}