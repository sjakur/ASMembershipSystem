using ASMembershipSystem.Core.Domain;
using System.Collections.Generic;

namespace ASMembershipSystem.Core.Services
{
    public interface IMemberService
    {
        void AddMember(Member member);
        List<Member> GetAllMembers();
        Member GetMemberById(int id);
        void UpdateMember(Member member);
    }
}