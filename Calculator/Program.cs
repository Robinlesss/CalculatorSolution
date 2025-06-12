using System;

// Komplettering för pull request

namespace Calculator
{
    internal class Program
    {
        static void Main()
        {
            // Här intierar klasser för beräkning och filsparningen
            var saveToFile = new SaveToFile();
            var engine = new CalculatorEngine(); 

            bool exitProgram = false;
            double result = 0;

            // Menyn körs i en loop tills användaren väljer att avsluta
            while (!exitProgram)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(
                    "\n-------------------------------------------" +
                    "\n Miniräknare" +
                    "\n-------------------------------------------" +
                    "\n Vilken beräkning skulle du vilja göra? Välj Operatör 1-7." +
                    "\n1. Addition +" +
                    "\n2. Subtraktion -" +
                    "\n3. Multiplikation *" +
                    "\n4. Division /" +
                    "\n5. Upphöjt till ^" +
                    "\n6. Roten ur V" +
                    "\n7. Avsluta programmet" +
                    "\n------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write("\nSkriv in valet: ");
                if (!int.TryParse(Console.ReadLine(), out int menuChoice) || menuChoice < 1 || menuChoice > 7)
                {
                    Console.WriteLine("Ogiltigt val. Var god välj ett nummer mellan 1-7.");
                    continue;
                }

                if (menuChoice == 7)
                {
                    Console.WriteLine("Avslutas...");
                    break;
                }

                // Tar emot operander och använder tidigare resultat för vidare beräkningar
                double num1 = (result == 0) ? GetOperand("Ange det första talet: ") : result;
                double num2 = (menuChoice == 6) ? 0 : GetOperand("Ange det andra talet: ");

                // Utför beräkningen
                result = engine.Calculate(menuChoice, num1, num2);

                Console.WriteLine($"\nResultat: {result}");
                saveToFile.AddCalculation($"Resultat: {result}");

                // Om användaren valde division, beräkna heltalskvot och heltalsrest
                if (menuChoice == 4 && num2 != 0)
                {
                    int heltalskvot = (int)(num1 / num2);
                    int heltalsrest = (int)(num1 % num2);

                    Console.WriteLine($"Heltalskvot: {heltalskvot}");
                    Console.WriteLine($"Heltalsrest: {heltalsrest}");

                    saveToFile.AddCalculation($"Heltalskvot: {heltalskvot}");
                    saveToFile.AddCalculation($"Heltalsrest: {heltalsrest}");
                }

                // Frågar om fortsättning
                string userChoice = GetUserChoice();
                switch (userChoice)
                {
                    case "1":
                        break;
                    case "2":
                        result = 0;
                        break;
                    case "3":
                        Console.WriteLine("Avslutas...");
                        exitProgram = true;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val. Var god välj ett nummer mellan 1-3.");
                        break;
                }

                saveToFile.SavetoFile();
            }
        }

        static double GetOperand(string prompt)
        {
            double operand;
            Console.Write(prompt);

            while (!double.TryParse(Console.ReadLine(), out operand))
            {
                Console.WriteLine("Du måste skriva in en siffra.");
                Console.Write(prompt);
            }

            return operand;
        }

        public static string GetUserChoice()
        {
            Console.WriteLine("\nVad vill du göra nu?");
            Console.WriteLine("1. Fortsätt med det senaste resultatet");
            Console.WriteLine("2. Göra en ny beräkning");
            Console.WriteLine("3. Avsluta programmet");

            Console.Write("Välj ett alternativ (1-3): ");
            return Console.ReadLine().ToLower();
        }
    }
}
