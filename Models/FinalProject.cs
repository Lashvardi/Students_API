namespace Students_APP.Models;

public class FinalProject
{
    public int Id { get; set; }
    
    public string ProjectName { get; set; }
    
    public string ProjectDescription { get; set; }
    
    public string ProjectLink { get; set; }
    
    
    // Navigation
    public string StudentGuid { get; set; }
    public Student Student { get; set; }
    
    public int CourseId { get; set; }
    public Course Course { get; set; }
}