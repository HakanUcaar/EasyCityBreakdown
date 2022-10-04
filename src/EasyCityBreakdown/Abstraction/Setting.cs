using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCityBreakdown.Abstraction
{
    public class Setting : ISetting
    {
        public int Limit { get; set; }
        public string JsonDateFormat { get; set; } = "yyyy-MM-dd HH:mm:ss";
    }
}
