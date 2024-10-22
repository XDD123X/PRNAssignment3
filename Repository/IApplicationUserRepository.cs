using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IApplicationUserRepository
    {
        List<ApplicationUser> GetApplicationUser();

        ApplicationUser FindMemberById(string memberId);
        void CreateMember(ApplicationUser p);
        void UpdateMember(ApplicationUser p);
        void DeleteMember(string id);
        ApplicationUser FindMemberByEmail(string e);
    }
}
