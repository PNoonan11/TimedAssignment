namespace TimedAssignment.Services.Pagination
{
    public class PagedResponse
    {
        private const int _maxPageSize = 10;
        private int pageSize;


        public int PageNumber { get; set; } = 1;
        public int PageSize
        {
            get => pageSize;
            set => pageSize = value > _maxPageSize ? _maxPageSize : value;
        }
    }
}