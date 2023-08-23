using EShop.Domain.Entities;
using EShop.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Persistence.Contexts
{
    public class EShopDbContext : DbContext
    {
        public EShopDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEnitity>();
            foreach (var entry in datas)
            {
                _ = entry.State switch
                {
                    EntityState.Added => entry.Entity.CreatedTime = DateTime.Now,
                    _ => DateTime.Now
                };
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

    }
}
