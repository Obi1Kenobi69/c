using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Добро пожаловать в игру 'Удар по крысе'!");
        
        Random random = new Random();
        int targetPosition = random.Next(1, 11);
        int score = 0;
        bool gameOver = false;

        while (!gameOver)
        {
            Console.Write("Выберите позицию (1-10): ");
            string input = Console.ReadLine();
            int position;

            if (!int.TryParse(input, out position) || position < 1 || position > 10)
            {
                Console.WriteLine("Неправильный ввод! Введите число от 1 до 10.");
                continue;
            }

            if (position == targetPosition)
            {
                score++;
                Console.WriteLine("Попадание! Вы набрали 1 очко.");
            }
            else
            {
                Console.WriteLine("Промах!");
            }

            Console.WriteLine($"Текущий счёт: {score}");
            Console.WriteLine();

            Console.Write("Продолжить игру? (да/нет): ");
            string continueInput = Console.ReadLine();

            if (continueInput.ToLower() != "да")
            {
                gameOver = true;
            }
        }

        Console.WriteLine("Игра завершена! Ваш итоговый счёт: " + score);
    }
}