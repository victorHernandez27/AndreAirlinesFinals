using System.ComponentModel.DataAnnotations;

namespace AndreAirlineApi2.Model
{
    public class AirportData
    {
        [Key]
        public int Id { get; set; }
        public string City { get; set; }
        public string Code { get; set; }
        public string Country { get; set; }
        public string Continent { get; set; }
    }
}
