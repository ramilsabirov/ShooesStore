using ShooesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ShooesStore.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        public string pApplicationName;
        public override string ApplicationName
        {
            get { return pApplicationName; }
            set { pApplicationName = value; }
        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            string[] roles = new string[] { };
            using (ShoesContext shoesDb = new ShoesContext())
            {
                User user = shoesDb.Users.FirstOrDefault(u => u.Email == username);
                if (user != null)
                {
                    Role useRole = shoesDb.Roles.Find(user.RoleId);
                    if (useRole != null)
                    {
                        roles = new string[] { useRole.Name };    
                    }
                }
                  
            }
            return roles;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            bool outputResult = false;
            using (ShoesContext shoesDb = new ShoesContext())
            {
                User user = shoesDb.Users.FirstOrDefault(u => u.Email == username);
                if (user != null)
                {
                    Role useRole = shoesDb.Roles.Find(user.RoleId);
                    if (useRole != null && useRole.Name == roleName)
                    {
                        outputResult = true;
                    }
                }

            }
            return outputResult;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}