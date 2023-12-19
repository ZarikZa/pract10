using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static proverka324.Enum;

namespace proverka324
{
    internal class Kadr : AdminTable 
    {
        public override void ShowInfo(string name, string role, string path)
        {
            if (path == "Admin\\Search.json")
            {
                base.ShowInfo(name, role, "Admin\\Search.json");
            }
            else
            {
                base.ShowInfo(name, role, $"Admin\\{role}.json");
            }
        }
        public override void Create(string role, string name)
        {
            List<Kadrovik> kasrovs = new List<Kadrovik>();
            Kadrovik kadr = new Kadrovik();
            Console.WriteLine($"\t\tДобрый день {name}");
            Console.SetCursorPosition(50, 0);
            Console.WriteLine($"Роль: {role}");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(50, 2);
            Console.WriteLine("S - Сохранить");
            Console.SetCursorPosition(50, 3);
            Console.WriteLine("Delete - Удалить");
            Console.SetCursorPosition(50, 4); 
            Console.WriteLine("Backspace - Вернуться к регистрации");
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("  Введите ID: ");
            Console.WriteLine("  Введите Фамилию: ");
            Console.WriteLine("  Введите Имя: ");
            Console.WriteLine("  Введите Отчество: ");
            Console.WriteLine("  Введите Дату рождения: ");
            Console.WriteLine("  Введите Серию и номер паспорта: ");
            Console.WriteLine("  Введите Должность: ");
            Console.WriteLine("  Введите Зарплату: ");
            Console.WriteLine("  Введите ID сотрудника: ");
            while (true)
            {
                int pos = strelka.show(2, 10);
                if (pos == (int)klavishi.nazad)
                {
                    return;
                }
                else if (pos == 2)
                {
                    Console.SetCursorPosition(14, 2);
                    kadr.ID = Convert.ToInt32(Console.ReadLine());
                }
                else if (pos == 3)
                {
                    Console.SetCursorPosition(19, 3);
                    kadr.Surname = Console.ReadLine();
                }
                else if (pos == 4)
                {
                    Console.SetCursorPosition(15, 4);
                    kadr.Name = Console.ReadLine();
                }
                else if (pos == 5)
                {
                    Console.SetCursorPosition(20, 5);
                    kadr.Middlename = Console.ReadLine();
                }
                else if (pos == 6)
                {
                    Console.SetCursorPosition(25, 6);
                    kadr.DateOfBirth = Console.ReadLine();

                }
                else if (pos == 7)
                {
                    Console.SetCursorPosition(34, 7);
                    kadr.Pasport = Convert.ToInt32(Console.ReadLine());
                }
                else if (pos == 8)
                {
                    Console.SetCursorPosition(21, 8);
                    kadr.Dolznost = Console.ReadLine();
                    
                }
                else if (pos == 9)
                {
                    Console.SetCursorPosition(20, 9);
                    kadr.Zarplata = Convert.ToDouble(Console.ReadLine());
                }
                else if (pos == 10)
                {
                    Console.SetCursorPosition(25, 10);
                    kadr.ID_Sot = Convert.ToInt32(Console.ReadLine());
                }
                else if (pos == (int)klavishi.safe)
                {
                    break;
                }
            }
            try
            {
                var data1 = convert.Jsonviser<List<Kadrovik>>($"Admin\\{role}.json", role);
                data1.Add(kadr);
                convert.Jsonser(data1, $"Admin\\{role}.json");
            }
            catch (Exception)
            {
                kasrovs.Add(kadr);
                convert.Jsonser(kasrovs, $"Admin\\{role}.json");
            }
            return;
        }
        public override int vivod(string path, string role)
        {
            int j = 3;
            var data = convert.Jsonviser<List<Kadrovik>>(path, role);
            Console.SetCursorPosition(5, 2);
            Console.WriteLine("ID:");
            Console.SetCursorPosition(10, 2);
            Console.WriteLine("Фамилия");
            Console.SetCursorPosition(25, 2);
            Console.WriteLine("Имя:");
            Console.SetCursorPosition(40, 2);
            Console.WriteLine("Отчество:");
            Console.SetCursorPosition(60, 2);
            Console.WriteLine("Должность:");
            if (data != null)
            {
                foreach (var item in data)
                {
                    Console.SetCursorPosition(5, j);
                    Console.WriteLine(item.ID);
                    Console.SetCursorPosition(10, j);
                    Console.WriteLine(item.Surname);
                    Console.SetCursorPosition(25, j);
                    Console.WriteLine(item.Name);
                    Console.SetCursorPosition(40, j);
                    Console.WriteLine(item.Middlename);
                    Console.SetCursorPosition(60, j);
                    Console.WriteLine(item.Dolznost);
                    j++;
                }
            }
            return j;
        }
        public override int vivodRead(int pos, string role)
        {

            Console.SetCursorPosition(0, 2);
            var data = convert.Jsonviser<List<Kadrovik>>($"Admin\\{role}.json", role);
            var info = data[pos];
            Console.WriteLine("  ID: " + info.ID);
            Console.WriteLine("  Фамилия: " + info.Surname);
            Console.WriteLine("  Имя: " + info.Name);
            Console.WriteLine("  Отчество: " + info.Middlename);
            Console.WriteLine("  Дата рождения: " + info.DateOfBirth);
            Console.WriteLine("  Серия и номер паспорта: " + info.Pasport);
            Console.WriteLine("  Должность: " + info.Dolznost);
            Console.WriteLine("  Зарплата: " + info.Zarplata);
            Console.WriteLine("  ID сотрудника: " + info.ID_Sot);
            int poos = strelka.show(2, 10);
            return poos;
        }
        public override void Update(int poos, int pos, string role)
        {
            var data = convert.Jsonviser<List<Kadrovik>>($"Admin\\{role}.json", role);
            Kadrovik first = data[pos];
            if (poos-2 == 0)
            {
                Console.SetCursorPosition(6, 2);
                first.ID = Convert.ToInt32(Console.ReadLine());
                data[pos] = first;
            }
            else if (poos-2 == 1)
            {
                Console.SetCursorPosition(11, 3);
                first.Surname = Console.ReadLine();
                data[pos] = first;
            }
            else if (poos - 2 == 2)
            {
                Console.SetCursorPosition(7, 4);
                first.Name = Console.ReadLine();
                data[pos] = first;
            }
            else if (poos - 2 == 3)
            {
                Console.SetCursorPosition(12, 5);
                first.Middlename = Console.ReadLine();
                data[pos] = first;
            }
            else if (poos - 2 == 4)
            {
                Console.SetCursorPosition(17, 6);
                first.DateOfBirth = Console.ReadLine();
                data[pos] = first;
            }
            else if (poos - 2 == 5)
            {
                Console.SetCursorPosition(26, 7);
                first.Pasport = Convert.ToInt32(Console.ReadLine());
                data[pos] = first;
            }
            else if (poos - 2 == 6)
            {
                Console.SetCursorPosition(13, 8);
                first.Dolznost = Console.ReadLine();
                data[pos] = first;
            }
            else if (poos - 2 == 7)
            {
                Console.SetCursorPosition(12, 9);
                first.Zarplata = Convert.ToInt32(Console.ReadLine());
                data[pos] = first;
            }
            else if (poos - 2 == 8)
            {
                Console.SetCursorPosition(23, 10);
                first.ID_Sot = Convert.ToInt32(Console.ReadLine());
                data[pos] = first;
            }
            convert.Jsonser(data, $"Admin\\{role}.json");
        }
        public override void Delete(int pos, string role)
        {
            var data = convert.Jsonviser<List<Kadrovik>>($"Admin\\{role}.json", role);
            data.RemoveAt(pos);
            convert.Jsonser(data, $"Admin\\{role}.json");
        }
        public override void Search(string name, string role)
        {
            var data = convert.Jsonviser<List<Kadrovik>>($"Admin\\{role}.json", role);
            Console.WriteLine($"\t\tДобрый день {name}");
            Console.SetCursorPosition(50, 0);
            Console.WriteLine($"Роль: {role}");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("  ID");
            Console.WriteLine("  Фамилия");
            Console.WriteLine("  Имя");
            Console.WriteLine("  Отчество");
            Console.WriteLine("  Дата рождения");
            Console.WriteLine("  Серия и номер паспорта");
            Console.WriteLine("  Должность");
            Console.WriteLine("  Зарплата");
            Console.WriteLine("  ID сотрудника");
            int pos = strelka.show(2, 10);
            Console.SetCursorPosition(0, 12);
            Console.WriteLine("Введите значение для поиска");
            if (pos == 2)
            {
                int ID = Convert.ToInt32(Console.ReadLine());
                foreach (var item in data)
                {
                    if (ID == item.ID)
                    {
                        searchjson(item);
                    }
                }
            }
            if (pos == 3)
            {
                string surname = Console.ReadLine();
                foreach (var item in data)
                {
                    if (surname == item.Surname)
                    {
                        searchjson(item);
                    }
                }
            }
            if (pos == 4)
            {
                string nameser = Console.ReadLine();
                foreach (var item in data)
                {
                    if (nameser == item.Name)
                    {
                        searchjson(item);
                    }
                }
            }
            if (pos == 5)
            {
                string middle = Console.ReadLine();
                foreach (var item in data)
                {
                    if (middle == item.Middlename)
                    {
                        searchjson(item);
                    }
                }
            }
            if (pos == 6)
            {
                string dateofbirth = Console.ReadLine();
                foreach (var item in data)
                {
                    if (dateofbirth == item.DateOfBirth)
                    {
                        searchjson(item);
                    }
                }
            }
            if (pos == 7)
            {
                int pasport = Convert.ToInt32(Console.ReadLine());
                foreach (var item in data)
                {
                    if (pasport == item.Pasport)
                    {
                        searchjson(item);
                    }
                }
            }
            if (pos == 8)
            {
                string dolznost = Console.ReadLine();
                foreach (var item in data)
                {
                    if (dolznost == item.Dolznost)
                    {
                        searchjson(item);
                    }
                }
            }
            if (pos == 9)
            {
                double zp = Convert.ToDouble(Console.ReadLine());
                foreach (var item in data)
                {
                    if (zp == item.Zarplata)
                    {
                        searchjson(item);
                    }
                }
            }
            if (pos == 10)
            {
                int id_sot = Convert.ToInt32(Console.ReadLine());
                foreach (var item in data)
                {
                    if (id_sot == item.ID_Sot)
                    {
                        searchjson(item);
                    }
                }
            }
            ShowInfo(name, role, "Admin\\Search.json");
        }
        private void searchjson(Kadrovik item)
        {
            var data = convert.Jsonviser<List<Kadrovik>>("Admin\\Search.json", "Search");
            List<Kadrovik> list = new List<Kadrovik>();
            Kadrovik kadrov = new Kadrovik();
            kadrov.ID = item.ID;
            kadrov.Name = item.Name;
            kadrov.Surname = item.Surname;
            kadrov.Middlename = item.Middlename;
            kadrov.Dolznost = item.Dolznost;
            kadrov.DateOfBirth = item.DateOfBirth;
            kadrov.Zarplata = item.Zarplata;
            kadrov.ID_Sot = item.ID_Sot;
            kadrov.Pasport = item.Pasport;
            if (data == null)
            {
                list.Add(kadrov);
                convert.Jsonser(list, "Admin\\Search.json");
            }
            else
            {
                data.Add(kadrov);
                convert.Jsonser(data, "Admin\\Search.json");
            }
        }
    }
}