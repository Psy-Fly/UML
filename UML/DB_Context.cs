// AlexeyQwake Qwake

using System;
using System.Collections.Generic;
using System.Linq;

namespace UML
{
    public class DB_Context
    {
        private readonly string DBConntctionString;

        private List<User> dataBaseObject;

        public DB_Context(string dbConntctionString)
        {
            DBConntctionString = dbConntctionString;
            dataBaseObject = new List<User>();
        }

        public User GetUserByLogin(string login)
        {
            Console.WriteLine($"Поиск пользователя по логину {login}");
            if (dataBaseObject.Exists(x => x.Login == login))
            {
                return dataBaseObject.First(x => x.Login == login);
            }

            return null;

        }

        public User AddUser(User user)
        {
            dataBaseObject.Add(user);
            
            Console.WriteLine($"Пользователь {user.Name} {user.Login} успешно добавлен");
            return user;
        }
    }
}