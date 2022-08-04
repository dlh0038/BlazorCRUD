using BlazorCRUD.Server.Models;
using BlazorCRUD.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private ApplicationDBContext _movieContext;
        public MovieController(ApplicationDBContext movieContext)
        {
            _movieContext =movieContext;
        }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var movies = await _movieContext.Movies.ToListAsync();
        return Ok(movies);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Movie movie)
    {
        _movieContext.Add(movie);
        await _movieContext.SaveChangesAsync();
        return Ok(movie.Title); 
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var movie = new Movie { ID = id };
        _movieContext.Remove(movie);
        await _movieContext.SaveChangesAsync();
        return NoContent();
    }
    }
}