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

            builder.Entity<CustomAttribute>()
                .ToTable("CustomAttribute")
                .HasKey(ca => ca.CustomAttributeId);

            builder.Entity<CustomAttribute>()
                .HasMany(ca => ca.CustomAttributeValues)
                .WithOne(cav => cav.CustomAttribute)
                .HasForeignKey(cav => cav.CustomAttributeId);

            builder.Entity<CustomAttributeValue>()
                .ToTable("CustomAttributeValue")
                .HasKey(cav => cav.CustomAttributeValueId);    

            builder.Entity<Project>()
                .ToTable("Project")
                .HasKey(p => p.ProjectId);

            builder.Entity<Project>()
                .HasMany(p => p.ProjectFollowers)
                .WithOne(e=>e.Project)
                .HasForeignKey(pf => pf.ProjectId);

            builder.Entity<Project>()
                .HasMany(p => p.ProjectShareholders)
                .WithOne(s => s.Project)
                .HasForeignKey(s => s.ProjectId);

            builder.Entity<Project>()
                .HasMany(p => p.ExtraAttributes)
                .WithOne()    
                .HasForeignKey(cav => cav.ProjectId);

            builder.Entity<ProjectFollower>()
                .ToTable("ProjectFollower")
                .HasKey(pf => pf.ProjectFollowerId);

            builder.Entity<ShareHolder>()
                .ToTable("ShareHolder")
                .HasKey(s => s.ShareHolderId);

      
        }
    }
}
