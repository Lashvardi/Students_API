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
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GroupGetDTO>>> GetGroups()
    {
        return await _context.Groups
            .Include(group => group.Course) // Include the Course navigation property
            .Select(group => new GroupGetDTO
            {
                GroupName = group.GroupName,
                CourseId = group.CourseId,
                CourseName = group.Course.CourseName // Include the CourseName property from the Course entity
            })
            .ToListAsync();
    }
    
    [HttpPost]
    public async Task<ActionResult<Group>> PostGroup(GroupCreateDto groupDto)
    {
        var group = new Group
        {
            GroupName = groupDto.GroupName,
            CourseId = groupDto.CourseId
        };

        _context.Groups.Add(group);
        await _context.SaveChangesAsync();

        return CreatedAtAction("PostGroup", new { id = group.Id }, group);
    }


}