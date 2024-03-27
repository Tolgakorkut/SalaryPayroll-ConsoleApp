using SalaryPayroll.Abstract.Interfaces;
using SalaryPayroll.Concrete.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main()
    {
        #region Instances
        IReadDocument readDocument = new ReadDocument();
        CultureInfo culture = new CultureInfo("tr-TR");
        Random random = new Random();
        DateTime now = DateTime.Now;
        List<SalaryPayrollClass> salaryPayrolls = new List<SalaryPayrollClass>();
        
        #endregion


        string filePathReadDocumentPersonel = @"Database\personel.json";

        List<Personel> personeller = readDocument.ReadingDocument(filePathReadDocumentPersonel);

        string monthName = culture.DateTimeFormat.GetMonthName(now.Month).ToUpper();

        string yearName = now.Year.ToString();

        foreach (var personel in personeller)
        {
            Console.WriteLine($"isim: {personel.Name}, Başlık: {personel.Title}, Derece: {personel.Grade}");
            Console.WriteLine($"Lütfen {personel.Name} isimli kişinin bu ay çalıştığı süreyi saat olarak giriniz: ");

            #region Entering Working Hour
            int workingHours;

            while (true)
            {
                Console.Write("Lütfen çalışma saati giriniz (0-300): ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Giriş boş olamaz. Lütfen tekrar deneyin.");
                    continue;
                }

                if (!int.TryParse(input, out workingHours))
                {
                    Console.WriteLine("Geçersiz bir sayı girişi. Lütfen tekrar deneyin.");
                    continue;
                }

                if (workingHours < 0 || workingHours > 300)
                {
                    Console.WriteLine("Çalışma saati 0 ile 300 arasında olmalıdır. Lütfen tekrar deneyin.");
                    continue;
                }

                break;
            }
            #endregion



            decimal finalSalary = personel.CalculateSalary(workingHours, out decimal salary);

            SalaryPayrollClass salaryPayroll = new SalaryPayrollClass(personel.Name, workingHours, salary, finalSalary - salary, finalSalary);

            salaryPayrolls.Add(salaryPayroll); //we use this list to find employees who work less than 150 hours per month

            ISaveDocument saveDocument = new SaveDocument();
            saveDocument.SaveToFile(salaryPayroll, personel.Name, monthName, yearName);

            string filePathReadDocumentSalaryPayroll = Path.Combine("Database", personel.Name, "SalaryPayroll.json");

            string jsonString = File.ReadAllText(filePathReadDocumentSalaryPayroll);
            Console.WriteLine($"{jsonString}");
        }


        foreach (var payroll in salaryPayrolls)
        {
            if (payroll.WorkingHour < 150)
            {
                Console.WriteLine($"15 saatten daha az çalışanların listesi:\nİsim: {payroll.PersonelName}, Çalışma Saati: {payroll.WorkingHour}");
            }
        }

    }
}