// AlexeyQwake Qwake

using System;
using System.Collections.Generic;
using System.Linq;

namespace UML
{
    public class Editor
    {
        public string Name { get; set; }
        public File CurrentFile { get; set; }
        public User CurrentUser { get; set; }
        private Support support;

        private List<File> fileRepository;

        public Editor()
        {
            support = new Support();
            fileRepository = new List<File>();
        }

        public File CreateFile(string name, string extension)
        {
            var newFile = new File()
            {
                Name = name,
                Extension = extension,
                Size = 0,
                Content = ""
            };
            return newFile;
        }

        public File OpenFile(string name)
        {
            if (fileRepository.Exists(x => x.Name == name))
            {
                var foundFile = fileRepository.FirstOrDefault(x => x.Name == name);
                CurrentFile = foundFile;
                return foundFile;
            }

            Console.WriteLine("Файл не найден!");
            return null;
        }

        public void EditFile(string newContent)
        {
            CurrentFile.Content = newContent;
        }

        public void SaveFile()
        {
            
            if (fileRepository.Exists(x => x.Name == CurrentFile.Name))
            {
                var foundFile = fileRepository.FirstOrDefault(x => x.Name == CurrentFile.Name);

                foundFile.Extension = CurrentFile.Extension;
                foundFile.Size = CurrentFile.Size;
                foundFile.Content = CurrentFile.Content;
            }
            else
            {
                fileRepository.Add(CurrentFile);
            }
            Console.WriteLine($"Файл {CurrentFile.Name}.{CurrentFile.Extension} успешно сохранен");
        }

        public void KeyWordHighlightning()
        {
            Console.WriteLine("Подсветка ключевых слов активирована");
        }

        public void LeaveFeedback(string message, User sender)
        {
            Review review = new Review()
            {
                Message = message
            };
            support.SendForRevision(review, sender);
            Console.WriteLine("Ваше обращение зарегистрировано!");
        }

        public void RenameFile(string newName)
        {
            var oldName = CurrentFile.Name + "." + CurrentFile.Extension;
            var currentFile = fileRepository.FirstOrDefault(x => x.Name == CurrentFile.Name);
            currentFile.Name = newName;
            CurrentFile = currentFile;
            Console.WriteLine($"Имя файла {oldName} успешно изменено. Новое имя {currentFile.Name}.{currentFile.Extension}");
        }

        public void ChooseExtension(File file, string extension)
        {
            file.Extension = extension;
        }

        public void ShowResult(File file)
        {
            Console.WriteLine($"Файл {file.Name}.{file.Extension}. Размер {file.Size}.");
            Console.WriteLine($"Содержимое файла: {file.Content}");
        }

        public File ReturnResult()
        {
            return CurrentFile;
        }
    }
}