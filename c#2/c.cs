using System;

namespace TicTacToe
{
    class Program
    {
        static char[,] board = new char[3, 3]; 
        static char currentPlayer = 'X'; 
        
        static void Main(string[] args)
        {
            InitializeBoard(); 
            PlayGame();
        }

        static void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = '-';
                }
            }
        }

        static void PlayGame()
        {
            bool gameEnded = false;
            int turns = 0;

            while (!gameEnded)
            {
                Console.Clear();
                DrawBoard();

                Console.WriteLine($"Ход игрока {currentPlayer}. Введите координаты X и Y: ");
                int x = Int32.Parse(Console.ReadLine());
                int y = Int32.Parse(Console.ReadLine());

                if (IsValidMove(x, y))
                {
                    board[x, y] = currentPlayer;
                    turns++;

                    if (CheckWin())
                    {
                        gameEnded = true;
                        Console.WriteLine($"Игрок {currentPlayer} победил!");
                    }
                    else if (turns == 9)
                    {
                        gameEnded = true;
                        Console.WriteLine("Ничья!");
                    }
                    else
                    {
                        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                    }
                }
                else
                {
                    Console.WriteLine("Неверные координаты. Попробуйте еще раз.");
                }
            }

            Console.WriteLine("Игра окончена. Нажмите любую клавишу, чтобы выйти.");
            Console.ReadKey();
        }

        static void DrawBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{board[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        static bool IsValidMove(int x, int y)
        {
            if (x < 0 || x >= 3 || y < 0 || y >= 3)
            {
                return false;
            }

            if (board[x, y] != '-')
            {
                return false;
            }

            return true;
        }

        static bool CheckWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer)
                {
                    return true;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer)
                {
                    return true;
                }
            }
            if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer)
            {
                return true;
            }
            if (board[2, 0] == currentPlayer && board[1, 1] == currentPlayer && board[0, 2] == currentPlayer)
            {
                return true;
            }

            return false;
        }
    }
}