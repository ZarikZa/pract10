using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace proverka324
{
    internal class convert
    {
        private static string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public static void Jsonser<T>(T Mydata, string filename)
        {
            string json = JsonConvert.SerializeObject(Mydata);
            File.WriteAllText(desktop + "\\" + filename, json);
        }
        public static T Jsonviser<T>(string filename, string role) 
        {
            string json = "";
            try
            {
                json = File.ReadAllText(desktop + "\\" + filename);

            }
            catch (Exception)
            {
                File.Create(desktop + "\\" + filename).Close();
                json = File.ReadAllText(desktop + "\\" + filename);
            }
            T Mydata = JsonConvert.DeserializeObject<T>(json);
            return Mydata;
        }
    }
}