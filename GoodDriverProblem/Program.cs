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
            List<Driver> Name = new List<Driver>();

            TimeSpan time;

            // Use using StreamReader for disposing.
            using (StreamReader r = new StreamReader(f))
            {
                // Use while != null pattern for loop
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    if (line.Contains("Driver"))
                    {
                        string[] names = line.Split(' ');
                        Name.Add(new Driver { Name = names[1] });
                    }

                    if (line.Contains("Trip"))
                    {
                        string[] info = line.Split(' ');

                        time = Convert.ToDateTime(info[3]) - Convert.ToDateTime(info[2]);


                        for (int i = 0; i < Name.Count; i++)
                        {
                            if ((info[1]) == Name[i].Name)
                            {
                                Name[i].MilesDriven += double.Parse(info[4]);
                                double minutes = Convert.ToDateTime(info[3]).Subtract(Convert.ToDateTime(info[2])).TotalHours;
                                Name[i].HoursDriven += minutes;
                            }
                        }
                    }
                }
            }



            for (int i = 0; i < Name.Count; i++)
            {
                if (Name[i].MilesDriven > 0)
                {
                    Console.WriteLine(Name[i].Name + ": " + Convert.ToString(Math.Round(Name[i].MilesDriven)) + " miles @ " + Convert.ToString(Math.Round(Name[i].GetMPH()))+" MPH");
                }
                else
                {
                    Console.WriteLine(Name[i].Name + ": 0 miles");
                }
            }
        }


    }
}
