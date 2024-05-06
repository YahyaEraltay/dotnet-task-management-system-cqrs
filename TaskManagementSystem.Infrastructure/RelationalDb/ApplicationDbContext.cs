using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Domain.Entites;

namespace TaskManagementSystem.Infrastructure.RelationalDb
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ToDoTask> ToDoTasks { get; set; }

        public ApplicationDbContext(string connectionString) : base(BuildDbContextOptions(connectionString))
        {
        }

        public static DbContextOptions<ApplicationDbContext> BuildDbContextOptions(string connectionString)
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            dbContextOptionsBuilder.UseSqlServer(connectionString);
            return dbContextOptionsBuilder.Options;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoTask>()
                .HasOne(x => x.AssignedUser)
                .WithMany()
                .HasForeignKey(x => x.AssignedUserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
