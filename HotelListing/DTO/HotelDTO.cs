using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.DTO
{
    public class CreateHotelDTO
    {
      

        [Required]
        [StringLength(maximumLength: 150, ErrorMessage = "Hotel Name Is Too Long")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 250, ErrorMessage = "Address Name Is Too Long")]
        public string Address { get; set; }

        [Required]
        [Range(1,5)]
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }

        public int CountryId { get; set; }
        public CountryDTO Country { get; set; }
    }


    public class HotelDTO:CreateCountryDTO
    {
        public int Id { get; set; }

    }
}
