using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions) 
        {
            
        }

        public DbSet<DataProcessor30ListingData> DataProcessor30ListingDatas {get; set;}
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<DataProcessor30ListingData>()
            .OwnsOne(p => p.DataController);
        
        modelBuilder.Entity<DataProcessor30ListingData>()
            .OwnsOne(p => p.DataProcessor);
        
        modelBuilder.Entity<DataProcessor30ListingData>()
            .OwnsOne(p => p.DataProcessorRepresentative);
        }
    }
}