using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCityBreakdown.Abstraction
{
    public class Breakdown : ValueOf<(DateTime? startDate, DateTime? endDate, string reason, string district, string region), Breakdown>, IBreakdown
    {
        public DateTime? StartDate => Value.startDate;
        public DateTime? EndDate => Value.endDate;
        public string Reason => Value.reason;
        public string District => Value.district;
        public string Region => Value.region;
    }
}
