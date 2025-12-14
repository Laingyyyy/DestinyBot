using DiscordBot;

namespace DestinyBot;

class Program
{
    static async Task Main(string[] args)
    {
        using var cts = new CancellationTokenSource();

        Console.CancelKeyPress += (sender, e) =>
        {
            Console.WriteLine("Stopping...");
            e.Cancel = true;
            cts.Cancel();
        };

        AppDomain.CurrentDomain.ProcessExit += (sender, e) =>
        {
            cts.Cancel();
        };
        
        var bot = new Bot();
        await bot.Run(cts.Token).ConfigureAwait(false);

        try
        {
            await Task.Delay(-1, cts.Token).ConfigureAwait(false);
        }
        catch (TaskCanceledException)
        {
            // expected shutdown
        }
    }
}