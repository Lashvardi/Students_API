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
    
    

}