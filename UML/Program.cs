using System;

namespace UML
{
    class Program
    {
        private static AuthService authService;
        private static Editor editor;
        private static Support support;
        static void Main(string[] args)
        {
            authService = new AuthService();
            editor = new Editor();
            support = new Support();
            StartMenu();
            CreateOpenMenu();
        }

        public static void StartMenu()
        {
            var flag = true;
            while (flag)
            {
                Console.WriteLine();
                Console.WriteLine("Добро пожаловать в текстовый редактор!");
                Console.WriteLine("Для регистрации введите 0, Для авторизации 1");
                var symbol = Console.ReadLine();
                switch (symbol)
                {
                    case "0":
                        editor.CurrentUser = authService.Registration();
                        flag = false;
                        break;
                    case "1":
                        editor.CurrentUser = authService.Authentication();
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Ошибка, введите либо 0-1!");
                        break;
                }
            }
        }

        public static void CreateOpenMenu()
        {
            var flag = true;
            while (flag)
            {
                Console.WriteLine();
                Console.WriteLine($"Меню редактора: ");
                Console.WriteLine($"Создать файл - 0");
                Console.WriteLine($"Открыть файл - 1");
                Console.WriteLine($"Сменить пользователя - 2");
                Console.WriteLine($"Оставить отзыв - 3");
                var symbol = Console.ReadLine();
                switch (symbol)
                {
                    case "0":
                        Console.WriteLine("Введите название файла: ");
                        var fileName = Console.ReadLine();
                        Console.WriteLine("Введите расширение: ");
                        var fileExt = Console.ReadLine();
                        var createdFile = editor.CreateFile(fileName, fileExt);
                        if (createdFile != null)
                        {
                            editor.CurrentFile = createdFile;
                            FileMenu();
                        }
                        else
                        {
                            Console.WriteLine("Ошибка создания файла");
                            break;
                        }

                        Console.WriteLine($"Файл {fileName}.{fileExt} создан");
                        flag = false;
                        break;
                    case "1":
                        Console.WriteLine("Введите имя файла: ");
                        var name = Console.ReadLine();
                        var openedFile = editor.OpenFile(name);
                        if (openedFile != null)
                        {
                            editor.CurrentFile = openedFile;
                            FileMenu();
                        }
                        else
                        {
                            Console.WriteLine("Ошибка открытия файла");
                            break;
                        }

                        Console.WriteLine(
                            $"Файл {openedFile.Name}.{openedFile.Extension} открыт. Размер {openedFile.Size}.");
                        Console.WriteLine($"Содержимое: {openedFile.Content}");
                        flag = false;
                        break;
                    case "2":
                        StartMenu();
                        break;
                    case "3":
                        Console.WriteLine("Напишите ваш отзыв: ");
                        var review = Console.ReadLine();
                        editor.LeaveFeedback(review, editor.CurrentUser);
                        break;
                    default:
                        Console.WriteLine("Ошибка, введите либо 0-3!");
                        break;
                }
            }
        }

        public static void FileMenu()
        {
            var flag = true;
            while (flag)
            {
                Console.WriteLine();
                Console.WriteLine($"Меню файла {editor.CurrentFile.Name}.{editor.CurrentFile.Extension}: ");
                Console.WriteLine($"Редактировать файл - 0");
                Console.WriteLine($"Сохранить файл - 1");
                Console.WriteLine($"Показать содержимое - 2");
                Console.WriteLine($"Включить подсветку ключевых слов - 3");
                Console.WriteLine($"Переименовать файл - 4");
                Console.WriteLine($"Выйти в меню - 5");
                var symbol = Console.ReadLine();
                switch (symbol)
                {
                    case "0":
                        Console.WriteLine("Введите новый текст: ");
                        var newText = Console.ReadLine();
                        editor.EditFile(newText);
                        Console.WriteLine($"Новый текст файла {editor.CurrentFile.Name}.{editor.CurrentFile.Extension}:");
                        Console.WriteLine(editor.CurrentFile.Content);
                        break;
                    case "1":
                        editor.SaveFile();
                        break;
                    case "2":
                        Console.WriteLine($"Текст файла: {editor.CurrentFile.Content}");
                        break;
                    case "3":
                        editor.KeyWordHighlightning();
                        break;
                    case "4":
                        Console.WriteLine($"Введите новое имя файла: ");
                        editor.RenameFile(Console.ReadLine());
                        break;
                    case "5":
                        CreateOpenMenu();
                        break;
                    default:
                        Console.WriteLine("Ошибка, введите 0-5!");
                        break;
                }
            }
        }
    }
}