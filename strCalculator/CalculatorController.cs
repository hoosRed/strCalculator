using System;
namespace strCalculator
{
    public class CalculatorController
    {
        private IConsoleInterface _consoleInterface;
        private ICalculatorAddService _addService;

        public CalculatorController(
            IConsoleInterface consoleInterface,
            ICalculatorAddService addService)
        {
            _consoleInterface = consoleInterface;
            _addService = addService;
        }

        public void Run()
        {
            bool finished = false;

            // Stretch 2: Process entries until Ctrl + C
            do
            {
                _consoleInterface.Write("Welcome to String Calculator ");
                _consoleInterface.Write("Enter Operation: Add ");

                string command = _consoleInterface.ReadLine().ToLower();

                if (String.IsNullOrWhiteSpace(command))
                {
                    _consoleInterface.Write("Goodbye");
                    finished = true;
                }
                else if (command == "add")
                {
                    // read input string
                    _consoleInterface.Write("Enter numbers: ");
                    var input = _consoleInterface.ReadLine();

                    // execute and print 
                    var addServiceOutput = _addService.Execute(input);
                    _consoleInterface.WriteLine(addServiceOutput);
                }
                else
                {
                    _consoleInterface.WriteLine("Invalid Input, please try again");
                }
            }
            while (!finished);
        }
    }
}
