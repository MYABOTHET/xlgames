using Telegram.Bot;

namespace XlgamesTGBOT_DIRECT
{
    internal class Program
    {
        static TelegramBotClient bot = null!;
        static HttpClient httpClient = new HttpClient();

        async static Task Main(string[] args)
        {
            var source = args[0];
            using var cts = new CancellationTokenSource();
            bot = new TelegramBotClient(args[1], cancellationToken: cts.Token);
            int? offset = null;
            while (!cts.IsCancellationRequested)
            {
                var updates = await bot.GetUpdates(offset, timeout: 2);
                foreach (var update in updates)
                {
                    offset = update.Id + 1;
                    try
                    {
                        var id = update.CallbackQuery!.Data;
                        Dictionary<string, string> data = new Dictionary<string, string>
                        {
                            ["id"] = id,
                            ["hash"] = source,
                        };
                        HttpContent contentForm = new FormUrlEncodedContent(data);
                        using var response = await httpClient
                            .PostAsync(args[3], contentForm);
                        string responseText = await response.Content.ReadAsStringAsync();
                        await bot.SendMessage(args[2], responseText);
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine(ex);
                    }
                    if (cts.IsCancellationRequested) break;
                }
            }
            cts.Cancel();
        }
    }
}
