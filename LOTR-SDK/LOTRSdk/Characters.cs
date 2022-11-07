using LOTRSdk.Data;

namespace LOTRSdk
{
    public class Characters : BaseRequest<Characters,Character>
    {
        public Characters(string accessToken) : base(accessToken) { }
        
        public override string Path => "character";

        public List<Quote> GetQuoteByCharacter( string characterId )
        {
            var rc = QueryAPI<Quote>(characterId, "quote");
            return rc.docs;
        }

    }
}