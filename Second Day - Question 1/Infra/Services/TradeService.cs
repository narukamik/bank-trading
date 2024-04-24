using bank_trading.Domain;
using bank_trading.Domain.Enum;

namespace bank_trading.Infra.Services
{
    public class TradeService
    {
        public async Task<IEnumerable<Trade>> GetTradesAsync()
        {
            var trades = new List<Trade>
            {
                new Trade { Value = 2000000, ClientSector = ClientSector.Private },
                new Trade { Value = 400000, ClientSector = ClientSector.Public },
                new Trade { Value = 500000, ClientSector = ClientSector.Public }
            };

            return trades;
        }
    }
}
