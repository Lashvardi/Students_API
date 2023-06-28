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
    
    // Assign Student To Group
    [HttpPost]
    [Route("AddToGroup")]
    public async Task<ActionResult<StudentGroup>> AddStudentToGroup(StudentGroupAddDto studentGroupDto)
    {
        var studentGroup = new StudentGroup
        {
            StudentGuid = studentGroupDto.StudentGuid,
            GroupId = studentGroupDto.GroupId
        };

        _context.StudentGroups.Add(studentGroup);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(AddStudentToGroup), new { id = studentGroup.GroupId }, studentGroup);
    }
}