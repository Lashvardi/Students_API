using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Students_APP.Data;
using Students_APP.DTOs;
using Students_APP.Models;

namespace Students_APP.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : Controller
{
    private readonly DataContext _context;

    public StudentController(DataContext context)
    {
        _context = context;
    }
    
    // Get All Students With Group and Course Name
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StudentGetDto>>> GetStudents()
    {
        return await _context.Students.Select(student => new StudentGetDto
        {
            Guid = student.Guid,
            FullName = student.FullName,
            Email = student.Email,
            Phone = student.Phone,
            Address = student.Address,
            GroupName = student.StudentGroups.Select(group => group.Group.GroupName).FirstOrDefault(),
            CourseName = student.StudentCourses.Select(course => course.Course.CourseName).FirstOrDefault()
        }).ToListAsync();
    }
    
    // Adding A Student
    [HttpPost]
    public async Task<ActionResult<Student>> PostStudent(StudentCreateDto studentDto)
    {
        var student = new Student
        {
            Guid = Guid.NewGuid().ToString(),
            FullName = studentDto.FullName,
            Email = studentDto.Email,
            Phone = studentDto.Phone,
            Address = studentDto.Address
        };

        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        return CreatedAtAction("PostStudent", new { id = student.Guid }, student);
    }
    
    // Assign Student To Group and Course
    [HttpPost]
    [Route("AddToGroup")]
    public async Task<ActionResult<StudentGroupResultDto>> AddStudentToGroup(StudentGroupAddDto studentGroupDto)
    {
        var group = await _context.Groups
            .SingleOrDefaultAsync(g => g.Id == studentGroupDto.GroupId);
        if (group == null)
        {
            return NotFound();
        }

        var studentGroup = new StudentGroup
        {
            StudentGuid = studentGroupDto.StudentGuid,
            GroupId = studentGroupDto.GroupId,
        };

        _context.StudentGroups.Add(studentGroup);

        // Use the CourseId from the Group to create the StudentCourse
        var studentCourse = new StudentCourse
        {
            StudentGuid = studentGroupDto.StudentGuid,
            CourseId = group.CourseId, // Set CourseId from the group
        };

        _context.StudentCourses.Add(studentCourse);
        await _context.SaveChangesAsync();

        var result = new StudentGroupResultDto
        {
            StudentGuid = studentGroup.StudentGuid,
            GroupId = studentGroup.GroupId
        };

        return CreatedAtAction(nameof(AddStudentToGroup), new { id = studentGroup.GroupId }, result);
    }


}