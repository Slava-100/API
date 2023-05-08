
using TechnoTest.Core.Enums;

namespace TechnoTest.BLL.Models
{
    public class UserGroup
    {
        public int Id { get; set; }
        public GroupStatus Code { get; set; }
        public string Description { get; set; }
    }
}
