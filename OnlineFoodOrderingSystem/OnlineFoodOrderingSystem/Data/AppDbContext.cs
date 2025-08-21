
using Microsoft.Azure.Documents;
using Microsoft.EntityFrameworkCore;
using OnlineFoodOrderingSystem.Models;

namespace OnlineFoodOrderingSystem.Data
{
    public class AppDbContext : DbContext // Explicitly specify the namespace
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {

        }


        public DbSet<RegisterVM> registerUser { get; set; }
        public DbSet<UserRole> userrole { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //  Configure 1:1 relationship between RegisterVM and UserRole
            //modelBuilder.Entity<RegisterVM>()
            //    .HasOne(r => r.UserRoles)           // RegisterVM has one UserRole
            //    .WithOne(ur => ur.RegisterVM)      // UserRole has one RegisterVM
            //    .HasForeignKey<RegisterVM>(r => r.roleID)  // Foreign key in RegisterVM
            //    .HasConstraintName("FK_RegisterVM_UserRole")
            //    .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            //// Create index on foreign key
            //modelBuilder.Entity<RegisterVM>()
            //    .HasIndex(r => r.roleID)
            //    .HasDatabaseName("IX_RegisterVM_RoleID");



            //////Email ID unique key
            //var userEntity = modelBuilder.Entity<RegisterVM>();
            //userEntity.HasIndex(u => u.emailID).IsUnique(); // Uniqu

            modelBuilder.Entity<RegisterVM>()
     .HasOne(r => r.UserRoles)          // Use UserRoles (plural) to match your property
     .WithOne(ur => ur.RegisterVM)
     .HasForeignKey<RegisterVM>(r => r.roleID)
     .HasPrincipalKey<UserRole>(ur => ur.roleId)
     .HasConstraintName("FK_RegisterVM_UserRole")
     .OnDelete(DeleteBehavior.Restrict);

            // Create index on foreign key
            modelBuilder.Entity<RegisterVM>()
                .HasIndex(r => r.roleID)
                .HasDatabaseName("IX_RegisterVM_RoleID");


            base.OnModelCreating(modelBuilder);

        }
    }
}
