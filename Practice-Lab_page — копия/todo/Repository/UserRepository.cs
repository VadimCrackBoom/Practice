using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoEntities;

namespace todo.Repository
{
    public class UserRepository
    {
        private static List<UserModel> _users = new List<UserModel>()
        {
        //new UserModel {Email = "werty211@gmail.com",  Name = "Андрей", Password = "241024102410"}
        };
        public static UserModel CurrentUser { get; private set; }
        public UserModel GetUser(string email, string password)
        {
            return _users.FirstOrDefault(user => user.Email == email && user.Password == password);
        }

        public bool RegisterUser(string username, string useremail, string password)
        {

            if (_users.Exists(u => u.Email.Equals(useremail, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }

            var newUser = new UserModel
            {
                Name = username,
                Email = useremail,
                Password = password
            };
            _users.Add(newUser);

            //_users.Add( new UserModel { UserName = username, UserEmail = useremail, Password = password });

            CurrentUser = newUser;

            return true;
        }

        public static bool AuthenticateUser(string useremail, string username, string password)
        {
            CurrentUser = new UserModel();

            var user1 = _users.FirstOrDefault(user => user.Email == useremail && user.Password == password);

            if (user1 == null)
            {

                return false;
            }


            CurrentUser = user1;

            return true;
        }

        
    }
}
