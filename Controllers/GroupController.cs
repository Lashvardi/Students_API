using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Students_APP.Data;
using Students_APP.Models;
using Students_APP.DTOs;
namespace Students_APP.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupController : Controller
{
    private readonly DataContext _context;

    public GroupController(DataContext context)
    {
        _context = context;
    }
    
    // Get All Groups With Course Name
    [HttpGet]
    [Route("WithCourseName")]
    public async Task<ActionResult<IEnumerable<GroupGetDto>>> GetGroups()
    {
        return await _context.Groups
            .Include(group => group.Course) // Include the Course navigation property
            .Select(group => new GroupGetDto
            {
                GroupId = group.Id,
                GroupName = group.GroupName,
                CourseId = group.CourseId,
                CourseName = group.Course.CourseName // Include the CourseName property from the Course entity
            })
            .ToListAsync();
    }
    
    // Get All Groups With Students And Course Names
    [HttpGet]
    [Route("WithStudents")]
    public async Task<ActionResult<IEnumerable<GroupWithStudents>>> GetGroupsWithStudents()
    {
        return await _context.Groups
            .Include(group => group.Course)
            .Include(group => group.StudentGroups)
            .ThenInclude(studentGroup => studentGroup.Student)
            .Select(group => new GroupWithStudents
            {
                GroupId = group.Id,
                GroupName = group.GroupName,
                CourseId = group.CourseId,
                CourseName = group.Course.CourseName,
                Students = group.StudentGroups.Select(studentGroup => new StudentGetDto
                {
                    Guid = studentGroup.Student.Guid,
                    FullName = studentGroup.Student.FullName,
                    Email = studentGroup.Student.Email,
                    Phone = studentGroup.Student.Phone,
                    Address = studentGroup.Student.Address,
                    GroupName = studentGroup.Group.GroupName,
                    CourseName = studentGroup.Group.Course.CourseName
                }).ToList()
            })
            .ToListAsync();
    }
    
    
    // Adding Group With Course
    [HttpPost]
    [Route("CreateWithCourse")]
    public async Task<ActionResult<Group>> PostGroup(GroupCreateDto groupDto)
    {
        var group = new Group
        {
            GroupName = Group.GenerateGroupName(),
            CourseId = groupDto.CourseId,
        };

        _context.Groups.Add(group);
        await _context.SaveChangesAsync();

        return CreatedAtAction("PostGroup", new { id = group.Id }, group);
    }



}