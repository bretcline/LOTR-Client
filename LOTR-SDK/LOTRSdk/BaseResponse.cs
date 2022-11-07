namespace LOTRSdk
{
    public class BaseResponse<T>
    {
        public List<T> docs { get; set; }
        public int total { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int page { get; set; }
        public int pages { get; set; }

    }
}