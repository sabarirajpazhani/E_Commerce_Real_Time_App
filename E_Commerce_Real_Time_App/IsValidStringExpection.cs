using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_RealTime_App
{
    internal class IsValidStringExpection : Exception
    {
        public IsValidStringExpection(string message) : base(message) { }
    }
}