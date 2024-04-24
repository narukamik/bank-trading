
using bank_trading.Domain.Enum;
using System.Globalization;

namespace bank_trading.Domain
{
    public class Trade
    {
        public Trade(string inputFormattedTrade, DateTime referenceDate)
        {
            var tradeData = inputFormattedTrade.Split(" ");
            Value = double.Parse(tradeData[0]);
            ClientSector = tradeData[1] == "Public" ? ClientSector.Public : ClientSector.Private;
            NextPaymentDate = DateTime.Parse(tradeData[2], CultureInfo.InvariantCulture);
            
            var daysSincePaymentExpired = (int) (referenceDate - NextPaymentDate).TotalDays;
            DaysSincePaymentExpired = Math.Max(0, daysSincePaymentExpired); // if negative, set to 0
        }

        public double Value { get; set; }
        public ClientSector ClientSector { get; set; }
        public DateTime NextPaymentDate { get; set; } 

        private int DaysSincePaymentExpired { get; set; }
        public string TradeCategory
        {
            get
            {
                if (_tradeCategory is null)
                    _tradeCategory = GetTradeCategory();

                return _tradeCategory;
            }
        }
        private string? _tradeCategory { get; set; }

        private string GetTradeCategory()
        {
            if (DaysSincePaymentExpired > 30)
                return "EXPIRED";

            if (ClientSector == ClientSector.Private)
            {
                if (Value > 1000000)
                    return TradeRisk.HIGHRISK;
                else
                    return TradeRisk.UNKNOWNRISK;
            }
            else if (ClientSector == ClientSector.Public)
            {
                if (Value > 1000000)
                    return TradeRisk.MEDIUMRISK;
                else
                    return TradeRisk.UNKNOWNRISK;
            }
            else // There is no other scenario. This is only here for readability.
            {
                return TradeRisk.UNKNOWNRISK;
            }
        }
    }
}