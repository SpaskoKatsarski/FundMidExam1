using System;

namespace T01._Computer_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            double sumWithoutTax = 0;
            double taxesSum = 0;
            double total = 0;

            // If there's a problem with the sums try with decimal

            while (input != "special" && input != "regular")
            {
                double currPriceWithoutTax = double.Parse(input);

                if (currPriceWithoutTax < 0)
                {
                    Console.WriteLine("Invalid price!");
                    input = Console.ReadLine();
                    continue;
                }
                else if (currPriceWithoutTax == 0)
                {
                    Console.WriteLine("Invalid order!");
                    input = Console.ReadLine();
                    continue;
                }

                sumWithoutTax += currPriceWithoutTax;
                taxesSum += 0.20 * currPriceWithoutTax;

                total += currPriceWithoutTax + 0.20 * currPriceWithoutTax;

                input = Console.ReadLine();
            }

            if (input == "special")
            {
                total *= 0.90;
            }

            if (total == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
                Console.WriteLine($"Congratulations you've just bought a new computer!\nPrice without taxes: {sumWithoutTax:f2}$\nTaxes: {taxesSum:f2}$\n-----------\nTotal price: {total:f2}$");
            }
        }
    }
}
