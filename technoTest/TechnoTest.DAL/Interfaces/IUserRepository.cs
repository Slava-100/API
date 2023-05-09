
using Microsoft.EntityFrameworkCore;
using TechnoTest.Core.CustomExceptions;
using TechnoTest.DAL.Models;

namespace TechnoTest.DAL.Interfaces
{
    public interface IUserRepository
    {
        public Task<IEnumerable<UserEntity>> GetAllUsersAsync();
        public Task<UserEntity> CreateUserAsync(UserEntity user);
        public Task<bool> IsUserExistAsync(UserEntity? user = null);
        public Task<UserEntity> GetUserExistByIdAsync(int userId);
        public Task<UserEntity> DeleteUserAsync(int userId);
        public Task<int> GetIdStateBlockedAsync();
        public Task<int> GetIdStateActiveAsync();
        public Task<int> GetIdGroupAdminAsync();
        public Task<bool> IsAdminExistAsync();
        public Task<int> GetIdGroupUserAsync();
    }
}
