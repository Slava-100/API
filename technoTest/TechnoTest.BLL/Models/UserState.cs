using TechnoTest.Core.Enums;

namespace TechnoTest.BLL.Models
{
    public class UserState
    {
        public int Id { get; set; }
        public StateStatus Code { get; set; }
        public string Description { get; set; }
    }
}
