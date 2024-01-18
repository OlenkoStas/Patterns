namespace Homework06;

public class CarFactory
{
    private readonly ElectricEngineFactory electricEngineFactory;
    private readonly DieselEngineFactory dieselEngineFactory;

    public CarFactory(DieselEngineFactory dieselEngineFactory, ElectricEngineFactory electricEngineFactory)
    {
        this.electricEngineFactory = electricEngineFactory;
        this.dieselEngineFactory = dieselEngineFactory;
    }

    public Car Get(String make, String model, int year, int hp)
    {
        if (make != "Tesla")
            return new Car(
                make,
                model,
                this.dieselEngineFactory.Get(hp),
                year
            );

        return new Car(
            make,
            model,
            this.electricEngineFactory.Get(hp),
            year
        );
    }
}