using System.Collections.Generic;
using strCalculator;

namespace StrCalculatorTests
{
    /// <summary>
    ///     Fake Console to Test Console Interface
    /// </summary>
    public class FakeConsoleInterface : IConsoleInterface
    {
        public Queue<string> UserInput;
        public string Output;

        public FakeConsoleInterface(IEnumerable<string> input)
        {
            UserInput = new Queue<string>(input);
            Output = "";
        }

        public string ReadLine()
        {
            if (UserInput.Count == 0)
            {
                return "";
            }
            return UserInput.Dequeue();
        }

        public void Write(string message)
        {
            Output += message;
        }

        public void WriteLine(string message)
        {
            Output += message + "\r\n";
        }

        public void WriteLine(object o)
        {
            Output += o + "\r\n";
        }
    }
}
