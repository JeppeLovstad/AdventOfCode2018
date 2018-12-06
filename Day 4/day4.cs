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
        private const string V = "Day 4 - Part 1: ";
        private const string V1 = "Day 4 - Part 2: ";

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
            List<object[]> logs = new List<object[]>();
            List<object[]> days = new List<object[]>();
            List<string[]> awoken = new List<string[]>();

            foreach (var line in input)
            {

                object[] objArr = new object[4]; 
                var log = line.Split(' ');
                int month = Convert.ToInt32(log[0].Substring(0, 2));
                int day = Convert.ToInt32(log[0].Substring(2, 2));
                int time = Convert.ToInt32(log[1]);
                int daysInMonth = DateTime.DaysInMonth(1518, month);

                if (time > 60)
                {
                    //objArr[2] = time - 2360;
                    objArr[2] = -1;
                    if (day + 1 > daysInMonth)
                    {
                        objArr[0] = 01;
                        objArr[1] = month + 1;
                    }
                    else
                    {
                        objArr[0] = day + 1;
                        objArr[1] = month;
                    }
                    
                }
                else
                {
                    objArr[0] = day;
                    objArr[1] = month;
                    objArr[2] = time;
                    

                }
                objArr[3] = log[2];

                logs.Add(objArr);
            }

            Dictionary<int, List<object[]>> e = new Dictionary<int, List<object[]>>();
            foreach (var log in logs)
            {
                int key = Convert.ToInt32(Convert.ToString((int)log[0]) + Convert.ToString((int)log[1]));
                /*
                if ((int)log[0] > 10)
                {
                }
                else
                {
                    key = (int)log[0] * 1000 + (int)log[1];
                }*/

                if (e.ContainsKey(key))
                {
                    e[key].Add(log);
                }
                else
                {
                    List<object[]> list = new List<object[]>();
                    list.Add(log);
                    e.Add(key, list);
                }
            }

            Dictionary<int, Dictionary<int, int>> GuardToSleepMinutes = new Dictionary<int, Dictionary<int, int>>();
            foreach (var day in e.Keys)
            {
                var a = e[day].OrderBy(x => x[2]).ToList();

                int GuardID = Convert.ToInt32(((string)a[0][3]).Substring(1));
                a.Remove(a[0]);

                if (!GuardToSleepMinutes.ContainsKey(GuardID))
                {
                    GuardToSleepMinutes.Add(GuardID, new Dictionary<int, int>() { });
                }


                for (int i = 0; i < a.Count; i = i+2)
                {
                    int rangeStart = (int)a[i][2];
                    int rangeCount = (int)a[i + 1][2] - rangeStart;
                    IEnumerable<int> range = Enumerable.Range(rangeStart, rangeCount);

                    foreach (var num in range)
                    {
                        if(GuardToSleepMinutes[GuardID].ContainsKey(num))
                        {
                            GuardToSleepMinutes[GuardID][num]++;
                        }
                        else
                        {
                            GuardToSleepMinutes[GuardID].Add(num, 1);
                        }
                    }

                }
            }

            Dictionary<int, int> MostSleepy = new Dictionary<int, int>();
            int maxguard = 0;
            int maxguardID = 0;
            int maxguardCount = 0;
            foreach (var guard in GuardToSleepMinutes.Keys)
            {
                int minuteCount = 0;
                foreach (var dict in GuardToSleepMinutes[guard])
                {
                    minuteCount += dict.Value;
                }

                if (minuteCount > maxguard)
                {
                    maxguard = minuteCount;
                    maxguardID = guard;
                }

                    /*var test = GuardToSleepMinutes[guard].OrderByDescending(z => z.Value).ToArray();
                    if (test.Count() != 0 && test[0].Value > maxguardCount)
                    {
                        maxguardCount = test[0].Value;
                        maxguard = test[0].Key;
                        maxguardID = guard;
                    }
                    MostSleepy.Add(guard, test[0].Key);*/
                }

            var test = GuardToSleepMinutes[maxguardID].OrderByDescending(z => z.Value).ToArray();

            return maxguardID * test[0].Key;
        }

        private static dynamic PartTwoSolve(List<String> input)
        {


            List<object[]> logs = new List<object[]>();

            foreach (var line in input)
            {

                object[] objArr = new object[4];
                var log = line.Split(' ');
                int month = Convert.ToInt32(log[0].Substring(0, 2));
                int day = Convert.ToInt32(log[0].Substring(2, 2));
                int time = Convert.ToInt32(log[1]);
                int daysInMonth = DateTime.DaysInMonth(1518, month);

                if (time > 60)
                {
                    //objArr[2] = time - 2360;
                    objArr[2] = -1;
                    if (day + 1 > daysInMonth)
                    {
                        objArr[0] = 01;
                        objArr[1] = month + 1;
                    }
                    else
                    {
                        objArr[0] = day + 1;
                        objArr[1] = month;
                    }

                }
                else
                {
                    objArr[0] = day;
                    objArr[1] = month;
                    objArr[2] = time;


                }
                objArr[3] = log[2];

                logs.Add(objArr);
            }

            Dictionary<int, List<object[]>> e = new Dictionary<int, List<object[]>>();
            foreach (var log in logs)
            {
                int key = Convert.ToInt32(Convert.ToString((int)log[0]) + Convert.ToString((int)log[1]));

                if (e.ContainsKey(key))
                {
                    e[key].Add(log);
                }
                else
                {
                    List<object[]> list = new List<object[]>();
                    list.Add(log);
                    e.Add(key, list);
                }
            }

            Dictionary<int, Dictionary<int, int>> GuardToSleepMinutes = new Dictionary<int, Dictionary<int, int>>();
            foreach (var day in e.Keys)
            {
                var a = e[day].OrderBy(x => x[2]).ToList();

                int GuardID = Convert.ToInt32(((string)a[0][3]).Substring(1));
                a.Remove(a[0]);

                if (!GuardToSleepMinutes.ContainsKey(GuardID))
                {
                    GuardToSleepMinutes.Add(GuardID, new Dictionary<int, int>() { });
                }


                for (int i = 0; i < a.Count; i = i + 2)
                {
                    int rangeStart = (int)a[i][2];
                    int rangeCount = (int)a[i + 1][2] - rangeStart;
                    IEnumerable<int> range = Enumerable.Range(rangeStart, rangeCount);

                    foreach (var num in range)
                    {
                        if (GuardToSleepMinutes[GuardID].ContainsKey(num))
                        {
                            GuardToSleepMinutes[GuardID][num]++;
                        }
                        else
                        {
                            GuardToSleepMinutes[GuardID].Add(num, 1);
                        }
                    }

                }
            }

            Dictionary<int, int> MostSleepy = new Dictionary<int, int>();
            int maxguard = 0;
            int maxguardID = 0;
            int maxguardCount = 0;
            foreach (var guard in GuardToSleepMinutes.Keys)
            {
                /*
                int minuteCount = 0;
                foreach (var dict in GuardToSleepMinutes[guard])
                {
                    minuteCount += dict.Value;
                }
                
                if (minuteCount > maxguard)
                {
                    maxguard = minuteCount;
                    maxguardID = guard;
                }
                */

                var test = GuardToSleepMinutes[guard].OrderByDescending(z => z.Value).ToArray();
                if (test.Count() != 0 && test[0].Value > maxguardCount)
                {
                    maxguardCount = test[0].Value;
                    maxguard = test[0].Key;
                    maxguardID = guard;
                }
                //MostSleepy.Add(guard, test[0].Key);
            }

            //var test = GuardToSleepMinutes[maxguardID].OrderByDescending(z => z.Value).ToArray();

            return maxguardID * maxguard;
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
