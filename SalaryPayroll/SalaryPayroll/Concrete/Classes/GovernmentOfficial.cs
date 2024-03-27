using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryPayroll.Concrete.Classes
{
    public class GovernmentOfficial : Personel
    {
        private decimal pricePerHour = 500; // Default salary for per hour
        private int maxWorkingHour = 180; // Maximum working hour

        public GovernmentOfficial(string name, string title, string grade) : base(name, title, grade)
        {
        }
                
          public override decimal CalculateSalary(int workingHours, out decimal salary)
        {
            decimal salaryMultiplyer;
            switch (Grade)
            {
                case "1":
                    salaryMultiplyer = 1.02m;
                    break;
                case "2":
                    salaryMultiplyer = 1.04m;
                    break;
                case "3":
                    salaryMultiplyer = 1.1m;
                    break;
                case "4":
                    salaryMultiplyer = 1.13m;
                    break;
                case "5":
                    salaryMultiplyer = 1.16m;
                    break;
                case "6":
                    salaryMultiplyer = 1.2m;
                    break;
                case "7":
                    salaryMultiplyer = 1.25m;
                    break;
                case "8":
                    salaryMultiplyer = 1.3m;
                    break;
                case "9":
                    salaryMultiplyer = 1.35m;
                    break;

                default:
                    salaryMultiplyer = 1;
                    break;
            }


            salary = maxWorkingHour * pricePerHour * salaryMultiplyer;
            decimal finalSalary = salary;

           
            if (workingHours > maxWorkingHour) // It will enter this condition if the working hours exceed the maximum working hours
            {
                finalSalary += ((workingHours - maxWorkingHour) * pricePerHour * salaryMultiplyer * 1.5m);
            }


            return finalSalary;
        }
    }
}
