using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_RealTime_App
{
    internal class Exceptions : Exception
    {
        public Exceptions(string message) : base(message) { }
    }
    internal class IsNullExpection : Exception
    {
        public IsNullExpection(string message) : base(message) { }
    }
    internal class IsValidStringExpection : Exception
    {
        public IsValidStringExpection(string message) : base(message) { }
    }
}