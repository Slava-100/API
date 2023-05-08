
using TechnoTest.DAL.Models;

namespace TechnoTest.DAL.Interfaces
{
    public interface IUserRepository
    {
        public Task<IEnumerable<UserEntity>> GetAllUsersAsync();
        public Task<UserEntity> CreateUserAsync(UserEntity user);
    }
}
