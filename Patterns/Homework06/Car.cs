namespace Homework06;

public class Car
{
    private readonly String make;
    private readonly String model;
    private readonly IEngine engine;
    private readonly int year;

    public Car(String make, String model, IEngine engine, int year)
    {
        this.make = make;
        this.model = model;
        this.engine = engine;
        this.year = year;
    }

    public void start()
    {
        Console.WriteLine("Starting {0} {1} car, manufactured {2}", this.make, this.model, this.year);
        this.engine.StartEngine();
    }
}