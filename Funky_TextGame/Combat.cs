using System;
using System.Threading;
using System.Threading.Tasks.Dataflow;

namespace Funky_TextGame
{
    public class CombatSequence

    {
        static int playerX = 6;
        static int playerY = 1;
        static char[,] gameGrid = new char[24, 12]; // Example 12x12 grid to accommodate the border
        public static void CombatStart()

        {

            Thread playerStats = new Thread(DisplayStats);
            Thread GameBoard = new Thread(DisplayBoard);

            GameBoard.Start();
            playerStats.Start();
            playerStats.Join();
            GameBoard.Join();

        }

        static void DisplayStats()

        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Things go in here");
        }
        static void DisplayBoard()


        {
            InitializeGameGrid();
            PrintGameGrid();
           
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                // Update player position based on input
                if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    MovePlayer(-2, 0);
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    MovePlayer(2, 0);
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    MovePlayer(0, -1);
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    MovePlayer(0, 1);
                }

                Console.Clear();
                PrintGameGrid();
                DisplayStats();

            }
        }

        static void InitializeGameGrid()
        {
          
            // Fill the grid with empty spaces
            for (int y = 0; y < gameGrid.GetLength(1); y++)
            {
                for (int x = 0; x < gameGrid.GetLength(0); x++)
                {
                    gameGrid[x, y] = ' ';
                }
            }

            // Create a border by setting the characters at the edges of the grid
            for (int x = 0; x < gameGrid.GetLength(0); x++)
            {
                gameGrid[x, 0] = '*';               // Top border
                gameGrid[x, gameGrid.GetLength(1) - 1] = '*'; // Bottom border
            }
            for (int y = 0; y < gameGrid.GetLength(1); y++)
            {
                gameGrid[0, y] = '*';               // Left border
                gameGrid[gameGrid.GetLength(0) - 1, y] = '*'; // Right border
            }
        }

        static void MovePlayer(int deltaX, int deltaY)
        {
            // Check boundaries and update player position
            int newX = playerX + deltaX;
            int newY = playerY + deltaY;

            if (newX >= 1 && newX < gameGrid.GetLength(0) - 1 && newY >= 1 && newY < gameGrid.GetLength(1) - 1)
            {
                playerX = newX;
                playerY = newY;
            }
        }

        static void PrintGameGrid()
        {

            Console.SetCursorPosition(0, 10);

            // Print the grid with the player character
            for (int y = 0; y < gameGrid.GetLength(1); y++)
            {
                for (int x = 0; x < gameGrid.GetLength(0); x++)
                {
                    if (x == playerX && y == playerY)
                    {
                        Console.Write('P');
                    }
                    else
                    {
                        Console.Write(gameGrid[x, y]);
                    }
                }
                Console.WriteLine();
            }
        }

    }
}