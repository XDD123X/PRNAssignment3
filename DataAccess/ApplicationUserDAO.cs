using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ApplicationUserDAO
    {
        public static List<ApplicationUser> GetApplicationUsers()
        {
            var listApplicationUsers = new List<ApplicationUser>();
            try
            {
                using (var context = new MyStoreDBContext())
                {
                    listApplicationUsers = context.ApplicationUsers
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listApplicationUsers;
        }
        public static ApplicationUser FindApplicationUserById(string ApplicationUserId)
        {
            ApplicationUser p = new ApplicationUser();
            try
            {
                using (var context = new MyStoreDBContext())
                {
                    p = context.ApplicationUsers
                        .SingleOrDefault(x => x.Id.Equals(ApplicationUserId));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return p;
        }
        public static ApplicationUser FindApplicationUserByEmail(string email)
        {
            ApplicationUser p = new ApplicationUser();
            try
            {
                using (var context = new MyStoreDBContext())
                {
                    p = context.ApplicationUsers
                        .SingleOrDefault(x => x.Email.Equals(email));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return p;
        }
        public static void CreateApplicationUser(ApplicationUser p)
        {
            try
            {
                using (var context = new MyStoreDBContext())
                {
                    context.ApplicationUsers.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void UpdateApplicationUser(ApplicationUser p)
        {
            try
            {
                using (var context = new MyStoreDBContext())
                {
                    context.Entry<ApplicationUser>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void DeleteApplicationUser(String id)
        {
            try
            {
                using (var context = new MyStoreDBContext())
                {
                    var ApplicationUser = context.ApplicationUsers
                        .SingleOrDefault(x => x.Id.Equals(id));

                    if (ApplicationUser != null)
                    {
                        context.ApplicationUsers.Remove(ApplicationUser);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("ApplicationUser not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
