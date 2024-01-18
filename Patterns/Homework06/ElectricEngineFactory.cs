using Homework06;

public class ElectricEngineFactory
{
    private readonly ElectricEngine electricEngine;

    public ElectricEngineFactory(ElectricEngine electricEngine)
    {
        this.electricEngine = electricEngine;
    }

    public IEngine Get(int hp)
    {
        this.electricEngine.Hp = hp;
        return this.electricEngine;
    }
}