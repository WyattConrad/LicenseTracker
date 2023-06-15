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

        public DbSet<ApplicationUser> ApplicationUser { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .HasKey(a => new { a.ApplicationId, a.UserId });
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(l => l.User)
                .WithMany(a => a.Applications)
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(m => m.Application)
                .WithMany(a => a.ApplicationUsers)
                .HasForeignKey(m => m.ApplicationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
