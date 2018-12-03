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
        private const string V = "Day 3 - Part 1: ";
        private const string V1 = "Day 3 - Part 2: ";

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
            List<int[]> claims = new List<int[]>();
            int maxRow = 0;
            int maxCol = 0;

            foreach (var line in input)
            {
                string[] claim = line.Split(new char[] { '@', ':' }).Select(x => x.Trim()).ToArray();

                int id = Convert.ToInt32(claim[0].Substring(1));

                int colPos = Convert.ToInt32(claim[1].Split(',')[0]);
                int rowPos = Convert.ToInt32(claim[1].Split(',')[1]);

                int colAmount = Convert.ToInt32(claim[2].Split('x')[0]);
                int rowAmount = Convert.ToInt32(claim[2].Split('x')[1]);

                maxCol = Math.Max(maxCol, colPos+ colAmount);
                maxRow = Math.Max(maxRow, rowPos + rowAmount);

                claims.Add(new int[] { id, colPos, rowPos, colAmount, rowAmount });

                
            }

            Dictionary<string, int> claimedFabric = new Dictionary<string, int>();
            int duplicatesFound = 0;
            foreach (var claim in claims)
            {
                int id = claim[0];

                int colPos = claim[1];
                int rowPos = claim[2];

                int colAmount = claim[3];
                int rowAmount = claim[4];

                for (int i = colPos; i < colPos+colAmount; i++)
                {
                    for (int j = rowPos; j < rowPos + rowAmount; j++)
                    {
                        string key = i + "," + j;
                        if (claimedFabric.ContainsKey(key))
                        {
                            if(claimedFabric[key] == 1)
                            {
                                duplicatesFound++;
                            }
                            claimedFabric[key]++;
                        }
                        else
                        {
                            claimedFabric.Add(key, 1);
                        }
                    }
                }
            }
            /*
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    if (claimedFabric.TryGetValue(j + "," + i, out int t))
                    {
                        Debug.Write(t);
                    }
                    else
                    {
                        Debug.Write(".");
                    }
                }
                Debug.WriteLine("");
            }*/


            return duplicatesFound;
        }

        private static dynamic PartTwoSolve(List<String> input)
        {

            List<int[]> claims = new List<int[]>();
            int maxRow = 0;
            int maxCol = 0;

            foreach (var line in input)
            {
                string[] claim = line.Split(new char[] { '@', ':' }).Select(x => x.Trim()).ToArray();

                int id = Convert.ToInt32(claim[0].Substring(1));

                int colPos = Convert.ToInt32(claim[1].Split(',')[0]);
                int rowPos = Convert.ToInt32(claim[1].Split(',')[1]);

                int colAmount = Convert.ToInt32(claim[2].Split('x')[0]);
                int rowAmount = Convert.ToInt32(claim[2].Split('x')[1]);

                maxCol = Math.Max(maxCol, colPos + colAmount);
                maxRow = Math.Max(maxRow, rowPos + rowAmount);

                claims.Add(new int[] { id, colPos, rowPos, colAmount, rowAmount });


            }

            Dictionary<string, int> claimedFabric = new Dictionary<string, int>();
            int idToReturn = 0;
            foreach (var claim in claims)
            {
                int id = claim[0];

                int colPos = claim[1];
                int rowPos = claim[2];

                int colAmount = claim[3];
                int rowAmount = claim[4];

                for (int i = colPos; i < colPos + colAmount; i++)
                {
                    for (int j = rowPos; j < rowPos + rowAmount; j++)
                    {
                        string key = i + "," + j;
                        if (claimedFabric.ContainsKey(key))
                        {
                            claimedFabric[key]++;
                        }
                        else
                        {
                            claimedFabric.Add(key, 1);
                        }
                    }
                }
            }

            foreach (var claim in claims)
            {
                int id = claim[0];

                int colPos = claim[1];
                int rowPos = claim[2];

                int colAmount = claim[3];
                int rowAmount = claim[4];

                bool goNext = false;

                for (int i = colPos; i < colPos + colAmount; i++)
                {
                    for (int j = rowPos; j < rowPos + rowAmount; j++)
                    {
                        string key = i + "," + j;

                        if (claimedFabric[key] > 1)
                        {
                            goNext = true;
                            break;
                        }
                    }
                    if (goNext)
                        break;
                }
                if (goNext)
                    continue;

                return id;
            }

            return -1;
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
