namespace Server.Models
{
    public class GetEntriesParameters
    {
        public int? Code { get; set; }

        public string Value { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}
