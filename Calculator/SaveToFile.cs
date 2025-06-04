using System;
using System.Collections.Generic;
using System.IO;

namespace Calculator
{
    // Detta är Interface för att spara beräkningar till en fil
    public interface ISaveToFile
    {
        void AddCalculation(string calculation);
        void SavetoFile();
    }

    // Klass för filhantering
    public class SaveToFile : ISaveToFile
    {
        private readonly List<string> calculations = new List<string>();
        private readonly string filePath;

        public SaveToFile()
        {
            // Använd ett statiskt filnamn direkt, till skrivbordet
            string fileName = "calc_results.txt";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Säkerställ att folderPath och fileName inte är null
            filePath = Path.Combine(folderPath ?? ".", fileName);
        }

        public void SavetoFile()
        {
            try
            {
                File.AppendAllLines(filePath, calculations);
                Console.WriteLine($"Beräkningarna har sparats i filen: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Det uppstod ett problem vid filskrivning: {ex.Message}");
            }
        }

        // Lägger till en beräkningssträng till listan ifall den inte är tom
        public void AddCalculation(string calculation)
        {
            if (!string.IsNullOrWhiteSpace(calculation))
            {
                calculations.Add(calculation);
            }
        }
    }
}
