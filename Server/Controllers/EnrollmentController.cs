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
    public class EnrollmentController : ControllerBase
    {
        private readonly SchoolContext _context;
        public EnrollmentController(SchoolContext context)
        {
            this._context = context;
        }
    

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var enrollments = await _context.Enrollments.ToListAsync();
            return Ok(enrollments);
        }
        

        [HttpPost]
        public async Task<IActionResult> Post(Enrollment enrollment)
        {
            _context.Add(enrollment);
            await _context.SaveChangesAsync();
            return Ok(enrollment.EnrollmentID); 
        }
    }
}