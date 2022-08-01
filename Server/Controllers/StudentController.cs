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
    public class StudentController : ControllerBase
    {
        private readonly SchoolContext _context;
        public StudentController(SchoolContext context)
        {
            this._context = context;
        }
    

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await _context.Students.ToListAsync();
            return Ok(students);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            var student = await _context.Students
        .Include(s => s.Enrollments)
            .ThenInclude(e => e.Course)
        .AsNoTracking()
        .FirstOrDefaultAsync(m => m.ID == id);
        if(student == null)
        {
            return NotFound();
        }
        return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Student student)
        {
            _context.Add(student);
            await _context.SaveChangesAsync();
            return Ok(student.FirstMidName); 
        }
    }
}