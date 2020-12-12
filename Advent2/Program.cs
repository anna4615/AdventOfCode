using System;
using System.IO;
using System.Linq;

namespace Advent2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] linesFromFile = File.ReadAllLines("PasswordFile.txt");

            //int validPassword1 = CountValidPasswords1(linesFromFile);
            //Console.WriteLine($"Number of valid passwords is {validPassword1}");

            //Console.WriteLine("\n-----------------------------------------------------------------------------------\n");

            int validPassword1UsingLinq = CountValidPasswords1UsingLinq(linesFromFile);
            Console.WriteLine($"Number of valid passwords is {validPassword1UsingLinq}");

            Console.WriteLine("\n-----------------------------------------------------------------------------------\n");
            int validPassword2 = CountValidPasswords2(linesFromFile);
            Console.WriteLine($"Number of valid passwords in second method is {validPassword2}");
        }

        private static int CountValidPasswords1UsingLinq(string[] lines)
        {
            int min = 0;
            int max = 0;
            string letterToCount = "";
            int matchingChar = 0;
            int validPassword = 0;

            foreach (var line in lines)
            {
                var itemsInline = line.Split(" ");

                for (int i = 0; i < 3; i++)
                {
                    if (i == 0)
                    {
                        var minMaxString = itemsInline[i].Split("-");
                        min = int.Parse(minMaxString[0]);
                        max = int.Parse(minMaxString[1]);
                    }
                    if (i == 1)
                    {
                        letterToCount = itemsInline[1].Trim(':');
                    }
                    if (i == 2)
                    {
                        char[] chars = itemsInline[2].ToCharArray();

                        matchingChar = chars
                            .Where(c => c.ToString() == letterToCount)
                            .Count();
                    }
                }

                if (matchingChar >= min && matchingChar <= max)
                {
                    foreach (var word in itemsInline)
                    {
                        Console.Write($"{word}, ");
                    }
                    Console.WriteLine();
                    validPassword++;
                }
            }
            return validPassword;
        }

        private static int CountValidPasswords2(string[] lines)
        {
            int firstPosition = 0;
            int secondPosition = 0;
            string letterToFind = "";
            int matchingChar = 0;
            int validPassword = 0;

            foreach (var line in lines)
            {
                var itemsInline = line.Split(" ");

                for (int i = 0; i < 3; i++)
                {
                    if (i == 0)
                    {
                        var minMaxString = itemsInline[i].Split("-");
                        firstPosition = int.Parse(minMaxString[0]);
                        secondPosition = int.Parse(minMaxString[1]);
                    }
                    if (i == 1)
                    {
                        letterToFind = itemsInline[1].Trim(':');
                    }
                    if (i == 2)
                    {
                        matchingChar = 0;
                        char[] chars = itemsInline[2].ToCharArray();
                        for (int j = 0; j < chars.Length; j++)
                        {
                            if ((j == firstPosition - 1 || j == secondPosition - 1)
                                && chars[j].ToString() == letterToFind)
                            {
                                matchingChar++;
                            }
                        }
                    }
                }

                if (matchingChar == 1)
                {
                    foreach (var word in itemsInline)
                    {
                        Console.Write($"{word}, ");
                    }
                    Console.WriteLine();
                    validPassword++;
                }
            }

            return validPassword;
        }

        private static int CountValidPasswords1(string[] lines)
        {
            int min = 0;
            int max = 0;
            string letterToCount = "";
            int matchingChar = 0;
            int validPassword = 0;

            foreach (var line in lines)
            {
                var itemsInline = line.Split(" ");

                for (int i = 0; i < 3; i++)
                {
                    if (i == 0)
                    {
                        var minMaxString = itemsInline[i].Split("-");
                        min = int.Parse(minMaxString[0]);
                        max = int.Parse(minMaxString[1]);
                    }
                    if (i == 1)
                    {
                        letterToCount = itemsInline[1].Trim(':');
                    }
                    if (i == 2)
                    {
                        matchingChar = 0;
                        char[] chars = itemsInline[2].ToCharArray();
                        foreach (char letter in chars)
                        {
                            if (letter.ToString() == letterToCount)
                            {
                                matchingChar++;
                            }
                        }
                    }
                }

                if (matchingChar >= min && matchingChar <= max)
                {
                    foreach (var word in itemsInline)
                    {
                        Console.Write($"{word}, ");
                    }
                    Console.WriteLine();
                    validPassword++;
                }
            }
            return validPassword;
        }
    }
}
