using Microsoft.AspNetCore.Identity;

namespace Entities.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        public String? CityName { get; set; }
        public String? DistrictName { get; set; }
        public String? AddressName { get; set; }
        public String? ZipCode { get; set; }
        public String? userId{get;set;}

    

    }
}