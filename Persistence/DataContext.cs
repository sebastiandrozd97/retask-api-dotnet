using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
  public class DataContext : IdentityDbContext<AppUser>
  {
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Workday> Workdays { get; set; }
    public DbSet<Workplace> Workplaces { get; set; }
    public DbSet<WorkdayMaterial> WorkdayMaterials { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Notification> Notifications { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
      builder.Entity<AppUser>()
        .Ignore(c => c.AccessFailedCount)
        .Ignore(c => c.EmailConfirmed)
        .Ignore(c => c.PhoneNumberConfirmed)
        .Ignore(c => c.TwoFactorEnabled)
        .Ignore(c => c.LockoutEnd)
        .Ignore(c => c.LockoutEnabled);
    }
  }
}
