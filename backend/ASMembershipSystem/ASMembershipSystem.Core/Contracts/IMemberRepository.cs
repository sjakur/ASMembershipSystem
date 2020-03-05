using System.Collections.Generic;
using ASMembershipSystem.Core.Domain;

namespace ASMembershipSystem.Core.Contracts
{
    public interface IMemberRepository
    {
        void Add(Member member);
        void Update(Member member);
        Member GetById(int id);
        List<Member> GetAll();
    }
}