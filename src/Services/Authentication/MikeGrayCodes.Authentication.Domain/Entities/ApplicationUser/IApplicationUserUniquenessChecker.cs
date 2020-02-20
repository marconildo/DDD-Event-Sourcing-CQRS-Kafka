using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MikeGrayCodes.Authentication.Domain.Entities.ApplicationUser
{
    public interface IApplicationUserUniquenessChecker
    {
        bool IsUnique(string email);
    }
}
