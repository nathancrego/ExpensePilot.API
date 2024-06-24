using ExpensePilot.API.Models.Domain.Administration.DepartmentManagement;
using ExpensePilot.API.Models.Domain.Administration.RoleAccessManagement;
using ExpensePilot.API.Models.Domain.Administration.UserManagement;
using Microsoft.EntityFrameworkCore;

namespace ExpensePilot.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
        public DbSet<Users> tblEPUsers { get; set; }
        public DbSet<UserRoles> tblEPUserRoles { get; set; }
        public DbSet<UserAccess> tblEPUserAccess { get; set;}
        public DbSet<Department> tblEPDepartments { get; set; }
        public DbSet<Login> tblEPLogin { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccess>()
                .HasKey(ua => ua.UserAccessID);

            //User - Useraccess relationship
            modelBuilder.Entity<UserAccess>()
                .HasOne(ua => ua.User)
                .WithMany(u => u.tblEPUserAccess)
                .HasForeignKey(ua => ua.UserID);

            //Userrole - Useraccess relationship
            modelBuilder.Entity<UserAccess>()
                .HasOne(ua => ua.UserRole)
                .WithMany(ur => ur.tblEPUserAccess)
                .HasForeignKey(ua => ua.UserRoleID);

            //User - Department relationship
            modelBuilder.Entity<Users>()
                .HasOne(u => u.Department)
                .WithMany(d => d.tblEPUsers)
                .HasForeignKey(u => u.DepartmentID);

            //user - login relationship
            modelBuilder.Entity<Users>()
            .HasKey(u => u.ID);

            modelBuilder.Entity<Users>()
                .HasOne(u => u.Login)
                .WithOne(l => l.User)
                .HasForeignKey<Login>(l => l.UserID);

            // Configure Login entity
            modelBuilder.Entity<Login>()
                .HasKey(l => l.LoginId);

            modelBuilder.Entity<Login>()
                .Property(l => l.HashedPassword)
                .IsRequired();
        }

    }
}
