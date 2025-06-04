using System;

namespace Calculator
{
    // Denna klass hanterar olika matematiska operationer
    public class CalculatorEngine
    {
        // Detta �r f�lt f�r att kunna h�lla referens till operation
        private readonly IOperation? _operation;

        // Konstruktor f�r Dependency Injection i tester
        public CalculatorEngine(IOperation operation)
        {
            _operation = operation;
        }

        // Standardkonstruktor f�r produktion
        public CalculatorEngine() { }

        // Metod f�r att utf�ra ber�kningar baserat p� anv�ndarens val
        public double Calculate(int menuChoice, double num1, double num2)
        {
            // Om en operation har injicerats, anv�nd den f�r ber�kning
            if (_operation != null)
            {
                return _operation.calulate(num1, num2); // anv�nds i test
            }
            // H�r v�ljs r�tt operation utifr�n menyvalet i produktionsl�ge f�rst�s
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
