using AutoMapper;
using System.ComponentModel.DataAnnotations;
using TechnoTest.BLL.Interfaces;
using TechnoTest.BLL.Models;
using TechnoTest.Core.CustomExceptions;
using TechnoTest.DAL.Interfaces;
using TechnoTest.DAL.Models;

namespace TechnoTest.BLL
{
    public class UserManager : IUserManager
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserManager(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            if (!await _userRepository.IsUserExistAsync())
            {
                throw new ObjectNotExistException("Список пользователей пуст");
            }

            var usersEntity = await _userRepository.GetAllUsersAsync();
            var result = _mapper.Map<IEnumerable<User>>(usersEntity);

            return result;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            var userEntity = _mapper.Map<UserEntity>(user);

            int idGroupAdmin = await _userRepository.GetIdGroupAdminAsync();
            int idGroupUser = await _userRepository.GetIdGroupUserAsync();

            if (await _userRepository.IsUserExistAsync(userEntity))
            {
                throw new RepetativeActionException($"Пользователь с таким Login:{user.Login} уже существует");
            }
            
            if (await _userRepository.IsAdminExistAsync() && user.UserGroupId == idGroupAdmin)
            {
                throw new RepetativeActionException($"UserGroupId:{user.UserGroupId} - Admin уже существует");
            }
                
            if (user.UserGroupId != idGroupAdmin && user.UserGroupId != idGroupUser)
            {
                throw new ValidationException($"UserGroupId имеет значения {idGroupAdmin}:Admin и {idGroupUser}:User. {user.UserGroupId}:Ошибка");
            }

            var callback = await _userRepository.CreateUserAsync(userEntity);
            var result = _mapper.Map<User>(callback);

            return result;
        }

        public async Task<User> DeleteUserAsync(int userId)
        {
            var existUser = await _userRepository.GetUserExistByIdAsync(userId);
            if (existUser is null)
            {
                throw new ObjectNotExistException($"Пользователя с id:{userId} не существует");
            }
            else
            {
                if(existUser.UserStateId == await _userRepository.GetIdStateBlockedAsync())
                {
                    throw new RepetativeActionException($"Пользователь с id:{userId} уже и так имеет статус:Blocked");
                }
            }

            var callback = await _userRepository.DeleteUserAsync(userId);
            var result = _mapper.Map<User>(callback);

            return result;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            UserEntity userEntity = await _userRepository.GetUserExistByIdAsync(userId);
            int idStateBlocked = await _userRepository.GetIdStateBlockedAsync();

            if (userEntity is null)
            {
                throw new ObjectNotExistException($"Пользователя с id:{userId} не существует");
            }

            if (userEntity.UserStateId == idStateBlocked)
            {
                throw new ObjectNotExistException($"Пользователь с id:{userId} имеет статус:Blocked");
            }

            var result = _mapper.Map<User>(userEntity);

            return result;
        }
    }
}
