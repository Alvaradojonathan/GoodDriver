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

            // Use using StreamReader for disposing.
            using (StreamReader r = new StreamReader(f))
            {
                // Use while != null pattern for loop
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    // Build Name objects list
                    if (line.Contains("Driver"))
                    {
                        string[] names = line.Split(' ');
                        Name.Add(new Driver { Name = names[1] });
                    }

                    // Add property values to driver objects
                    if (line.Contains("Trip"))
                    {
                        string[] info = line.Split(' ');
                        for (int i = 0; i < Name.Count; i++)
                        {
                            if ((info[1]) == Name[i].Name)
                            {
                                // Assign value to MilesDriven object property
                                Name[i].MilesDriven += double.Parse(info[4]);

                                // Calculate total hours spent driving
                                double hours = Convert.ToDateTime(info[3]).Subtract(Convert.ToDateTime(info[2])).TotalHours;

                                // Assign value to HoursDriven object property
                                Name[i].HoursDriven += hours;
                            }
                        }
                    }
                }
            }

            // Sort the object list by miles driven in descending order
            var drivingRecordSorted = from entry in Name
                                      orderby entry.MilesDriven descending
                                      select entry;

            // Print every objects information to the console from Name list
            foreach (Driver i in drivingRecordSorted)
            {
                if (i.MilesDriven > 0)
                {
                    Console.WriteLine(i.Name + ": " + Math.Round(i.MilesDriven) + " miles @ " + Math.Round(i.GetMPH()) + " MPH");
                }
                else
                {
                    Console.WriteLine(i.Name + ": 0 miles");
                }
            }
        }
    }
}
