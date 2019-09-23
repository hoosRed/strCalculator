using System;
namespace strCalculator
{
    /// <summary>
    ///     Interface for mocked console
    /// </summary>
    public interface IConsoleInterface
    {
        void WriteLine(string message);
        void Write(string message);
        string ReadLine();
        void WriteLine(Object o);
    }
}
