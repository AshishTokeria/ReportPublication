using FVA.IPV.ReportPublication.Model.Configuration;
using FVA.IPV.ReportPublication.Model.Data;
using Microsoft.EntityFrameworkCore;

namespace FVA.IPV.ReportPublication.Data.Context
{
    public class CreateDbContext : DbContext
    {
        public DbSet<ReportOutputModel> ReportOutputModels { get; set; }
        public DbSet<ReportTradeOutputModel> ReportTradeOutputModels { get; set; }
        public DbSet<ReportHeader> ReportHeaders { get;set; }
        public DbSet<ReportSettings> ReportSettings { get; set; }

        public CreateDbContext(DbContextOptions<CreateDbContext> options) : base(options)
        {
            Database.SetCommandTimeout(900);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ReportOutputModel>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<ReportTradeOutputModel>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<ReportHeader>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<ReportSettings>()
                .HasKey(x => x.Id);

        }
    }
}
