using SalaryPayroll.Concrete.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryPayroll.Abstract.Interfaces
{
    public interface ISaveDocument
    {
        void SaveToFile(SalaryPayrollClass salaryPayrolls, string personelName, string monthName, string yearName);
    }
}
