using Microsoft.EntityFrameworkCore;

namespace AndreAirlineMVC.Data
{
    public class AndreAirlineMVCContext : DbContext
    {
        public AndreAirlineMVCContext (DbContextOptions<AndreAirlineMVCContext> options)
            : base(options)
        {
        }

        public DbSet<AndreAirlineApi2.Model.AirportData> AirportData { get; set; }
    }
}
