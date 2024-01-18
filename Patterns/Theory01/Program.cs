using System.Net.Http.Headers;

Console.WriteLine("Hello, this is Theory #01!");

using (HttpClient client = new HttpClient()) // TODO: convert to using declaration
{
    client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Chrome", "120.0.0.0"));
    try
    {
        HttpResponseMessage response = await client.GetAsync("https://robotdreams.cc/"); // TODO: convert to using, use var
        if (response.IsSuccessStatusCode)
        {
            byte[] responseData = await response.Content.ReadAsByteArrayAsync();
            Console.WriteLine($"I'm async, response size: {responseData.Length} bytes");
        }
        else
        {
            Console.WriteLine($"Request failed with status code: {response.StatusCode}");
        }
    }
    catch (HttpRequestException e)
    {
        Console.WriteLine($"Request exception: {e.Message}");
    }
}

Console.WriteLine("Circle radius = " + new MyClass(10).GetSquare());

class MyClass // TODO: rename to Circle 
{
    private readonly double radius;

    public MyClass(double radius = 123)
    {
        this.radius = radius;
    }

    public double GetSquare()
    {
        // TODO: convert method to property; rename to Area
        return Math.PI * this.radius * this.radius;
    }
}