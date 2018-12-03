using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Advent_of_Code
{
    class Program
    {

        static void Main(string[] args)
        {
            List<String> input = getInput("string");

            var output = PartOneSolve(input);
            Debug.WriteLine("Day 2 - Part 1: " + output);

            var output2 = PartTwoSolve(input);
            Debug.WriteLine("Day 2 - Part 2: " + output2);

        }

        private static int PartOneSolve(List<String> input)
        {
            int twos = 0;
            int threes = 0;

            foreach (var line in input)
            {
                var lettersByCount = line.ToLookup(p => p.ToString());
                var twoletters = lettersByCount.Where(p => p.Count() == 2).Select(p => p.Key).Count();
                var threeletters = lettersByCount.Where(p => p.Count() == 3).Select(p => p.Key).Count();

                twos += (twoletters > 0 ? 1 : 0);
                threes += (threeletters > 0 ? 1 : 0);
            }

            return twos * threes;
        }

        private static string PartTwoSolve(List<String> input)
        {

            string diff = "";
            foreach (var line in input)
            {
                foreach (var line2 in input)
                {
                    diff = stringDistance(line, line2);
                    if (diff != "")
                    {
                        return diff;
                    }
                }
            }


            return "";
        }

        public static string stringDistance(string stringOne, string stringTwo)
        {
            int distance = 0;
            for (int i = 0; i < stringOne.Length; i++)
            {
                distance += stringOne.Substring(i, 1) != stringTwo.Substring(i, 1) ? 1 : 0;
            }

            if (distance != 1)
                return "";

            string diff = "";
            for (int i = 0; i < stringOne.Length; i++)
            {
                diff += stringOne.Substring(i, 1) == stringTwo.Substring(i, 1) ? stringOne.Substring(i, 1) : "";
            }
            return diff;
        }

        public static dynamic getInput(String ReturnType)
        {
            string path = @"input.txt";
            string folder = Path.Combine(Environment.CurrentDirectory, path);

            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            if (ReturnType == "int")
            {
                List<int> input = new List<int>();
                while (!sr.EndOfStream)
                {
                    input.Add(Convert.ToInt32(sr.ReadLine()));
                }
                return input;

            }
            else
            {
                List<string> input = new List<string>();
                while (!sr.EndOfStream)
                {
                    input.Add(sr.ReadLine());
                }
                return input;
            }
        }
    }
}
