using System.ComponentModel.DataAnnotations;
using TechnoTest.Core.Enums;

namespace TechnoTest.DAL.Models
{
    public class UserGroupEntity
    {
        [Key]
        public int Id { get; set; }
        public GroupStatus Code { get; set; }
        public string? Description { get; set; }
    }
}
