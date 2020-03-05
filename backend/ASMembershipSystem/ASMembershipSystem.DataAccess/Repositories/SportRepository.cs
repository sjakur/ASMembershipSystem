using ASMembershipSystem.Core.Contracts;
using ASMembershipSystem.Core.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ASMembershipSystem.DataAccess.Repositories
{
    public class SportRepository : ISportRepository
    {
        private readonly ASMembershipContext _context;

        public SportRepository(ASMembershipContext context)
        {
            _context = context;
        }

        public List<Sport> GetAll()
        {
            return _context.Sports.ToList();
        }
    }
}
