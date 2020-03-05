using ASMembershipSystem.Core.Contracts;
using ASMembershipSystem.Core.Domain;
using System.Collections.Generic;

namespace ASMembershipSystem.Core.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public void AddMember(Member member)
        {
            _memberRepository.Add(member);
        }

        public Member GetMemberById(int id)
        {
            return _memberRepository.GetById(id);
        }

        public List<Member> GetAllMembers()
        {
            return _memberRepository.GetAll();
        }

        public void UpdateMember(Member member)
        {
            _memberRepository.Update(member);
        }
    }
}
