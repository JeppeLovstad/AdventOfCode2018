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
        private const string V = "Day 6 - Part 1: ";
        private const string V1 = "Day 6 - Part 2: ";

        static void Main(string[] args)
        {
            List<String> input = getInput("string");

            var output = PartOneSolve(input[0]);
            Debug.WriteLine(V + output);

            int output2 = PartTwoSolve(input[0]);
            Debug.WriteLine(V1 + output2);

        }

        private static int PartOneSolve(string input)
        {
            StringBuilder sb = new StringBuilder(input);

            int pos = 0;


            for (int i = 0; i < sb.Length - 1; i++)
            {
                var a = sb[i];
                var b = sb[i+1];

                if (char.ToLower(sb[i]) == char.ToLower(sb[i+1]) && ((char.IsUpper(sb[i]) && char.IsLower(sb[i+1])) || (char.IsLower(sb[i]) && char.IsUpper(sb[i+1]))))
                {
                    sb.Remove(i , 2);
                    i = Math.Max(-1, i-2);
                }
            }
            
            sb.ToString();

            return sb.ToString().Length;
        }

        private static dynamic PartTwoSolve(string input)
        {
            
            var polymers = input.ToLower().Distinct().ToArray();
            int polymerLength = int.MaxValue;

            foreach (var polymer in polymers)
            {
                StringBuilder sb = new StringBuilder(input);
                sb.Replace(polymer.ToString(), "");
                sb.Replace(polymer.ToString().ToUpper(), "");

                for (int i = 0; i < sb.Length - 1; i++)
                {
                    var a = sb[i];
                    var b = sb[i + 1];

                    if (char.ToLower(sb[i]) == char.ToLower(sb[i + 1]) && ((char.IsUpper(sb[i]) && char.IsLower(sb[i + 1])) || (char.IsLower(sb[i]) && char.IsUpper(sb[i + 1]))))
                    {
                        sb.Remove(i, 2);
                        i = Math.Max(-1, i - 2);
                    }
                }

                polymerLength = Math.Min(sb.Length, polymerLength);
            }

            return polymerLength;
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
