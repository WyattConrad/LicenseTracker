namespace LicenseTracker.Data
{
    public class LicenseTrackerContext : DbContext
    {
        public LicenseTrackerContext (DbContextOptions<LicenseTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<LicenseTracker.Models.Team> Team { get; set; } = default!;

        public DbSet<LicenseTracker.Models.Application> Application { get; set; } = default!;

        public DbSet<LicenseTracker.Models.User> User { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(a => a.Applications)
                .WithMany(b => b.Users)
                .UsingEntity(join => join.ToTable("ApplicationUser"));
        }
    }
}
