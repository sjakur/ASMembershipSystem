using ASMembershipSystem.Core.Domain;
using System.Collections.Generic;

namespace ASMembershipSystem.Core.Services
{
    public interface ISportService
    {
        List<Sport> GetAllSports();
    }
}