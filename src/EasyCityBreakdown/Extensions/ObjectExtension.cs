using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EasyCityBreakdown
{
    public static class ObjectExtension
    {
        public static void ToConsole(this object obj)
        {
            Console.WriteLine(obj.ToString());
        }
        public static void ToDebug(this object obj)
        {
            Debug.WriteLine(obj.ToString());
        }
    }
}
