using SalaryPayroll.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SalaryPayroll.Concrete.Classes
{
    public class SalaryPayrollClass
    {

        [DisplayName("Personel İsmi")]
        public string PersonelName { get; set; }

        [DisplayName("Çalışma Saati")]
        public int WorkingHour { get; set; }

        [DisplayName("Ana Ödeme")]
        public decimal MainPayment { get; set; }

        [DisplayName("Mesai")]
        public decimal ExtraPayment { get; set; }

        [DisplayName("Toplam Ödeme")]
        public decimal TotalPayment { get; set; }
                        
        public SalaryPayrollClass(string personelName, int workingHour, decimal mainPayment, decimal extraPayment, decimal totalPayment)
        {
            PersonelName = personelName;
            WorkingHour = workingHour;
            MainPayment = mainPayment;
            ExtraPayment = extraPayment;
            TotalPayment = totalPayment;
            
        }

       
    }
}
