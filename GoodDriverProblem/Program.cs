using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodDriverProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            const string f = "DrivingRecord.txt";

            // Declare new List.
            List<string> names = new List<string>();
            List<string> times = new List<string>();
            List<string> miles = new List<string>();

            string[] temp = new string[4];

            // Use using StreamReader for disposing.
            using (StreamReader r = new StreamReader(f))
            {
                // Use while != null pattern for loop
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    if (line.Contains("Trip"))
                    {
                        string[] info = line.Split(' ');


                        foreach (string i in info)
                        {
                            if (i != "Trip")
                            {
                                if (i.Contains(':'))
                                {
                                    
                                }
                                else if (i.Contains('.'))
                                {
                                    miles.Add(i);
                                }
                                else
                                {
                                    names.Add(i);
                                }
                            }
                        }
                    }
                }
            }
            List<string> final = new List<string> { };
            foreach (string i in names)
            {
                if (!final.Contains(i))
                {
                    final.Add(i);
                }
            }


            foreach (string s in final)
            {
                Console.WriteLine(s);
            }
            //foreach (string s in names)
            //{
            //    Console.WriteLine(s);
            //}
            //foreach (string s in miles)
            //{
            //    Console.WriteLine(s);
            //}
            //foreach (string s in times)
            //{
            //    Console.WriteLine(s);
            //}
        }
    }

    class Trip
    {
        public static double TripTime(TimeSpan StartTime, TimeSpan EndTime)
        {
            double tripTime = EndTime.Subtract(StartTime).TotalMinutes;
            return tripTime;
        }

        public static double MPH(TimeSpan start, TimeSpan end)
        {

            double time = TripTime(start, end);
            double MilesDriven = 36;
            double mph = MilesDriven / (time / 60);
            return mph;
        }
    }
}