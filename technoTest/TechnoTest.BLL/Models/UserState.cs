using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
