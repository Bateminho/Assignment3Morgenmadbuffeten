using Assignment3Morgenmadbuffeten.Models.Users;
using Assignment3Morgenmadbuffeten.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Assignment3Morgenmadbuffeten.Data
{
    public class BreakfastBuffetDbContext : DbContext
    {
	    private const string DbName = "HOTELAU";
	    private const string ConnectionString = $"Data Source=localhost;Initial Catalog={DbName};User ID=SA;Password=<YourStrong@Passw0rd>;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

		public BreakfastBuffetDbContext(DbContextOptions<BreakfastBuffetDbContext> options) : base(options)
        {
        }

        public DbSet<Kitchen>? Kitchens { get; set; }
        public DbSet<Reception>? Receptions { get; set; }
        public DbSet<Restaurant>? Restaurants { get; set; }

        public DbSet<CheckInBreakfastBuffetGuest>? CheckInBreakfastBuffetGuests { get; set; }

        public DbSet<ExpectedBreakfastGuests>? ExpectedBreakfastGuests { get; set; }
    }
}