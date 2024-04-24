using bank_trading.Domain.Enum;
using bank_trading.Domain;
using bank_trading.Domain.Services;
using System.Globalization;

public class Program
{
    private static void Main(string[] args)
    {
        var trades = GetConsoleInput();

        Run(trades);

        Console.WriteLine("\nEnd of process! Press a key to kill the console.\n");
        Console.ReadKey();
    }

    private static IEnumerable<Trade> GetConsoleInput()
    {
        bool referenceDateSuccess;
        bool numberOfTradesSuccess;
        bool addingTrades = true;
        DateTime referenceDate;
        var trades = new List<Trade>();

        do
        {
            Console.WriteLine("Type the reference date (ex: 12/11/2020)");
            var referenceDateInput = Console.ReadLine();

            referenceDateSuccess = DateTime.TryParse(referenceDateInput, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out referenceDate);
        } while (!referenceDateSuccess);

        do
        {
            Console.WriteLine("Type the number of trades in the porfolio (ex: 4)");
            var numberOfTrades = Console.ReadLine();
            numberOfTradesSuccess = int.TryParse(numberOfTrades, out int tradesCount);
        } while (!numberOfTradesSuccess);

        do
        {
            Console.WriteLine("Type the trades in the following format: Value ClientSector NextPaymentDate (ex: 2000000 Private 12/29/2025)");
            var tradeInput = Console.ReadLine();

            if (tradeInput is null)
            {
                Console.WriteLine("Invalid trade. Please type the trade in the correct format.");
                continue;
            }

            var trade = new Trade(tradeInput, referenceDate);
            trades.Add(trade);

            Console.WriteLine("Do you want one more trade? Y/N");
            var answer = Console.ReadLine();

            if (answer is null)
                Console.WriteLine("Invalid answer. Please type Y or N.");

            if (answer.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                continue;
            else if (answer.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                addingTrades = false;
            else
                Console.WriteLine("Invalid answer. Please type Y or N.");
        } while (addingTrades);

        return trades;
    }

    public static void Run(IEnumerable<Trade> trades)
    {
        foreach (var trade in trades)
        {
            Console.WriteLine(trade.TradeCategory);
        }
    }
}

