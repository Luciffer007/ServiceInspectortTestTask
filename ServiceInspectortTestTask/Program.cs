using System;
using System.Linq;

namespace ServiceInspectortTestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] initialArray = new int[] { 3, 1, 8, 5, 4 };
            int requiredNumber = 0;

            bool endApp = false;
            while (!endApp)
            {
                Console.Write("Press 'c' and Enter to close the app, or enter any natural number and Enter to continue: ");
                string line = Console.ReadLine();
                switch (line)
                {
                    case "c":
                        endApp = true;
                        break;
                    default:
                        try
                        {
                            requiredNumber = Int32.Parse(line);
                            if (requiredNumber < 1) throw new ArgumentException("The number is not natural");

                            // Delete large numbers and sort
                            int[] filteredArray = initialArray.Where(number => number < requiredNumber).OrderByDescending(number => number).ToArray();
                            Console.Write(canAchivedNumber(filteredArray, requiredNumber));
                            Console.WriteLine("\n");
                        }
                        catch
                        {
                            Console.Write("Error: incorrect number");
                            Console.WriteLine("\n");
                        }
                        break;
                }
            }

            return;
        }

        private static bool canAchivedNumber(int[] numbers, int requiredNumber)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > requiredNumber)
                {
                    continue;
                }

                if (numbers[i] == requiredNumber)
                {
                    return true;
                }

                if (canAchivedNumber(numbers[(i + 1)..], requiredNumber - numbers[i]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
