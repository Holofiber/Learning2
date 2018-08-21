using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketData.Public.Api.ExternalApi;
using NotInFire.General.Domain.Types.ValueTypes.Criterias.Push.MarketSummary;
using NotInFire.General.Domain.Types.ValueTypes.Exchange.Base;

namespace CrytoSignalTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
                MarketDataApi api = new MarketDataApi(MarketDataApi.ProductionUrl);
                api.Connect();

                var subscribResponse = await api.SubscribeOnTickerUpdates(MarketSummarySubscriptionCriteria.From(Exchanges.Binance),
                    block => { Console.WriteLine(block); });
            
            api.UnsubscribeFromTickerUpdates(subscribResponse.Id);

            var tikerBlock = await api.GetTickersBlock();
            Console.ReadLine();
           
        }
    }
}
