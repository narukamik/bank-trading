using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_trading.Domain.Services
{
    public interface ITradeService
    {
        public Task<IEnumerable<Trade>> GetTradesAsync();
    }
}
