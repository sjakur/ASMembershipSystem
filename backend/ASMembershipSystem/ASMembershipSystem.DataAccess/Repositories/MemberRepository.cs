using ASMembershipSystem.Core.Contracts;
using ASMembershipSystem.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ASMembershipSystem.DataAccess.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly ASMembershipContext _context;

        public MemberRepository(ASMembershipContext context)
        {
            _context = context;
        }

        public void Add(Member member)
        {
            var sportsIds = new HashSet<int>(member.MemberSports.Select(ms => ms.SportId));
            var validSportIds = _context.Sports.Where(s => sportsIds.Contains(s.Id))
                                               .Select(s => s.Id);

            member.MemberSports = validSportIds.Select(vid => new MemberSport
            {
                SportId = vid
            }).ToList();

            _context.Add(member);
            _context.SaveChanges();
        }

        public List<Member> GetAll()
        {
            return _context.Members.ToList();
        }

        public Member GetById(int id)
        {
            return _context.Members.Include(m => m.MemberSports)
                                   .ThenInclude(ms => ms.Sport)
                                   .SingleOrDefault(m => m.Id == id);
        }

        public void Update(Member member)
        {
            var originalMember = _context.Members
                                   .Include(m => m.MemberSports)
                                   .SingleOrDefault(m => m.Id == member.Id);

            var sportsIds = new HashSet<int>(member.MemberSports.Select(ms => ms.SportId));
            var validSportIds = _context.Sports.Where(s => sportsIds.Contains(s.Id))
                                               .Select(s => s.Id);

            originalMember.MemberSports = validSportIds.Select(vid => new MemberSport
            {
                SportId = vid
            }).ToList();

            _context.Entry(originalMember).CurrentValues.SetValues(member);

            _context.SaveChanges();
        }
    }
}
