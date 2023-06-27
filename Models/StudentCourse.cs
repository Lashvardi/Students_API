namespace Students_APP.Models;

public class StudentCourse
{
    public string StudentGuid { get; set; }
    public Student Student { get; set; }

    public int CourseId { get; set; }
    public Course Course { get; set; }
}