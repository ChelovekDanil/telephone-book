using System.Collections.Generic;
using System.Security.Policy;
using System.Windows;

namespace telephone_book
{
    public class ContextOperations
    {
        public telephone_bookEntities context = new telephone_bookEntities();
        public ContextOperations() { }

        public List<string> getRolesStrings()
        {
            List<string> roles = new List<string>();
            foreach (var role in context.role)
            {
                roles.Add(role.name);
            }
            return roles;
        }

        public Dictionary<string, int> getRolesTable()
        {
            Dictionary<string, int> roles = new Dictionary<string, int>();
            foreach (var role in context.role)
            {
                roles.Add(role.name, role.id);
            }
            return roles;
        }

        public bool saveUser(users user)
        {
            if (context.users.Find(user.login) != null)
            {
                MessageBox.Show("this username exist. Enter new username");
                return false;
            }
            context.users.Add(user);
            context.SaveChangesAsync();
            return true;
        }

        public users getUserByLogin(string username)
        {
            return context.users.Find(username);
        }
    }
}
