using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage = "ProductName is required.")]
        public String? ProductName { get; set; } = String.Empty;

        public String? ProductDescription { get; set; } = String.Empty;

        public int? ProductRanking { get; set; } = 0;
        [Required(ErrorMessage = "Price is required.")]
        public decimal unitPrice { get; set; }

        public String? ImageUrl { get; set; }
        public String? ImageUrl1 { get; set; }
        public String? ImageUrl2 { get; set; }
        public String? ImageUrl3 { get; set; }
        public String? ImageUrl4 { get; set; }
        public String? ImageUrl5 { get; set; }
        public String? ImageUrl6 { get; set; }
        [Required(ErrorMessage = "Stock is required.")]
        public int? Stock { get; set; }

        public int? CategoryID { get; set; } // foregin key
        public Category? category { get; set; } //Navigation Property

        public bool ShowCase { get; set; }
        
    }
}