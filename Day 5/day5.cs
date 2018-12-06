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
        private const string V = "Day 5 - Part 1: ";
        private const string V1 = "Day 5 - Part 2: ";

        static void Main(string[] args)
        {
            List<String> input = getInput("string");

            var output = PartOneSolve(input);
            Debug.WriteLine(V + output);

            int output2 = PartTwoSolve(input);
            Debug.WriteLine(V1 + output2);

        }

        private static int PartOneSolve(List<String> input)
        {
            
            return 2;
        }

        private static dynamic PartTwoSolve(List<String> input)
        {


          
            return 2;
        }


        public static dynamic getInput(String ReturnType)
        {
            string path = @"input.txt";
            //string path = @"test.txt";
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
