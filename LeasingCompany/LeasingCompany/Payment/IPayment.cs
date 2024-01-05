using LeasingCompany.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeasingCompany.Payment
{
    internal interface IPayment
    {
        IVehicle Vehicle { get; set; }
        decimal Cal
    }
}
