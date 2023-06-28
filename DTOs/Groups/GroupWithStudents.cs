namespace Students_APP.DTOs;

public class GroupWithStudents
{
    public int GroupId { get; set; }
    public string GroupName { get; set; }
    public int CourseId { get; set; }
    public string CourseName { get; set; }
    public List<StudentGetDto> Students { get; set; }
}
