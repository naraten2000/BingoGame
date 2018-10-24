using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var exit = false;
            while (!exit)
            {
                WriteRule();

                var input = Console.ReadLine();
                var numbers = ParseInput(input);
                var isBingo = CheckBingo(numbers);
                Console.WriteLine(string.Format("Input:[{0}] = {1}", string.Join(",", numbers), isBingo ? "Bingo" : "Not Bingo"));
                Console.WriteLine();
                Console.WriteLine("Do you want to test again? If so, press Y, otherwist, press Enter");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();
                if (key.Key != ConsoleKey.Y)
                {
                    exit = true;
                }
            }
        }

        private static bool CheckBingo(List<int> numbers)
        {
            var boardSize = 5;
            var bingoCount = 1;
            // Sort first
            numbers.Sort();

            for (int i = 0; i < boardSize; i++)
            {
                var firstNumber = numbers[i];

                // Check horizontal
                for (int j = 1; j < boardSize; j++)
                {
                    if (numbers.Contains(firstNumber + j))
                        bingoCount++;
                }

                if (bingoCount == 5)
                    return true;


                // Check Vertical
                bingoCount = 1;
                for (int j = 1; j < boardSize; j++)
                {
                    if (numbers.Contains(firstNumber + j * boardSize))
                        bingoCount++;
                }

                if (bingoCount == 5)
                    return true;
            }

            return false;
        }

        private static List<int> ParseInput(string input)
        {
            while (!input.StartsWith("[") || !input.EndsWith("]"))
            {
                Console.WriteLine("You input is not in a correct format, please re-check and re-enter again");
                Console.WriteLine();
                input = Console.ReadLine();
            }

            var inputWithoutBlackets = input.Substring(1, input.Length - 2);
            var numbersIntext = inputWithoutBlackets.Split(',').ToList();
            var numbers = numbersIntext.Select(i => int.Parse(i)).ToList();
            return numbers;
        }

        private static void WriteRule()
        {
            Console.WriteLine("Please enter number in form of [a,b,c,...] and in the board below:");
            Console.WriteLine();
            Console.WriteLine(" 1     2    3    4    5");
            Console.WriteLine(" 6     7    8    9   10");
            Console.WriteLine("11    12   13   14   15");
            Console.WriteLine("16    17   18   19   20");
            Console.WriteLine("21    22   23   24   25");
            Console.WriteLine();
        }
    }
}
