namespace Students_APP.Models;

public class Group
{
    public int Id { get; set; }
    
    public string GroupName { get; set; }
    
    
    // Navigation
    public ICollection<StudentGroup> StudentGroups { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
}