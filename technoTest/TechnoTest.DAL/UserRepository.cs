using Microsoft.EntityFrameworkCore;
using TechnoTest.Core.CustomExceptions;
using TechnoTest.Core.Enums;
using TechnoTest.DAL.Interfaces;
using TechnoTest.DAL.Models;

namespace TechnoTest.DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserEntity>> GetAllUsersAsync()
        {
            var existingUsers = _context.Users
                .Include(x => x.UserGroup)
                .Include(x => x.UserState)
                .Where(x => x.UserState.Code == StateStatus.Active)
                .ToList();

            if (existingUsers.Count > 0)
            {
                return existingUsers;
            }
            else
            {
                throw new ObjectNotExistException("Список юзеров пуст");
            }
        }

        public async Task<UserEntity> CreateUserAsync(UserEntity user)
        {
            if (_context.Users
                .ToList()
                .Find(p => p.Login == user.Login
                && p.UserState.Code == StateStatus.Active) is not null)
            {
                throw new RepetativeActionException($"Пользователь с таким Login:{user.Login} уже существует");
            }
            else
            {
                user.UserState.Code = StateStatus.Active;

                _context.Users.Add(user);
                _context.SaveChanges();

                return _context.Users.Single(p => p.Id == user.Id);
            }
        }
    }
}
