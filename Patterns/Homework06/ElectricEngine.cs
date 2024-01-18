namespace Homework06;

public class ElectricEngine : IEngine
{
    public int Hp { get; set; }

    public void StartEngine()
    {
        Console.WriteLine("Electric engine with {0} hp has been started", this.Hp);
    }
}