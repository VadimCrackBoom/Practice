﻿using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Todo.Desktop
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string PasswordHash { get; set; }
    }

    public class UserRepository
    {
        private static readonly List<User> _registeredUsers = new List<User>();
        private static int _nextId = 1;


        private static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }





        public static bool RegisterUser(string name, string password)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                return false;
            }


            if (_registeredUsers.Exists(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }

            var newUser = new User
            {
                Id = _nextId++,
                Name = name,
                PasswordHash = HashPassword(password)
            };

            _registeredUsers.Add(newUser);
            return true; // Регистрация успешна
        }


        public static User AuthenticateUser(string name, string password)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            var passwordHash = HashPassword(password);
            var user = _registeredUsers.Find(u =>
                u.Name.Equals(name, StringComparison.OrdinalIgnoreCase) &&
                u.PasswordHash == passwordHash);

            return user;
        }
    }
}