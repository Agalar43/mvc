using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage = "ProductName is required.")]
        public String? ProductName { get; set; } = String.Empty;

        public String? ProductDescription { get; set; } = String.Empty;

        public String? ProductRanking { get; set; } 
        [Required(ErrorMessage = "Price is required.")]
        public decimal unitPrice { get; set; }

        public String? ImageUrl {get;set;}
        [Required(ErrorMessage = "Stock is required.")]
        public int? Stock { get; set; }

        public int? CategoryID { get; set; } // foregin key
        public Category? category { get; set; } //Navigation Property
    }
}