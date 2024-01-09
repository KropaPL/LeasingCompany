using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeasingCompany.Driver
{
    internal class CustomerDriver : IDriver
    {
        public decimal Rating { get; set; }

        public CustomerDriver(decimal rating) 
        {
            Rating = rating;
        }



    }
}
