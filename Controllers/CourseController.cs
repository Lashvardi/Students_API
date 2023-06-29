using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Students_APP.Data;
using Students_APP.DTOs;
using Students_APP.Models;

namespace Students_APP.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CourseController : Controller
{
    private readonly DataContext _context;

    public CourseController(DataContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    [Route("WithId")]
    public async Task<ActionResult<IEnumerable<CourseWithId>>> GetFullCourseInfo()
    {
        return await _context.Courses.Select(Course => new CourseWithId
        {
            CourseId = Course.Id,
            CourseName = Course.CourseName,
        }).ToListAsync();
    }

    // Adding Course With Course Name
    [HttpPost]
    public async Task<ActionResult<Course>> PostCourse(CourseCreateDto courseDto)
    {
        var course = new Course
        {
            CourseName = courseDto.CourseName,
        };

        _context.Courses.Add(course);
        await _context.SaveChangesAsync();

        return CreatedAtAction("PostCourse", new { id = course.Id }, course);
    }
    
    
    [HttpGet]
    [Route("WithGroups")]
    public async Task<ActionResult<IEnumerable<CourseWithGroupInfo>>> GetCoursesWithGroupInfo()
    {
        return await _context.Courses
            .Include(course => course.Groups)
            .ThenInclude(group => group.StudentGroups) // Include StudentGroups to get student count per group
            .Select(course => new CourseWithGroupInfo
            {
                CourseId = course.Id,
                CourseName = course.CourseName,
                GroupInfos = course.Groups.Select(group => new GroupNameWithId
                {
                    GroupId = group.Id,
                    GroupName = group.GroupName,
                    NumberOfStudents = group.StudentGroups.Count // Get the number of students in the group
                }).ToList()
            })
            .ToListAsync();
    }
    
    
    // Get Groups With Course Name
    [HttpGet]
    [Route("WithCourseName")]
    public async Task<ActionResult<IEnumerable<CourseWithGroupInfo>>> GetCoursesWithGroupInfoWithCourseName(string CourseName)
    {
        return await _context.Courses
            .Include(course => course.Groups)
            .ThenInclude(group => group.StudentGroups) // Include StudentGroups to get student count per group
            .Where(course => course.CourseName == CourseName)
            .Select(course => new CourseWithGroupInfo
            {
                CourseId = course.Id,
                CourseName = course.CourseName,
                GroupInfos = course.Groups.Select(group => new GroupNameWithId
                {
                    GroupId = group.Id,
                    GroupName = group.GroupName,
                    NumberOfStudents = group.StudentGroups.Count // Get the number of students in the group
                }).ToList()
            })
            .ToListAsync();
    }






}