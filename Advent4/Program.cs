using System;
using System.Collections;
using System.IO;

namespace Advent4
{
    class Program
    {
        static void Main(string[] args)
        {
            string allText = File.ReadAllText("passports.txt");
            //Console.WriteLine(allText);

            string[] dataSets = allText.Split(Environment.NewLine + Environment.NewLine);

            //for (int i = 0; i < dataSets.Length; i++)
            //{
            //    Console.WriteLine(dataSets[i]);
            //    Console.WriteLine();
            //}

            int validPassports = 0;
            int validByr = 0;
            int validIyr = 0;
            int validEyr = 0;
            int validHgt = 0;
            int validHcl = 0;
            int validEcl = 0;
            int validPid = 0;


            foreach (var dataSet in dataSets)
            {
                Hashtable dataToCheck = new Hashtable();
                
                string[] dataLines = dataSet.Split('\n');

                foreach (var line in dataLines)
                {
                    string[] dataPairs = line.Split(' ');

                    foreach (var dataPair in dataPairs)
                    {
                        string[] keyValue = dataPair.Split(':');
                        dataToCheck.Add(keyValue[0], keyValue[1]);

                    }
                }


                if (CheckByr(dataToCheck))
                {
                    validByr++;
                }
                if (CheckIyr(dataToCheck))
                {
                    validIyr++;
                }
                if (CheckEyr(dataToCheck))
                {
                    validEyr++;
                }
                if (CheckHgt(dataToCheck))
                {
                    validHgt++;
                }
                if (CheckHcl(dataToCheck))
                {
                    validHcl++;
                }
                if (CheckEcl(dataToCheck))
                {
                    validEcl++;
                }
                if (CheckPid(dataToCheck))
                {
                    validPid++;
                }


                if (CheckPassport(dataToCheck))
                {
                    validPassports++;
                }
            }

            //for (int i = 0; i < dataSets.Length; i++)
            //{
            //    if (dataSets[i].Contains("byr") &&
            //        dataSets[i].Contains("iyr") &&
            //        dataSets[i].Contains("eyr") &&
            //        dataSets[i].Contains("hgt") &&
            //        dataSets[i].Contains("hcl") &&
            //        dataSets[i].Contains("ecl") &&
            //        dataSets[i].Contains("pid"))
            //    {
            //        validPassports++;
            //    }
            //}

            Console.WriteLine($"Kollade pass: {dataSets.Length}");
            Console.WriteLine($"Byr: {validByr}");
            Console.WriteLine($"Iyr: {validIyr}");
            Console.WriteLine($"Eyr: {validEyr}");
            Console.WriteLine($"Hgt: {validHgt}");
            Console.WriteLine($"Hcl: {validHcl}");
            Console.WriteLine($"Ecl: {validEcl}");
            Console.WriteLine($"Pid: {validPid}");
            Console.WriteLine($"Antal giltiga pass: {validPassports}");
        }

        public static bool CheckPassport(Hashtable passport)
        {
            bool verified = false;

            if (CheckByr(passport) &&
                CheckIyr(passport) &&
                CheckEyr(passport) &&
                CheckHgt(passport) &&
                CheckHcl(passport) &&
                CheckEcl(passport) &&
                CheckPid(passport))
            {
                verified = true;
            }

            return verified;
        }

        private static bool CheckByr(Hashtable passport)
        {
            bool verified = false;

            if (passport.ContainsKey("byr") &&
                passport["byr"].ToString().Trim().Length == 4 &&
                int.TryParse(passport["byr"].ToString(), out int birthYear) &&
                birthYear >= 1920 && birthYear <= 2002)
            {
                verified = true;
            }

            return verified;
        }

        private static bool CheckIyr(Hashtable passport)
        {
            bool verified = false;

            if (passport.ContainsKey("iyr") &&
                passport["iyr"].ToString().Trim().Length == 4 &&
                int.TryParse(passport["iyr"].ToString(), out int issueYear) &&
                issueYear >= 2010 && issueYear <= 2020)
            {
                verified = true;
            }

            return verified;
        }

        private static bool CheckEyr(Hashtable passport)
        {
            bool verified = false;

            if (passport.ContainsKey("eyr") &&
                passport["eyr"].ToString().Trim().Length == 4 &&
                int.TryParse(passport["eyr"].ToString(), out int expYear) &&
                expYear >= 2020 && expYear <= 2030)
            {
                verified = true;
            }

            return verified;
        }

        private static bool CheckHgt(Hashtable passport)
        {
            bool verified = false;
            char[] trimCm = "cm".ToCharArray();
            char[] trimIn = "in".ToCharArray();

            if (passport.ContainsKey("hgt") &&
                passport["hgt"].ToString().ToLower().Trim().EndsWith("cm") &&
                int.TryParse(passport["hgt"].ToString().ToLower().Trim().Trim(trimCm), out int cm) &&
                cm >= 150 && cm <= 193)
            {
                verified = true;
            }

            else if (passport.ContainsKey("hgt") &&
                passport["hgt"].ToString().ToLower().Trim().EndsWith("in") &&
                int.TryParse(passport["hgt"].ToString().ToLower().Trim().Trim(trimIn), out int inches) &&
                inches >= 59 && inches <= 76)
            {
                verified = true;
            }

            return verified;
        }

        private static bool CheckHcl(Hashtable passport)
        {
            bool verified = false;
            string value;

            if (passport.ContainsKey("hcl"))
            {
                value = passport["hcl"].ToString().Trim();

                if (value.StartsWith('#') &&
                    value.Length == 7 &&
                    CheckChars(value))
                {
                    verified = true;
                }
            }



            return verified;
        }

        private static bool CheckEcl(Hashtable passport)
        {
            bool verified = false;

            if (passport.ContainsKey("ecl"))
            {
                switch (passport["ecl"].ToString().Trim())
                {
                    case "amb":
                    case "blu":
                    case "brn":
                    case "gry":
                    case "grn":
                    case "hzl":
                    case "oth":
                        verified = true;
                        break;
                    default:
                        break;
                }
            }

            return verified;
        }

        private static bool CheckPid(Hashtable passport)
        {
            bool verified = false;
            if (passport.ContainsKey("pid") &&
                passport["pid"].ToString().Trim().Length == 9 &&
                int.TryParse(passport["pid"].ToString().Trim(), out _))
            {
                verified = true;
            }

            return verified;
        }

        private static bool CheckChars(string value)
        {
            bool verified = false;

            char[] chars = value.ToCharArray(1, value.Length - 1);

            foreach (var c in chars)
            {
                if ((c >= 48 && c <= 57) ||
                    (c >= 'a' && c <= 'f'))
                {
                    verified = true;
                }
                else
                {
                    verified = false;
                    break;
                }
            }

            return verified;
        }
    }
}
