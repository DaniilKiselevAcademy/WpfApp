using Microsoft.EntityFrameworkCore;

namespace WpfApp
{
    class Context : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=test.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, Name = "Марк", Age=16 },
                new Student { StudentId = 2, Name = "Денис", Age=16 }
                ); 
        }
    }
}
