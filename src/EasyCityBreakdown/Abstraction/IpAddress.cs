using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EasyCityBreakdown.Abstraction
{
    public class IpAddress : ValueOf<string, IpAddress>
    {
        protected override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Value))
                throw new ArgumentException("Value cannot be null or empty");

            Match match = Regex.Match(Value, @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
            if (!match.Success)
            {
                throw new ArgumentException("Ip address not valid");
            }
        }
    }
}
