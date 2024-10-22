using BusinessObject.Model;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        public void CreateMember(ApplicationUser p) =>  ApplicationUserDAO.CreateApplicationUser(p);

        public void DeleteMember(string id) => ApplicationUserDAO.DeleteApplicationUser(id);

        public ApplicationUser FindMemberByEmail(string e) => ApplicationUserDAO.FindApplicationUserByEmail(e);

        public ApplicationUser FindMemberById(string memberId) => ApplicationUserDAO.FindApplicationUserById(memberId);

        public List<ApplicationUser> GetApplicationUser() => ApplicationUserDAO.GetApplicationUsers();

        public void UpdateMember(ApplicationUser p) => ApplicationUserDAO.UpdateApplicationUser(p);
    }
}
