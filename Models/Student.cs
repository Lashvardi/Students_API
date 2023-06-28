using Microsoft.EntityFrameworkCore;

namespace Students_APP.Models;

public class Student
{
    public string Guid { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
        
    public ICollection<StudentGroup> StudentGroups { get; set; }
    public ICollection<StudentCourse> StudentCourses { get; set; }
    public ICollection<FinalProject> StudentFinalProjects { get; set; }
}