using Blue.Server.CityJournal.Models;
using Blue.Shared;
using Microsoft.EntityFrameworkCore;

namespace Blue.Server.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context) { }

        public DbSet<CityModel> CityModels { get; set; }
    }
}
