using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OneBitTask.Data.Entities;
using OneBitTask.Data.Enums;
using OneBitTask.Data.Interfaces;

namespace OneBitTask.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>().HasQueryFilter(x => EF.Property<EntityStatus>(x, nameof(Customer.Status)) != EntityStatus.Deleted);
            builder.Entity<PurchaseOrder>().HasQueryFilter(x => EF.Property<EntityStatus>(x, nameof(PurchaseOrder.Status)) != EntityStatus.Deleted);

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
        }

        public override int SaveChanges()
        {
            this.AddAllRules();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            this.AddAllRules();
            return await base.SaveChangesAsync();
        }

        private void AddAllRules()
        {
            this.AddUndeletableRules();
            this.AddAuditRules();
        }

        private void AddUndeletableRules()
        {
            var entries = this.ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity && e.State == EntityState.Deleted);

            foreach (var entry in entries)
            {
                var entity = (BaseEntity)entry.Entity;
                entity.Status = EntityStatus.Deleted;
                entry.State = EntityState.Modified;
            }
        }

        private void AddAuditRules()
        {
            var entries = this.ChangeTracker.Entries().Where(e => e.Entity is IAudit && e.State == EntityState.Added);
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).Created = DateTime.UtcNow;
                }
            }
        }
    }
}
