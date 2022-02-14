using System;
using System.Linq;

namespace T02._The_Lift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int waitingPeople = Math.Abs(int.Parse(Console.ReadLine()));
            int[] currentLiftState = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            FixArray(currentLiftState);

            int firstCountOfPeople = waitingPeople;

            for (int i = 0; i < currentLiftState.Length; i++)
            {
                for (int j = currentLiftState[i]; j < 4; j++)
                {
                    if (waitingPeople == 0 && currentLiftState[currentLiftState.Length - 1] < 4)
                    {
                        Console.WriteLine($"The lift has empty spots!\n{string.Join(' ', currentLiftState)}");
                        return;
                    }
                    else if (waitingPeople == 0)
                    {
                        Console.WriteLine(string.Join(' ', currentLiftState));
                        return;
                    }

                    currentLiftState[i]++;
                    waitingPeople--;
                }
            }

            int peopleInQueue = waitingPeople;

            if (waitingPeople == firstCountOfPeople)
            {
                peopleInQueue = firstCountOfPeople;
            }

            Console.WriteLine($"There isn't enough space! {peopleInQueue} people in a queue!\n{string.Join(' ', currentLiftState)}");
        }

        static void FixArray(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > 4)
                {
                    while (arr[i] > 4)
                    {
                        arr[i]--;
                        arr[i + 1]++;
                    }
                }
            }
        }
    }
}
