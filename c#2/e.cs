using System;

class Program
{
    static void Main(string[] args)
    {
        string playerName;
        int playerScore = 0;

        Console.WriteLine("Добро пожаловать в игру!");
        
        Console.Write("Введите ваше имя: ");
        playerName = Console.ReadLine();

        Console.WriteLine($"Привет, {playerName}!");
        Console.WriteLine("Цель игры - набрать как можно больше очков, отвечая на вопросы.");
        Console.WriteLine();

        while (true)
        {
            Console.WriteLine("Выберите одну из следующих категорий:");
            Console.WriteLine("1. Математика");
            Console.WriteLine("2. История");
            Console.WriteLine("3. География");
            Console.WriteLine("4. Выход");
            
            Console.Write("Введите номер категории: ");
            int category = Convert.ToInt32(Console.ReadLine());

            if (category == 4)
            {
                Console.WriteLine("Игра завершена. Ваш счет: " + playerScore);
                break;
            }

            Console.WriteLine("Вопрос: ");

            string question;
            string correctAnswer;
            
            switch (category)
            {
                case 1:
                    question = "Сколько будет 2+2?";
                    correctAnswer = "4";
                    break;
                case 2:
                    question = "В каком году произошла Великая Октябрьская социалистическая революция в России?";
                    correctAnswer = "1917";
                    break;
                case 3:
                    question = "Какая столица Франции?";
                    correctAnswer = "Париж";
                    break;
                default:
                    Console.WriteLine("Некорректный выбор категории.");
                    continue;
            }

            Console.WriteLine(question);
            Console.Write("Введите ваш ответ: ");
            string answer = Console.ReadLine();

            if (answer == correctAnswer)
            {
                playerScore += 10;
                Console.WriteLine("Правильно! Вы получаете 10 очков.");
            }
            else
            {
                Console.WriteLine("Неправильно. Правильный ответ: " + correctAnswer);
            }

            Console.WriteLine("Ваш счет: " + playerScore);
            Console.WriteLine();
        }

        Console.WriteLine("Спасибо за игру, " + playerName + "!");

        Console.ReadLine();
    }
}