using Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace e_commerceApp.Models
{
    public class OrderCompleteViewModel
    {
        public IEnumerable<Address>? address { get; set; }

        
        public Order? order { get; set; }
    }
}