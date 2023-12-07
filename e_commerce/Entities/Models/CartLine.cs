namespace Entities.Models
{
    public class CartLine
    {
        public int CartID { get; set; }

        public Product Product { get; set; } = new();

        public int Quantity { get; set; }

    }
}