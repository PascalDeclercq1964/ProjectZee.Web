using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace ProjectZee.Web.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<ShareHolder> ShareHolders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Project>()
                .ToTable("Project")
                .HasKey(p => p.ProjectId)  
                .HasMany(p => p.Followers)
                .WithMany(u => u.FollowedProjects);
            builder.Entity<Project>()
                .HasMany(p => p.Candidates)
                .WithOne(s => s.Project)
                .HasForeignKey(s => s.ProjectId);

            builder.Entity<ShareHolder>()
                .ToTable("ShareHolder")
                .HasKey(s => s.ShareHolderId);
        }
    }
}
