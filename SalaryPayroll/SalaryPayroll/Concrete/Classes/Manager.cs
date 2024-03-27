using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryPayroll.Concrete.Classes
{
    public class Manager : Personel
    {
        private decimal pricePerHour = 500; // Default salary for per hour
        private int maxWorkingHour = 180; // Maximum working hour
        private decimal bonus=0;
        public Manager(string name, string title, string grade) : base(name, title, grade)
        {
        }

        public override decimal CalculateSalary(int workingHours, out decimal salary)
        {
            decimal salaryMultiplyer;
            switch (Grade)
            {
                case "A":
                    salaryMultiplyer = 1.05m;
                    break;
                case "B":
                    salaryMultiplyer = 1.1m;
                    break;
                case "C":
                    salaryMultiplyer = 1.15m;
                    break;
                case "D":
                    salaryMultiplyer = 1.2m;
                    break;
                case "E":
                    salaryMultiplyer = 1.3m;
                    break;

                default:
                    salaryMultiplyer = 1;
                    break;
            }
            salary = maxWorkingHour * pricePerHour * salaryMultiplyer;
            decimal finalSalary = salary;

            if (workingHours>maxWorkingHour)// It will enter this condition if the working hours exceed the maximum working hours
            {
                bonus = salary * (0.05m);
            }

            finalSalary += bonus;
                         

            return finalSalary;
        }

        
    }
}
