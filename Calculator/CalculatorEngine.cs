using System;

namespace Calculator
{
    // Denna klass hanterar olika matematiska operationer
    public class CalculatorEngine
    {
        // Detta är fält för att kunna hålla referens till operation
        private readonly IOperation? _operation;

        // Konstruktor för Dependency Injection i tester
        public CalculatorEngine(IOperation operation)
        {
            _operation = operation;
        }

        // Standardkonstruktor för produktion
        public CalculatorEngine() { }

        // Metod för att utföra beräkningar baserat på användarens val
        public double Calculate(int menuChoice, double num1, double num2)
        {
            // Om en operation har injicerats, använd den för beräkning
            if (_operation != null)
            {
                return _operation.calulate(num1, num2); // används i test
            }
            // Här väljs rätt operation utifrån menyvalet i produktionsläge förstås
            IOperation operation = menuChoice switch
            {
                1 => new Adder(),
                2 => new Subtractor(),
                3 => new Multiplier(),
                4 => new Divider(),
                5 => new PowerOf(),
                6 => new Squareroot(),
                _ => throw new ArgumentException("Ogiltigt val.")
            };
            // Returnerar vald operation
            return operation.calulate(num1, num2);
        }
    }
}
