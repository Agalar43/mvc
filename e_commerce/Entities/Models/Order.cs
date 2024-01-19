using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using Entities.Models;

namespace Entities.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();

        public String? userId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public String? Name { get; set; }
        public String? Adress { get; set; }
        public int AddressId { get; set; }
        public Address? address { get; set; }
        public bool GiftWrap { get; set; }
        public bool Shipped { get; set; }
        public DateTime OrderedAt { get; set; } = DateTime.Now;


    }
}