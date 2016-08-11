using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AcademySample.Models
{
    public class ComputerDbContext : DbContext
    {
        public DbSet<ComputerDetails> ComputerDetails { get; set; }
        public DbSet<UsageData> UsageDatas { get; set; }

        public ComputerDbContext(DbContextOptions<ComputerDbContext> options) : 
            base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UsageData>()
                .HasOne(ud => ud.ComputerDetails)
                .WithMany(cd => cd.UsageDatas)
                .HasForeignKey(ud => ud.ComputerName);
        }
    }
}
