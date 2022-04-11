using Microsoft.EntityFrameworkCore;
using AndreAirlineApi2.Model;

namespace AndreAirlineApi2.Data
{
    public class AndreAirlineApi2Context : DbContext
    {
        public AndreAirlineApi2Context (DbContextOptions<AndreAirlineApi2Context> options)
            : base(options)
        {
        }

        public DbSet<AirportData> AirportData { get; set; }
    }
}
