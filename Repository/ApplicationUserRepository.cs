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
        public void CreateApplicationUser(ApplicationUser p) =>  ApplicationUserDAO.CreateApplicationUser(p);

        public void DeleteApplicationUser(ApplicationUser p) => ApplicationUserDAO.DeleteApplicationUser(p);

        public ApplicationUser FindApplicationUserByEmail(String email) => ApplicationUserDAO.FindApplicationUserByEmail(email);

        public ApplicationUser FindApplicationUserById(int ApplicationUserId) => ApplicationUserDAO.FindApplicationUserById(ApplicationUserId);

        public List<ApplicationUser> GetApplicationUsers() => ApplicationUserDAO.GetApplicationUsers();

        public void UpdateApplicationUser(ApplicationUser p) => ApplicationUserDAO.UpdateApplicationUser(p);
    }
}
