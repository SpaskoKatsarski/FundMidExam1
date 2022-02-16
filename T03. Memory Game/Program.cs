using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._Memory_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> board = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            int moves = 0;

            while (input[0] != "end")
            {
                moves++;

                int firstIndex = int.Parse(input[0]);
                int secondIndex = int.Parse(input[1]);

                if (firstIndex == secondIndex || firstIndex < 0 || firstIndex >= board.Count || secondIndex < 0 || secondIndex >= board.Count)
                {
                    board.Insert(board.Count / 2, $"-{moves}a");
                    board.Insert(board.Count / 2, $"-{moves}a");

                    Console.WriteLine("Invalid input! Adding additional elements to the board");

                    input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
                    continue;
                }

                CheckIfElementsAreMatching(board, firstIndex, secondIndex);

                if (board.Count == 0)
                {
                    Console.WriteLine($"You have won in {moves} turns!");
                    return;
                }

                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            }

            Console.WriteLine($"Sorry you lose :(\n{string.Join(' ', board)}");
        }

        static void CheckIfElementsAreMatching(List<string> board, int firstIndex, int secondIndex)
        {
            if (board[firstIndex] == board[secondIndex])
            {
                Console.WriteLine($"Congrats! You have found matching elements - {board[firstIndex]}!");

                // a, b, c, d
                // 1, 0

                if (Math.Max(firstIndex, secondIndex) == firstIndex)
                {
                    board.RemoveAt(secondIndex);
                    board.RemoveAt(firstIndex - 1);
                }
                else
                {
                    board.RemoveAt(firstIndex);
                    board.RemoveAt(secondIndex - 1);
                }
            }
            else if (board[firstIndex] != board[secondIndex])
            {
                Console.WriteLine("Try again!");
            }
        }
    }
}
