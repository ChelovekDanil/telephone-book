using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
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

        public Dictionary<string, int> getRolesTableKeyName()
        {
            Dictionary<string, int> roles = new Dictionary<string, int>();
            foreach (var role in context.role)
            {
                roles.Add(role.name, role.id);
            }
            return roles;
        }

        public Dictionary<int, string> getRolesTableKeyId()
        {
            Dictionary<int, string> roles = new Dictionary<int, string>();
            foreach (var role in context.role)
            {
                roles.Add(role.id, role.name);
            }
            return roles;
        }

        public bool saveUser(users user)
        {
            if (context.users.FirstOrDefault(u => u.login == user.login) != null)
            {
                MessageBox.Show("this username exist. Enter new username");
                return false;
            }
            context.users.Add(user);
            context.SaveChanges();
            return true;
        }


        public bool updateUser(string oldLogin, users newUser)
        {
            users user = context.users.FirstOrDefault(u => u.login == oldLogin);
            if (user == null)
            {
                MessageBox.Show("user is not founded");
                return false;
            }

            user.login = newUser.login;
            user.number = newUser.number;
            user.role_id = newUser.role_id;
            user.password = newUser.password;

            context.SaveChanges();

            return true;
        }

        public bool deleteUser(users user)
        {
            var dUser = context.users.FirstOrDefault(u => u.login == user.login);
            if (dUser == null) 
            {
                MessageBox.Show("user not founded");
                return false;
            }
            context.users.Remove(dUser);
            context.SaveChanges();
            return true;
        }

        public users getUserByLogin(string login)
        {
            return context.users.FirstOrDefault(u => u.login == login);
        }

        public List<contacts> getContacts(users user)
        {
            if (user == null)
            {
                MessageBox.Show("user not founded");
                return null;
            }
            return context.contacts.Where(u => u.user_id == user.id).ToList();
        }

        public bool createContact(contacts contact)
        {
            if (context.users.FirstOrDefault(u => u.id == contact.user_id) == null)
            {
                MessageBox.Show("user not founded");
                return false;
            }
            context.contacts.Add(contact);
            context.SaveChanges();
            return true;
        }

        public bool updateContact(contacts contact)
        {
            var dContact = context.contacts.FirstOrDefault(c => c.id == contact.id);
            if (dContact == null)
            {
                MessageBox.Show("contact not founded");
                return false;
            }
            dContact.first_name = contact.first_name;
            dContact.last_name = contact.last_name;
            dContact.number = contact.number;
            dContact.user_id = contact.user_id;

            context.SaveChanges();

            return true;
        }

        public bool deleteContact(contacts contact)
        {
            var dContact = context.contacts.FirstOrDefault(c => c.id == contact.id);
            if (dContact == null)
            {
                MessageBox.Show("contact not founded");
                return false;
            }
            context.contacts.Remove(dContact);
            context.SaveChanges();
            return true;
        }

        public bool checkRoot(users user, int accessNeed)
        {
            if (context.role.FirstOrDefault(r => r.id == user.role_id).access_level == accessNeed)  
            {
                return true;
            }
            return false;
        }
    }
}