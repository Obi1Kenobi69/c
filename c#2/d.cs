using System;

class Program
{
    static void Main(string[] args)
    {
        string[] words = { "какашка", "говно", "фуфелмекс", "рафик", "для баланса вселенной" };
        Random random = new Random();
        string wordToGuess = words[random.Next(words.Length)];
        char[] guessedLetters = new char[wordToGuess.Length];
        int attemptsLeft = 6;

        Console.WriteLine("Добро пожаловать в "Палач"!");
        Console.WriteLine("Слово, которое нужно угадать, состоит из {0} букв.", wordToGuess.Length);
        Console.WriteLine("У вас есть {0} попыток угадать слово.", attemptsLeft);
        Console.WriteLine();

        while (true)
        {
            Console.WriteLine("Введите букву: ");
            char letter = Console.ReadKey().KeyChar;
            Console.WriteLine();

            bool guessedWrong = true;

            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if (wordToGuess[i] == letter)
                {
                    guessedLetters[i] = letter;
                    guessedWrong = false;
                }
            }

            if (guessedWrong)
            {
                attemptsLeft--;
                Console.WriteLine("Неправильная буква! Осталось попыток: {0}", attemptsLeft);
            }
            else
            {
                Console.WriteLine("Правильная буква!");
            }

            Console.WriteLine();

            Console.Write("Прогресс в слове:");
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if (guessedLetters[i] == 0)
                {
                    Console.Write("_ ");
                }
                else
                {
                    Console.Write(guessedLetters[i] + " ");
                }
            }

            Console.WriteLine();
            Console.WriteLine();

            if (attemptsLeft <= 0)
            {
                Console.WriteLine("Ты проиграл лошара ! Это было слово: {0}", wordToGuess);
                break;
            }

            if (Array.IndexOf(guessedLetters, (char)0) == -1)
            {
                Console.WriteLine("Поздравляю, вы угадали слово, мудила: {0}", wordToGuess);
                break;
            }
        }

        Console.WriteLine("Спасибо вам за игру! с вас сри хандрид бакс");
        Console.ReadLine();
    }
}