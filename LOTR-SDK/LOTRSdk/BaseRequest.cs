using LOTRSdk.Data;
using RestSharp;
using System.Text.Json;

namespace LOTRSdk
{
    public class DoesNotExistException : Exception
    {
        public DoesNotExistException() : base( "Item does not exists.") { }
        public DoesNotExistException(string err) : base(err) { }
        public DoesNotExistException(Exception err) : base(err.Message) { }
    }

    public abstract class BaseRequest<R,T>
    {
        public BaseRequest( string accessToken )
        {
            AccessToken = accessToken;
        }

        public abstract string Path { get; }

        public string AccessToken { get; set; }

        protected BaseResponse<T> QueryAPI(string itemId = "", string suffix = "")
        {
            return QueryAPI<T>(itemId, suffix);
        }

        protected BaseResponse<S>? QueryAPI<S>( string itemId = "", string suffix = "" )
        {
            BaseResponse<S>? rc = null;
            var rootUrl = "https://the-one-api.dev/v2/";
            var path = $"{rootUrl}{Path}";
            var client = new RestClient(path);

            if (!string.IsNullOrWhiteSpace(itemId))
                path += $"/{itemId}";
            if (!string.IsNullOrWhiteSpace(suffix))
                path += $"/{suffix}";

            path += GetQueryString();
            var request = new RestRequest(path, Method.Get);
            if( !string.IsNullOrWhiteSpace(AccessToken) )
                request.AddHeader("Authorization", $"Bearer {AccessToken}");

            var response = client.Execute(request);
            
            if( null != response && response.IsSuccessful && !string.IsNullOrWhiteSpace( response.Content ) )
                rc = JsonSerializer.Deserialize<BaseResponse<S>>(response.Content);
            else
            {
                var error = JsonSerializer.Deserialize<ServerError>(response.Content);
                throw new DoesNotExistException( error.Message );
            }
            return rc;
        }

        public List<T> GetAll()
        {
            var rc = QueryAPI();
            return rc.docs;
        }

        public T? GetByID( string id )
        {
            T? rc = default;
            var data = QueryAPI(id);
            if( null != data && null != data.docs && data.docs.Count > 0 )
                rc = data.docs[0];
            else
                throw new DoesNotExistException($"Invalid ID - {id}");
            return rc;
        }

        public Pagination? Pagination { get; set; }
        public Filters? Filter { get; set; }
        public Sorting? Sorting { get; set; }

        protected string GetQueryString()
        {
            var rc = string.Empty;
            if (null != Pagination)
            {
                rc += Pagination.PaginationString();
            }
            if (null != Filter)
            {
                rc += Filter.FilterString();
            }
            if (null != Sorting)
            {
                rc += Sorting.SortString();
            }
            if( !string.IsNullOrWhiteSpace(rc) )
                rc = rc.Remove(0, 1);
            return $"?{rc}";
        }

    }
}