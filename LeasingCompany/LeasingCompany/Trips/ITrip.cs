﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeasingCompany.Trips
{
    internal interface ITrip
    {
        int Duration { get; set; }
        int Distance {  get; set; }
    }
}
