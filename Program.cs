using bank_trading.Domain.Enum;
using bank_trading.Domain;
using bank_trading.Domain.Services;

public class Program
{
    private static void Main(string[] args)
    {
        var trades = new List<Trade>
        {
            new Trade { Value = 999999, ClientSector = ClientSector.Public }, // LOWRISK
            new Trade { Value = 1000000, ClientSector = ClientSector.Public }, // MEDIUMRISK
            new Trade { Value = 1000001, ClientSector = ClientSector.Public }, // MEDIUMRISK

            new Trade { Value = 999999, ClientSector = ClientSector.Private }, // LOWRISK
            new Trade { Value = 1000000, ClientSector = ClientSector.Private }, // HIGHRISK
            new Trade { Value = 1000001, ClientSector = ClientSector.Private }, // HIGHRISK
        };

        foreach (var trade in trades)
        {
            Console.WriteLine(trade.TradeCategory);
        }
    }
}