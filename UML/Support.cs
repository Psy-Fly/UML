// AlexeyQwake Qwake

using System;

namespace UML
{
    public class Support
    {
        public Review CurrentReview { get; set; }
        private Developer developer;

        public Support()
        {
            developer = new Developer()
            {
                DeveloperName = "Ekaterina"
            };
        }

        public void SendForRevision(Review review, User sender)
        {
            CurrentReview = review;

            Console.WriteLine($"Идет обработка обращения пользователя {sender.Name} {sender.Login}");

            developer.FixBug(CurrentReview);
        }
    }
}