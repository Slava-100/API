using AutoMapper;
using TechnoTest.BLL.Interfaces;
using TechnoTest.BLL.Models;
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
            var usersDto = await _userRepository.GetAllUsersAsync();
            var result = _mapper.Map<IEnumerable<User>>(usersDto);

            return result;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            var userEntity = _mapper.Map<UserEntity>(user);
            var callback = await _userRepository.CreateUserAsync(userEntity);
            var result = _mapper.Map<User>(callback);

            return result;
        }
    }
}
