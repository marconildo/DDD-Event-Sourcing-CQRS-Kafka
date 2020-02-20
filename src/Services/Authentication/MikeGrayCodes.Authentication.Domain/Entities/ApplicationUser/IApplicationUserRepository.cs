using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MikeGrayCodes.Authentication.Domain.Entities.ApplicationUser
{
    public interface IApplicationUserRepository
    {
        Task Add(ApplicationUser applicationUser);
    }
}
