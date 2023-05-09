using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
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
            return _context.Users
                    .Include(x => x.UserGroup)
                    .Include(x => x.UserState)
                    .Where(x => x.UserState.Code == StateStatus.Active)
                    .ToList();
        }

        public async Task<UserEntity> CreateUserAsync(UserEntity user)
        {
            user.UserStateId = await GetIdStateActiveAsync();
            user.CreatedDate = DateTime.UtcNow;

                _context.Users.Add(user);
                _context.SaveChanges();

                return _context.Users
                        .Include(x => x.UserGroup)
                        .Include(x => x.UserState)
                        .Single(p => p.Id == user.Id);
        }

        public async Task<UserEntity> DeleteUserAsync(int userId)
        {
            UserEntity existUser = _context.Users
                .Include(x => x.UserGroup)
                .Include(x => x.UserState)
                .Single( x => x.Id == userId);

            existUser.UserStateId = await GetIdStateBlockedAsync(); 

            _context.SaveChanges();
            
            return _context.Users
                .Include(x => x.UserGroup)
                .Include(x => x.UserState)
                .Single( x => x.Id == userId);;
        }

        public async Task<bool> IsUserExistAsync(UserEntity? user = null)
        {
            int idStateActive = await GetIdStateActiveAsync();
            
            if (user is not null)
            {
                return _context.Users
                        .ToList()
                        .Exists(p => p.Login == user.Login && p.UserStateId == idStateActive);
            }
            else
            {
                if (_context.Users.ToList().Find(x => x.UserStateId == idStateActive) is not null) return true;
                else return false;
            }
            
        }

        public async Task<UserEntity> GetUserExistByIdAsync(int userId)
        {
            return _context.Users
                    .Include(x => x.UserState)
                    .Include(x => x.UserGroup)
                    .ToList()
                    .Find(p => p.Id == userId);
        }

        public async Task<int> GetIdStateBlockedAsync()
        {
            var existState = _context.UserStates
                              .ToList()
                              .Find(x => x.Code.ToString() == StateStatus.Blocked.ToString());

            if (existState is not null)
            {
                return existState.Id;
            }
            else
            {
                throw new ObjectNotExistException("UserState c статусом Blocked не внесён в таблицу");
            }
        }

        public async Task<int> GetIdStateActiveAsync()
        {
            var existState = _context.UserStates
                              .ToList()
                              .Find(x => x.Code.ToString() == StateStatus.Active.ToString());

            if (existState is not null)
            {
                return existState.Id;
            }
            else
            {
                throw new ObjectNotExistException("UserState c статусом Active не внесён в таблицу");
            }
        }

        public async Task<int> GetIdGroupAdminAsync()
        {
            var existState = _context.UserGroups
                              .ToList()
                              .Find(x => x.Code.ToString() == GroupStatus.Admin.ToString());

            if (existState is not null)
            {
                return existState.Id;
            }
            else
            {
                throw new ObjectNotExistException("UserGroup c статусом Admin не внесён в таблицу");
            }
        }

        public async Task<int> GetIdGroupUserAsync()
        {
            var existState = _context.UserGroups
                              .ToList()
                              .Find(x => x.Code.ToString() == GroupStatus.User.ToString());

            if (existState is not null)
            {
                return existState.Id;
            }
            else
            {
                throw new ObjectNotExistException("UserGroup c статусом User не внесён в таблицу");
            }
        }

        public async Task<bool> IsAdminExistAsync()
        {
            int idGroupAdmin = await GetIdGroupAdminAsync();
            int idStateActive = await GetIdStateActiveAsync();

            return _context.Users
                    .ToList()
                    .Any(x => x.UserGroupId == idGroupAdmin && x.UserStateId == idStateActive);
        }
    }
}
