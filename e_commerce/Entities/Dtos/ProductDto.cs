using System.ComponentModel.DataAnnotations;
using Entities.Models;

namespace Entities.Dtos
{
    public record ProductDto
    {
        public int ProductID { get; init; }
        [Required(ErrorMessage = "ProductName is required.")]
        public String? ProductName { get; init; } = String.Empty;

        public String? ProductDescription { get; init; } = String.Empty;

        public int? ProductRanking { get; init; } = 0;
        [Required(ErrorMessage = "Price is required.")]
        public decimal unitPrice { get; init; }

        public String? ImageUrl { get; set; }
        public String? ImageUrl1 { get; set; }
        public String? ImageUrl2 { get; set; }
        public String? ImageUrl3 { get; set; }
        public String? ImageUrl4 { get; set; }
        public String? ImageUrl5 { get; set; }
        public String? ImageUrl6 { get; set; }
        [Required(ErrorMessage = "Stock is required.")]
        public int? Stock { get; init; }
        public bool ShowCase { get; init; }

        public int? CategoryID { get; init; } // foregin key
        public Category? category { get; init; } //Navigation Property
    }
}