using BlazorCRUD.Shared.Models;

namespace BlazorCRUD.Server.Interfaces
{
    public interface IUser
    {
        public List<User> GetUserDetails();
        public void AddUser(User user);
        public string AddRandomUser();
        public string HashPassword(String plaintext);
        public void UpdateUserDetails(User user);
        public User GetUserData(int id);
        public void DeleteUser(int id);
    }
}