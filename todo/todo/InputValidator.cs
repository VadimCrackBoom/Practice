using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace todo
{
    public static class InputValidator
    {
        public static bool ValidateEmail(this string email)
        {
            if (string.IsNullOrWhiteSpace(email) || email == "exam@yandex.ru")
                return false;

            string emailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            return Regex.IsMatch(email, emailPattern);
        }

        public static bool ValidatePassword(this string password)
        {
            return !string.IsNullOrWhiteSpace(password) && password.Length >= 6 && password != "Введите пароль";
        }

        public static bool ValidateName(this string name)
        {
            return !string.IsNullOrWhiteSpace(name) && name.Length >= 3 && name != "Введите имя пользователя";
        }
    }
}
