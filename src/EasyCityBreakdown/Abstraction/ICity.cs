using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCityBreakdown.Abstraction
{
    public interface ICity
    {
        City Info { get; set; }
        public abstract List<Breakdown> GetBreakdowns();
        public abstract Task<List<Breakdown>> GetBreakdownsAsync();
    }
}
