using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_RealTime_App.Exceptions
{
    internal class IsNullExpection : Exception
    {
        public IsNullExpection(string message) : base(message) { }
    }
}