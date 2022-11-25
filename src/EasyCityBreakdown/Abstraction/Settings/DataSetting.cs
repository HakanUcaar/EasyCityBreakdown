using EasyCityBreakdown.Abstraction;
using Optionable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCityBreakdown
{
    public class DataSetting : IOption
    {
        public int Limit { get; set; } = 1000;
    }
}
