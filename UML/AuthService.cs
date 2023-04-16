// AlexeyQwake Qwake

using System;

namespace UML
{
    public class AuthService
    {
        private DB_Context dbContext;

        public AuthService()
        {
            dbContext = new DB_Context("testString");
        }


        public User Registration()
        {
            Console.WriteLine("Регистрация.");
            Console.WriteLine("Введите имя: ");
            var userName = Console.ReadLine();
            Console.WriteLine("Введите логин: ");
            var userLogin = Console.ReadLine();
            Console.WriteLine("Введите пароль: ");
            var userPassword = Console.ReadLine();

            User user = new User()
            {
                Name = userName,
                Login = userLogin,
                Password = userPassword
            };
            
            var regUser = dbContext.AddUser(user);

            Console.WriteLine("Регистрация прошла успешно!");
            return regUser;
        }
        public User Authentication()
        {
            while (true)
            {
                Console.WriteLine("Авторизация.");
                Console.WriteLine("Введите логин: ");
                var userLogin = Console.ReadLine();
                Console.WriteLine("Введите пароль: ");
                var userPassword = Console.ReadLine();

                Console.WriteLine("Проверка данных.....");

                var foundUser = dbContext.GetUserByLogin(userLogin);
                if (foundUser == null)
                {
                    Console.WriteLine("Пользователь с таким логином не найден");
                    return null;
                }

                if (foundUser.Password == userPassword)
                {
                    Console.WriteLine($"Авторизация пользователя {foundUser.Name} {foundUser.Login} прошла успешно!");
                    return foundUser;
                }
                else
                {
                    Console.WriteLine("Пароль не верный! Попробуйте еще раз!");
                }
            }
        }
    }
}