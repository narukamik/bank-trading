
using bank_trading.Domain.Enum;

namespace bank_trading.Domain
{
    public class Trade
    {
        public double Value { get; set; }
        public ClientSector ClientSector { get; set; }
        public string TradeCategory
        {
            get
            {
                if (_tradeCategory is null)
                    _tradeCategory = GetTradeCategory();

                return _tradeCategory;
            }
        }
        private string _tradeCategory { get; set; }

        private string GetTradeCategory()
        {
            if (ClientSector == ClientSector.Public)
            {
                if (Value >= 1000000)
                    return "MEDIUMRISK";
                else
                    return "LOWRISK";
            }
            else
            {
                if (Value >= 1000000)
                    return "HIGHRISK";
                else
                    return "LOWRISK";
            }
        }
    }
}