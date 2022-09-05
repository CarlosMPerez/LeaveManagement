using LeaveManagement.Data.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext<Employee>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Create base roles
            builder.ApplyConfiguration(new RoleSeedConfiguration());
            // Create base users
            builder.ApplyConfiguration(new UserSeedConfiguration());
            // Link base users to base roles
            builder.ApplyConfiguration(new UserRoleSeedConfiguration());
        }

        /// <summary>
        /// Automate DATE TRACKING
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in base.ChangeTracker.Entries<BaseEntity>()
                                        .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified))
            {
                if (entry.State == EntityState.Added)
                    entry.Entity.CreationDate = DateTime.Now;
                else 
                    entry.Entity.ModificationDate = DateTime.Now;
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }

        public DbSet<LeaveRequest> LeaveRequests { get; set; }
    }
}