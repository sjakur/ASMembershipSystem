using System.Collections.Generic;

namespace ASMembershipSystem.Core.Domain
{
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<MemberSport> MemberSports { get; set; }
    }
}
