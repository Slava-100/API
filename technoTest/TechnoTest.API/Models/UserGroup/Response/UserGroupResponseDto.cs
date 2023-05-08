using TechnoTest.Core.Enums;

namespace technoTest.API.Models.UserGroup.Response
{
    public class UserGroupResponseDto
    {
        public int Id { get; set; }
        public GroupStatus Code { get; set; }
        public string Description { get; set; }
    }
}
