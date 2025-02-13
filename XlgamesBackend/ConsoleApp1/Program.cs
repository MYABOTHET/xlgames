public class Program
{
    static async Task Main()
    {
        int count = 0;
        var task1 = Task.Run(async () =>
        {
            while (true)
            {
                try
                {
                    HttpClient client = new HttpClient();
                    using HttpResponseMessage response = await client.GetAsync("https://ru-freelance.ru/registration");
                    response.EnsureSuccessStatusCode();
                    string header_csrf = response.Headers.GetValues("Set-cookie").First().Split(";")
                        .Where(str => str.StartsWith("csrftoken")).First().Split("=").Last();
                    string content = await response.Content.ReadAsStringAsync();
                    int startPos = content.IndexOf("value");
                    content = content.Substring(startPos + 7);
                    string csrf = content.Split("\"").First();
                    string[] guids = { "", "", "" };
                    for (int i = 0; i < 3; i++)
                    {
                        string guid = "";
                        for (int c = 0; c < 3; c++)
                        {
                            guid += Guid.NewGuid().ToString();
                        }
                        guids[i] = guid;
                    }
                    Dictionary<string, string> data = new Dictionary<string, string>
                    {
                        ["csrfmiddlewaretoken"] = csrf,
                        ["name"] = guids[0],
                        ["login"] = guids[1],
                        ["password"] = guids[2],
                        ["accept"] = "on",
                    };
                    HttpContent contentForm = new FormUrlEncodedContent(data);
                    client.DefaultRequestHeaders.Add("Origin", "https://ru-freelance.ru");
                    client.DefaultRequestHeaders.Add("Referer", "https://ru-freelance.ru/login");
                    client.DefaultRequestHeaders.Add("Cookie", "csrftoken=" + header_csrf + "; sessionid=u6ekn6feu2siju2nwprqv3jhvef3zw4g");
                    client.DefaultRequestHeaders.Add("X-Forwarded-For", "1.2.3.4");
                    client.DefaultRequestHeaders.Add("X-Forwarded-Host", "1.2.3.4");
                    client.DefaultRequestHeaders.Add("Forwarded", "for=192.0.2.60;proto=https;by=1.2.3.4");
                    using var result = await client.PostAsync("https://ru-freelance.ru/registration", contentForm);
                    result.EnsureSuccessStatusCode();
                    string test = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(test);
                    Console.WriteLine("Успешно... " + count++);
                    break;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Ошибка: ", e.Message);
                }
            }
        });
        task1.Wait();
    }
}