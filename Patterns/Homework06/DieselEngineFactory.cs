using Homework06;

public class DieselEngineFactory
{
    private readonly DieselEngine dieselEngine;

    public DieselEngineFactory(DieselEngine dieselEngine)
    {
        this.dieselEngine = dieselEngine;
    }

    public IEngine Get(int hp)
    {
        this.dieselEngine.Hp = hp;
        return this.dieselEngine;
    }
}