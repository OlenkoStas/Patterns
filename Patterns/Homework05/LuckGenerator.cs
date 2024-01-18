namespace Homework05;

public enum LuckType
{
    Default,
    Dice,
    Coin,
    Date,
    Text
}

public interface ILuckGenerator<out T>
{
    LuckType GetGeneratorType();
    T GenerateNext();
}

public class DefaultLuckGenerator<T> : ILuckGenerator<T>
{
    public LuckType GetGeneratorType()
    {
        return LuckType.Default;
    }

    public T GenerateNext()
    {
        return default;
    }
}