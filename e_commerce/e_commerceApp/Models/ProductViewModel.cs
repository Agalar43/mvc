using Entities.Models;

namespace e_commerceApp.Models
{
    public class ProductViewModel
    {
        public IEnumerable<Comment>? Comment { get; set; }
        public Product? Product { get; set; }

        public String? UserName { get; set; }
    }
}