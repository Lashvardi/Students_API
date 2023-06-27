using Microsoft.EntityFrameworkCore;
using Students_APP.Models;

namespace Students_APP.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    
    public DbSet<Course> Courses { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Group> Groups { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .HasKey(s => s.Guid);
        
        modelBuilder.Entity<StudentCourse>()
            .HasKey(sc => new { sc.StudentGuid, sc.CourseId });
        
        modelBuilder.Entity<StudentGroup>()
            .HasKey(sg => new { sg.StudentGuid, sg.GroupId });
        
        modelBuilder.Entity<Group>()
            .HasOne(g => g.Course)
            .WithMany(c => c.Groups)
            .HasForeignKey(g => g.CourseId);
    }
}