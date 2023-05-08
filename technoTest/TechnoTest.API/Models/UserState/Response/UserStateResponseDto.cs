using TechnoTest.Core.Enums;

namespace technoTest.API.Models.UserState.Response
{
    public class UserStateResponseDto
    {
        public int Id { get; set; }
        public StateStatus Code { get; set; }
        public string Description { get; set; }
    }
}
