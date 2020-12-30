namespace Paging.Api.ApiModels
{
    public class GetBooksParameters
    {
        private const int MaxPageSize = 50;

        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get { return _pageSize > MaxPageSize ? MaxPageSize : _pageSize; }
            set { _pageSize = value > 0 ? value : 1; }
        }
    }
}