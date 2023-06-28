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
    
    // Retrieve All Course Names
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CourseCreateDto>>> GetCourses()
    {
        return await _context.Courses.Select(course => new CourseCreateDto
        {
            CourseName = course.CourseName,
        }).ToListAsync();
    }
    
    
    [HttpGet]
    [Route("FullInfo")]
    public async Task<ActionResult<IEnumerable<Course>>> GetFullCourseInfo()
    {
        return await _context.Courses.ToListAsync();
    }

    // Todo: Create Endpoint For Adding Group To Course And Student
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
    
}