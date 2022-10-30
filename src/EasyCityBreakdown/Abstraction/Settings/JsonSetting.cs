using EasyCityBreakdown.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCityBreakdown
{
    public class JsonSetting : IOption
    {
        public string JsonDateFormat { get; set; } = "yyyy-MM-dd HH:mm:ss";
    }
}
