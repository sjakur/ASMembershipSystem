using System;
using System.Collections.Generic;
using System.Text;

namespace ASMembershipSystem.Core.Domain
{
    public class MemberSport
    {
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public int SportId { get; set; }
        public Sport Sport { get; set; }
    }
}
