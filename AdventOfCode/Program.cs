using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            // gör fil av input nummer, läs in till lista, konvertera till array

            //int x, y;
            //int[] numbers = new int[];'
            List<int> numbersList = new List<int>();

            foreach (var line in File.ReadLines("inputNumbers.txt"))
            {
                numbersList.Add(int.Parse(line));
            }

            foreach (var number in numbersList)
            {
                Console.WriteLine(number);
            }

            //int productOfTwo = MultiplyTwoNumbers(numbersList);
            //Console.WriteLine($"Correct answer is {productOfTwo}");

            int productOfThree = MultiplyThreeNumbers(numbersList);
            Console.WriteLine($"Correct answer is {productOfThree}");
        }

        private static int MultiplyThreeNumbers(List<int> numbersList)
        {
            bool numbersFound = false;
            int x = 0;
            int y = 0;
            int z = 0;

            foreach (int i in numbersList)
            {
                foreach (int j in numbersList)
                {
                    foreach (int k in numbersList)
                    {
                        if (i + j + k == 2020)
                        {
                            x = i;
                            y = j;
                            z = k;
                            Console.WriteLine($"{i} + {j} + {k}= {i + j + k}");
                            Console.WriteLine($"{i} * {j} * {k}= {i * j * k}");
                            numbersFound = true;
                            break;
                        }
                    }
                    if (numbersFound)
                    {
                        break;
                    }
                }
                if (numbersFound)
                {
                    break;
                }
            }
            return x * y * z;
        }

        private static int MultiplyTwoNumbers(List<int> numbersList)
        {
            bool numbersFound = false;
            int x = 0;
            int y = 0;

            foreach (int i in numbersList)
            {
                foreach (int j in numbersList)
                {
                    if (i + j == 2020)
                    {
                        x = i;
                        y = j;
                        Console.WriteLine($"{i} + {j} = {i + j}");
                        Console.WriteLine($"{i} * {j} = {i * j}");
                        numbersFound = true;
                        break;
                    }
                }
                if (numbersFound)
                {
                    break;
                }
            }
            return x * y;
        }
    }
}
