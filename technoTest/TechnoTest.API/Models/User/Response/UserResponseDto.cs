using technoTest.API.Models.UserGroup.Response;
using technoTest.API.Models.UserState.Response;

namespace technoTest.API.Models.User.Response
{
    public class UserResponseDto
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public UserGroupResponseDto UserGroup { get; set;}
        public UserStateResponseDto UserState { get; set; } 
    }
}
