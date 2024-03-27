using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SalaryPayroll.Concrete.Classes
{
    public abstract class Personel
    {             
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Title { get; set; }
        public string Grade { get; set; }

        public decimal WorkingHours { get; set; }

        

        public abstract decimal CalculateSalary(int workingHours,out decimal salary);

        protected Personel(string name, string title, string grade)
        {
            Name = name;
            Title = title;
            Grade = grade;
        }

        

    }
}
