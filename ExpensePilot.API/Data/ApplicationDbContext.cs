using ExpensePilot.API.Models.Domain.Administration.DepartmentManagement;
using ExpensePilot.API.Models.Domain.Administration.ExpenseCategoryManagement;
using ExpensePilot.API.Models.Domain.Administration.RoleAccessManagement;
using ExpensePilot.API.Models.Domain.Administration.UserManagement;
using ExpensePilot.API.Models.Domain.Expense;
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
        public DbSet<Expenses> tblEPExpenses { get; set; }
        public DbSet<ExpenseCategory> tblEPExpenseCategory { get; set; }
        public DbSet<InvoiceReceipt> tblEPInvoiceReceipt { get; set; }
        public DbSet<ExpenseStatus> tblEPExpenseStatus { get; set; }

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

            //Configure user and expense relationship
            modelBuilder.Entity<Expenses>()
                .HasOne(e => e.User)
                .WithMany(u => u.tblEPExpenses)
                .HasForeignKey(e => e.UserID);

            //Configure Expense and expense category relationship
            modelBuilder.Entity<Expenses>()
                .HasOne(ec => ec.ExpenseCategory)
                .WithMany(e => e.tblEPExpenses)
                .HasForeignKey(ec => ec.ExpenseCategoryID);

            //Configure Expense and expense status relationship
            modelBuilder.Entity<Expenses>()
                .HasOne(es => es.ExpenseStatus)
                .WithMany(e => e.tblEPExpenses)
                .HasForeignKey(es => es.ExpenseStatusID);

            //Configure Expense and InvoiceReceipt relationship
            modelBuilder.Entity<Expenses>()
                .HasOne(e => e.InvoiceReceipt)
                .WithOne(i => i.Expense)
                .HasForeignKey<Expenses>(e => e.InvoiceReceiptID)
                .IsRequired();
        }

    }
}
