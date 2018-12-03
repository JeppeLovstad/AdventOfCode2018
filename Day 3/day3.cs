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

            }

            return twos * threes;
        }

        private static string PartTwoSolve(List<String> input)
        {

            string diff = "";
            foreach (var line in input)
            {
                
            }


            return "";
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
            else if ((ReturnType == "string"))
            {
                List<string> input = new List<string>();
                while (!sr.EndOfStream)
                {
                    input.Add(sr.ReadLine());
                }
                return input;
            }

            else
            {
                return sr;
            }
        }
    }
}
