using LOTRSdk.Data;

namespace LOTRSdk
{
    public class Quotes : BaseRequest<Quotes,Quote>
    {
        public Quotes(string accessToken) : base(accessToken) { }
        
        public override string Path => "quote";

    }
}