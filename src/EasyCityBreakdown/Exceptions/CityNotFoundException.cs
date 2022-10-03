using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCityBreakdown.Exceptions
{
    public class CityNotFoundException : Exception
    {
        public CityNotFoundException() : base($"City not found")
        {

        }
    }
}
