using System;

namespace strCalculator
{
    public class ConsoleInterface : IConsoleInterface
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void Write(string message)
        {
            Console.Write(message);
        }
        public string ReadLine()
        {
            return Console.ReadLine();
        }
        public void WriteLine(Object o)
        {
            Console.WriteLine(o);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new CalculatorController(
                new ConsoleInterface(),
                new CalculatorAddService(),
                new CalculatorMultiplyService());

            calculator.Run();
        }
    }
}
