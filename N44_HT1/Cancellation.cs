using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N44_HT1
{
    public class Cancellation
    {
        public static async ValueTask Execute()
        {
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            try
            {
                await DownloadAsync(cts.Token);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public static async ValueTask DownloadAsync(CancellationToken cancellationToken)
        {
            for (int i = 0; i < 20; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine("Downloading cancelled");
                    return;
                }
                Console.WriteLine("Downlodaing...");
                await Task.Delay(1000, cancellationToken);
            }
        }
    }
}
