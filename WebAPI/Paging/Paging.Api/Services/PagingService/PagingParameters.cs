namespace Paging.Api.Services.PagingService
{
    public class PagingParameters
    {
        private const int MaxPageSize = 50;

        public PagingParameters(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        private int _pageNumber;
        public int PageNumber 
        { 
            get { return _pageNumber; } 
            private set 
            {
                _pageNumber = value > 0 ? value : 1;
            } 
        }

        private int _pageSize;
        public int PageSize
        {
            get { return _pageSize; }
            private set 
            { 
                if(value < 1)
                    _pageSize = 1;
                else if(value > MaxPageSize)
                    _pageSize = MaxPageSize;
                else
                    _pageSize = value;
            }
        }
    }
}