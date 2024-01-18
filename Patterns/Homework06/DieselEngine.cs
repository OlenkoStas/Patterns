namespace Homework06;

public class DieselEngine : IEngine
{
    public int Hp { get; set; }

    public void StartEngine()
    {
        Console.WriteLine("Diesel engine with {0} hp has been started", this.Hp);
    }
}