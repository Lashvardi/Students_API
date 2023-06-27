namespace Students_APP.Models;

public class StudentGroup
{
    public string StudentGuid { get; set; }
    public Student Student { get; set; }

    public int GroupId { get; set; }
    public Group Group { get; set; }
}