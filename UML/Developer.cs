// AlexeyQwake Qwake

using System;

namespace UML
{
    public class Developer
    {
        public string DeveloperName { get; set; }

        public void FixBug(Review review)
        {
            Console.WriteLine($"Разработчик {DeveloperName} принял обращение и начал работу.");
            Console.WriteLine($"Текст обращения: {review.Message}");
        }

        public void ReleaseUpdate()
        {
            Console.WriteLine($"Разработчик {DeveloperName} выпустил новое обновление!");
        }
    }
}