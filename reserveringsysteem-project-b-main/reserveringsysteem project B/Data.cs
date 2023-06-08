using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System;

namespace reserveringsysteem_project_B
{
    public class Data<T>
    {
        public List<T> Load(string fileName)
        {
            var json = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\..\\Data\\" + fileName);

            return JsonSerializer.Deserialize<List<T>>(json);
        }

        public void Save(string fileName, List<T> data)
        {
            var json = JsonSerializer.Serialize(data);

            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\..\\Data\\" + fileName, json);
        }
    }
}