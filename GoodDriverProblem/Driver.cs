using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodDriverProblem
{
    class Driver
    {
        public string Name { get; set; }
        public double MilesDriven { get; set; }
        public double HoursDriven { get; set; }
        public int MPH { get; set; }

        public Driver()
        {
            //Default
        }

        public double GetMPH()
        {
            double mph = MilesDriven/HoursDriven;
            return mph;
        }
    }
}
