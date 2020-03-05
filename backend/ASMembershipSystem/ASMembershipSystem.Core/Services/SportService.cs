using System.Collections.Generic;
using ASMembershipSystem.Core.Contracts;
using ASMembershipSystem.Core.Domain;

namespace ASMembershipSystem.Core.Services
{
    public class SportService : ISportService
    {
        private readonly ISportRepository _sportRepository;

        public SportService(ISportRepository sportRepository)
        {
            _sportRepository = sportRepository;
        }

        public List<Sport> GetAllSports()
        {
            return _sportRepository.GetAll();
        }
    }
}
