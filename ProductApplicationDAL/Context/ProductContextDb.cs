using Microsoft.EntityFrameworkCore;
using ProductApplicationDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApplicationDAL.Context
{
    public class ProductContextDb : DbContext
    {

        public DbSet<Product>Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                   "server=.; database=ProductApplicationDb;trusted_connection=true");
        }

    }
}
