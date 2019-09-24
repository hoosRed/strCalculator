using System;
namespace strCalculator
{
    public class CalculatorController
    {
        private IConsoleInterface _consoleInterface;
        private ICalculatorAddService _addService;
        private ICalculatorMultiplyService _multiplyService;

        /// <summary>
        ///     Constructor injects Console Interface and all Math Services
        /// </summary>
        /// <param name="consoleInterface">Console interface</param>
        /// <param name="addService">Add service</param>
        /// <param name="multiplyService">Multiply service</param>
        public CalculatorController(
            IConsoleInterface consoleInterface,
            ICalculatorAddService addService,
            ICalculatorMultiplyService multiplyService)
        {
            _consoleInterface = consoleInterface;
            _addService = addService;
            _multiplyService = multiplyService;
        }

        public void Run()
        {
            bool finished = false;

            // Stretch 2: Process entries until Ctrl + C
            do
            {
                _consoleInterface.Write("Welcome to String Calculator ");
                _consoleInterface.Write("Enter Operation: Add, Multiply ");

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
                else if (command == "multiply")
                {
                    // read input string
                    _consoleInterface.Write("Enter numbers: ");
                    var input = _consoleInterface.ReadLine();

                    // execute and print 
                    var multiplyServiceOutput = _multiplyService.Execute(input);
                    _consoleInterface.WriteLine(multiplyServiceOutput);
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
