using BlazorCRUD.Server.Models;
using BlazorCRUD.Shared.ContosoUniversityModels;
//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly SchoolContext _context;
        public CourseController(SchoolContext context)
        {
            this._context = context;
        }
    

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var courses = await _context.Courses.ToListAsync();
            return Ok(courses);
        }
        

        [HttpPost]
        public async Task<IActionResult> Post(Course course)
        {
            _context.Add(course);
            await _context.SaveChangesAsync();
            return Ok(course.Title); 
        }
    }
}