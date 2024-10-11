namespace Finance_Project.Helpers
{
    public class QueryObject
    {
        public string? Symbol { get; set; } = null;
        public string? CompanyName { get; set; } = null;
        public string? sortBy { get; set; } = null;
        public bool Isdescending {  get; set; } = false;
        public int pageNumber { get; set; } = 1;
        public int pagesize { get; set; } = 20;

    }
}
