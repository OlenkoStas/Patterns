namespace Homework05;

internal class LuckFactory
{
    public ILuckGenerator<T> GetLuckGenerator<T>(LuckType name) {
        // TODO: Implement factory here
        return new DefaultLuckGenerator<T>();
    }
}