using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace LOTRSdk
{

    public class Sorting
    {
        public bool Descending { get; set; }
        public string Property { get; set; }

        public string SortString()
        {
            return $"&sort={Property}:" + ( Descending ? "desc" : "asc" );
        }
    }

    public class Filters
    {
        public bool Exclude { get; set; }
        public string Property { get; set; }
        public string Values { get; set; }
        public string Operator { get; set; }

        public string FilterString()
        {
            if( string.IsNullOrWhiteSpace( Operator ) )
                Operator = "=";

            return $"&{Property}" + ( Exclude ? $"!{Operator}" : Operator ) + Values;
        }
    }

    public class Pagination
    {
        public int Page { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }

        public string PaginationString()
        {
            var rc = string.Empty;

            if (Page > 0)
            {
                rc = $"&page={Page}";
            }
            if ( Limit > 0)
            {
                rc = $"&limit={Limit}";
            }
            if ( Offset > 0)
            {
                rc = $"&offset={Offset}";
            }

            return rc;
        }
    }
}