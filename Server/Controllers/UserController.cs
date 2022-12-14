using BlazorCRUD.Server.Interfaces;
using BlazorCRUD.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCRUD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _IUser;
        public UserController(IUser iUser)
        {
            _IUser = iUser;
        }
        [HttpGet]
        public async Task<List<User>> Get()
        {
            return await Task.FromResult(_IUser.GetUserDetails());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            User user = _IUser.GetUserData(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }
        [HttpPost]
        public void Post(User user)
        {
            _IUser.AddUser(user);
        }
        [HttpPost("randomadd")]
        public string Post()
        {
            string UserName = _IUser.AddRandomUser();
            Console.WriteLine($"Created User: {UserName}");
            return UserName;
        }
        [HttpPut("updatepassword")]
        public string Put(User user, String plaintextpassword)
        {
            //string UserName = _IUser.AddRandomUser();
            string hashedPassword = _IUser.HashPassword(plaintextpassword);
            //Console.WriteLine(hashedPassword);
            user.Password = hashedPassword;
            _IUser.UpdateUserDetails(user);
            Console.WriteLine($"Updated User: {user.FirstName} {user.LastName}'s password");
            return user.FirstName;
        }
        [HttpPut]
        public void Put(User user)
        {
            _IUser.UpdateUserDetails(user);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _IUser.DeleteUser(id);
            return Ok();
        }
    }
}