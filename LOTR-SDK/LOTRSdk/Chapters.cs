using LOTRSdk.Data;

namespace LOTRSdk
{
    public class Chapters : BaseRequest<Chapters,Chapter>
    {
        public Chapters(string accessToken) : base(accessToken) { }

        public override string Path => "chapter";

    }
}