using Microsoft.EntityFrameworkCore;
using Osm.ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osm.DataAccessLayer.EF.Context
{
    public class OsmanliMakinaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=HAKAN\\SQLEXPRESS;database=OsmanliMakina;trusted_connection=true;");
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<AdminLogin> AdminLogin { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<CompanyInfo> CompanyInfo { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
    }
}
