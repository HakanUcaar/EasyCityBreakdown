using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCityBreakdown.Abstraction
{
    public interface ISetting
    {
        public int Limit { get; set; }
        public string JsonDateFormat { get; set; }
    }
}
