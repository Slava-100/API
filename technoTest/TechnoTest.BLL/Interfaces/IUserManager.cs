using TechnoTest.BLL.Models;

namespace TechnoTest.BLL.Interfaces
{
    public interface IUserManager
    {
        public Task<IEnumerable<User>> GetAllUsersAsync();
        public Task<User> CreateUserAsync(User user);
        public Task<User> DeleteUserAsync(int userId);
    }
}
