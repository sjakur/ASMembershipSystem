using System.Collections.Generic;

namespace ASMembershipSystem.Core.Domain
{
    public class Sport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MemberSport> MemberSports { get; set; }
    }
}
