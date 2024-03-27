using SalaryPayroll.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;

namespace SalaryPayroll.Concrete.Classes
{
    public class ReadDocument : IReadDocument
    {
        public List<Personel> ReadingDocument(string filePath)
        {
            var personelListesi = new List<Personel>();


            var json = File.ReadAllText(filePath);// We read json content from the file

            using (JsonDocument doc = JsonDocument.Parse(json))
            {
                foreach (JsonElement personel in doc.RootElement.EnumerateArray())
                {
                    string name = personel.GetProperty("Name").GetString();
                    string title = personel.GetProperty("Title").GetString();
                    string grade = personel.GetProperty("Grade").GetString();

                    switch (title)
                    {
                        case "Yönetici":
                            personelListesi.Add(new Manager(name, title, grade));
                            break;
                        case "Memur":
                            personelListesi.Add(new GovernmentOfficial(name, title, grade));
                            break;
                    }
                }
            }

            return personelListesi;
        
    }
           
}
}
