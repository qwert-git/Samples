namespace Paging.Api.Data.Models
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int Capacity { get; set; }
        public string Publisher { get; set; }
    }
}