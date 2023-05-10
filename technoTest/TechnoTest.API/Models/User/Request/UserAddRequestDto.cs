using System.ComponentModel.DataAnnotations;
using technoTest.API.Models.UserGroup.Response;
using technoTest.API.Models.UserState.Response;

namespace technoTest.API.Models.User.Request
{
    public class UserAddRequestDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int UserGroupId { get; set; }
    }
}
