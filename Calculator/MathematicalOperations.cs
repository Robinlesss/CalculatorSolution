using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    // Detta är Interface för olika matematiska operationer
    public interface IOperation
    {
        double calulate(double num1, double num2);
    }
    // Klass för addition, subtraktion, multiplikation, division, upphöjt till, roten ur
    public class Adder : IOperation
    {
        public double calulate(double num1, double num2) => num1 + num2;
    }

    public class Subtractor : IOperation
    {
        public double calulate(double num1, double num2) => num1 - num2;
    }

    public class Multiplier : IOperation
    {
        public double calulate(double num1, double num2) => num1 * num2;
    }

    public class Squareroot : IOperation
    {
        public double calulate(double num1, double num2) => Math.Sqrt(num1);
    }

    public class PowerOf : IOperation
    {
        public double calulate(double num1, double num2) => Math.Pow(num1, num2);
    }

    public class Divider : IOperation
    {
        public double calulate(double num1, double num2)
        {
            if (num2 != 0)
            {
                return num1 / num2;
            }
            else
            {   // Om num2 är 0, skriv ut ett felmeddelande
                Console.WriteLine("Det går inte att dividera med 0");
                return double.NaN;
                ;
            }
        }
    }

}

