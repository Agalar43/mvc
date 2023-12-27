using System.ComponentModel.DataAnnotations;
using Entities.Models;

namespace Entities.Dtos
{
    public record OrderDto
    {
        public int OrderID { get; init; }

        public ICollection<CartLine> Lines { get; init; } = new List<CartLine>();

        public String? userId { get; init; }

        [Required(ErrorMessage = "Name is required")]
        public String? Name { get; init; }
        public String? AddressID { get; init; }
        public Address? address { get; init; }
        public bool GiftWrap { get; init; }
        public bool Shipped { get; init; }
        public DateTime OrderedAt { get; init; } = DateTime.Now;
    }
}