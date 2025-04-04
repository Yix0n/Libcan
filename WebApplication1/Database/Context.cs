using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using WebApplication1.Database.Models;

namespace WebApplication1.Database;

public class Context : DbContext
{
    public DbSet<Student> students { get; set; }
    public DbSet<Grades> grades { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=database.db");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .HasMany(a => a.grades)
            .WithOne(b => b.Student)
            .HasForeignKey(b => b.StudentId);
    }
}