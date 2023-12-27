namespace e_commerceApp.Models
{
    public class Pagination
    {
        public int TotelItems { get; set; }
        public int ItemsPerPage{get;set;}

        public int CurrenPage { get; set; }

        public int TotalPages => (int)Math.Ceiling((decimal)TotelItems/ItemsPerPage);


    }
}