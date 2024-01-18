
namespace Homework05
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Starting Homework 05!");

            ExecuteSpecificLuckGenerator<int>(LuckType.Dice);
            Console.WriteLine();
            ExecuteSpecificLuckGenerator<int>(LuckType.Coin);
            Console.WriteLine();
            ExecuteSpecificLuckGenerator<DateTime>(LuckType.Date);
            Console.WriteLine();
            ExecuteSpecificLuckGenerator<string>(LuckType.Text);
        }
        
        private static void ExecuteSpecificLuckGenerator<T>(LuckType luckType) {
            Console.WriteLine("Testing luck generator of type '" + luckType + "'");

            var luckGenerator = new LuckFactory().GetLuckGenerator<T>(luckType);

            for (int iteration = 0; iteration < 5; iteration++) {
                Console.WriteLine("Test #" + iteration + ", LuckGenerator '" + luckGenerator.GetGeneratorType() + "': " + luckGenerator.GenerateNext());
            }
        }
    }
}