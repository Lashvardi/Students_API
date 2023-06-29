using Students_APP.Models;

namespace Students_APP.DTOs;

public class CourseWithGroupInfo
{
    public int CourseId { get; set; }
    public string CourseName { get; set; }
    public List<GroupNameWithId> GroupInfos { get; set; }
    
    public int GetNumberOfStudents()
    {
        int numberOfStudents = 0;
        foreach (var groupInfo in GroupInfos)
        {
            numberOfStudents += groupInfo.NumberOfStudents;
        }

        return numberOfStudents;
    }
}
