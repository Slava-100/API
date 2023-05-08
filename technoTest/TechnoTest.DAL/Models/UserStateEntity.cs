using System.ComponentModel.DataAnnotations;
using TechnoTest.Core.Enums;

namespace TechnoTest.DAL.Models
{
    public class UserStateEntity
    {
        [Key]
        public int Id { get; set; }
        public StateStatus Code { get; set; }
        public string? Description { get; set; }
    }
}
