using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Infrasturcture.Data
{
    public class ApplicationDBContext : IdentityDbContext<User, IdentityRole<int>, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ApplicationDBContext()
        {

        }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentSubject> DepartmentSubjects { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentSubject>()
                .HasKey(e => new { e.SubID, e.DID });

            modelBuilder.Entity<Ins_Subject>()
                .HasKey(e => new { e.SubId, e.InsId });

            modelBuilder.Entity<StudentSubject>()
                .HasKey(e => new { e.SubID, e.StudID });

            modelBuilder.Entity<Instructor>()
               .HasOne(e => e.Supervisor)
               .WithMany(e => e.Instructors)
               .HasForeignKey(e => e.SupervisorId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
              .HasOne(e => e.Instructor)
              .WithOne(e => e.DepartmentManager)
              .HasForeignKey<Department>(e => e.InsManager)
              .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
