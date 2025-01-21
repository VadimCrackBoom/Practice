using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todo.Repository
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // Добавляем поле для пароля
    }

    internal class UserRepository
    {
        private List<User> users = new List<User>();
        private int nextId = 1; // Для генерации уникальных ID

        // Метод для добавления пользователя
        public User AddUser(string name, string email, string password)
        {
            var user = new User
            {
                Id = nextId++,
                Name = name,
                Email = email,
                Password = password // Установка пароля
            };
            users.Add(user);
            return user;
        }

        // Метод для получения всех пользователей
        public List<User> GetAllUsers()
        {
            return users;
        }

        // Метод для получения пользователя по ID
        public User GetUserById(int id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }

        // Метод для обновления пользователя
        public bool UpdateUser(int id, string name, string email, string password)
        {
            var user = GetUserById(id);
            if (user != null)
            {
                user.Name = name;
                user.Email = email;
                user.Password = password; // Обновление пароля
                return true;
            }
            return false;
        }

        // Метод для удаления пользователя
        public bool DeleteUser(int id)
        {
            var user = GetUserById(id);
            if (user != null)
            {
                users.Remove(user);
                return true;
            }
            return false;
        }

        public User ValidateUser(string email, string password)
        {
            {
                return users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) && u.Password == password);
            }

        }
    }
}
