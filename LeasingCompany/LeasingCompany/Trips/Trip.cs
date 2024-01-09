using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeasingCompany.Trips
{
    internal class Trip : ITrip
    {
        public int Duration { get; set; }
        public int Distance { get; set; }
        public Trip(int duration, int distance)
        {
            Duration = duration;
            Distance = distance;
        }

            
    }
}
