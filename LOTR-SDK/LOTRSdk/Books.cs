using LOTRSdk.Data;

namespace LOTRSdk
{
    public class Books : BaseRequest<Books,Book>
    {
        public Books(): base("") { }

        public override string Path => "book";

        public List<Chapter> GetChaptersByBook( string bookId )
        {
            var rc = QueryAPI<Chapter>(bookId, "chapter");
            return rc.docs;
        }

    }
}