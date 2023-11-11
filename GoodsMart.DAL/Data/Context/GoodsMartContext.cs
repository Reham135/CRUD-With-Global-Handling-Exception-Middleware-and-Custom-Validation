using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsMart.DAL.Data.Context
{
    public class GoodsMartContext:DbContext
    {
        public DbSet<Product> Products =>Set<Product>();
        public GoodsMartContext(DbContextOptions<GoodsMartContext>options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Configure Product Properties
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Product>().Property(p => p.Price).IsRequired().HasMaxLength(7);
            modelBuilder.Entity<Product>().Property(p => p.ExpiryDate).IsRequired();

            #endregion

           

        }

    }
}
