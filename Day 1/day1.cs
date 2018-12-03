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
            var input = getInput("streamreader");

            int output = PartOneSolve(input);
            Debug.WriteLine("Day 1 - Part 1: " + output);

            input = getInput("int");
            int output2 = PartTwoSolve(input);
            Debug.WriteLine("Day 1 - Part 2: " + output2);

        }

        private static int PartOneSolve(StreamReader input)
        {
            int output = 0;

            while (!input.EndOfStream)
            {
                output += Convert.ToInt32(input.ReadLine());
            }
            input.Close();
            return output;
        }

        private static int PartTwoSolve(List<int> input)
        {
            int output = 0;
            HashSet<int> set = new HashSet<int>();

            while (true)
            {
                foreach (var line in input)
                {
                    output += line;

                    if (set.Contains(output))
                    {
                        return output;
                    }                 
                    else
                    {
                        set.Add(output);
                    }
                }
            }
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
