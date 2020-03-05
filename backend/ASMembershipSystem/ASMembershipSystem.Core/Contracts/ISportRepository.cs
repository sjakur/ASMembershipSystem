using ASMembershipSystem.Core.Domain;
using System.Collections.Generic;

namespace ASMembershipSystem.Core.Contracts
{
    public interface ISportRepository
    {
        List<Sport> GetAll();
    }
}