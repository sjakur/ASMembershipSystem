using ASMembershipSystem.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASMembershipSystem.API.Models
{
    public class MemberDetailDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<SportDto> Sports { get; set; }
    }
}
