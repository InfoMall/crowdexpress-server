using AuthWebApi.Data;
using CrowdExpress.Models;
using Microsoft.EntityFrameworkCore;

namespace CrowdExpress.Data
{
    public class CrowdExpressDbContext: ApplicationDbContext<User>
    {
        public CrowdExpressDbContext(DbContextOptions<CrowdExpressDbContext> options) :
            base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Itinerary> Itineraries { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Receipient> Receipients { get; set; }
        public DbSet<WalletTransaction> WalletTransactions { get; set; }
    }
}
