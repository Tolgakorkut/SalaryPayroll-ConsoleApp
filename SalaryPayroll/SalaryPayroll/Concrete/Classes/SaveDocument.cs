using SalaryPayroll.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SalaryPayroll.Concrete.Classes
{
    public class SaveDocument : ISaveDocument
    {
        public void SaveToFile(SalaryPayrollClass salaryPayroll, string personelName, string monthName, string yearName)
        {

            //We used this code here because the names were corrupted while saving
            string json = JsonSerializer.Serialize(salaryPayroll, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(System.Text.Unicode.UnicodeRanges.All)
            });


            //To save each personnel with a separate file
            string directoryPath = Path.Combine("Database", personelName);

            Directory.CreateDirectory(directoryPath);

            string filePath = Path.Combine(directoryPath, "SalaryPayroll.json");

            File.WriteAllText(filePath, monthName+" "+yearName + Environment.NewLine+json);
           
        }
    }
}
