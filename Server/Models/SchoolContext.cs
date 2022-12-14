using BlazorCRUD.Shared.ContosoUniversityModels;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUD.Server.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        //skip overridden entity names specifying singular table names in the DbContext
    }
}