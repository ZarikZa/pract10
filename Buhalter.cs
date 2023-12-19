using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static proverka324.Enum;

namespace proverka324
{
    internal class Buhalter : AdminTable
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
            List<BuhalterList> buhalts = new List<BuhalterList>();
            BuhalterList buhal = new BuhalterList();
            Console.WriteLine($"\t\tДобрый день {name}");
            Console.SetCursorPosition(50, 0);
            Console.WriteLine($"Роль: {role}");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(50, 2);
            Console.WriteLine("S - Сохранить");
            Console.SetCursorPosition(50, 3);
            Console.WriteLine("Backspace - Вернуться в меню");
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("  Введите ID: ");
            Console.WriteLine("  Введите Название: ");
            Console.WriteLine("  Введите Сумму: ");
            Console.WriteLine("  Время записи(Автоматически): ");
            Console.WriteLine("  Прибавка(True/False): ");
            while (true)
            {
                int pos = strelka.show(2, 6);
                if (pos == (int)klavishi.nazad)
                {
                    return;
                }
                else if (pos == 2)
                {
                    Console.SetCursorPosition(14, 2);
                    buhal.ID = Convert.ToInt32(Console.ReadLine());
                }
                else if (pos == 3)
                {
                    Console.SetCursorPosition(20, 3);
                    buhal.Name = Console.ReadLine();
                }
                else if (pos == 4)
                {
                    Console.SetCursorPosition(17, 4);
                    buhal.Summa = Convert.ToDouble(Console.ReadLine());
                }
                else if (pos == 6)
                {
                    Console.SetCursorPosition(24, 6);
                    string pribavka = Console.ReadLine();
                    if (pribavka == "True")
                    {
                        buhal.Pribavka = true;
                    }
                    else if (pribavka == "False")
                    {
                        buhal.Summa *= (-1);
                        buhal.Pribavka = false;
                    }
                }
                else if (pos == (int)klavishi.safe)
                {
                    break;
                }
                buhal.DateZap = DateOnly.FromDateTime(DateTime.Now);
            }
            try
            {
                var data1 = convert.Jsonviser<List<BuhalterList>>($"Admin\\{role}.json", role);
                if (data1 != null)
                {
                    data1.Add(buhal);
                    convert.Jsonser(data1, $"Admin\\{role}.json");
                }
                else
                {
                    List<BuhalterList> buhalterLists = new List<BuhalterList>
                    {
                        buhal
                    };
                    convert.Jsonser(buhalterLists, $"Admin\\{role}.json");

                }
            }
            catch (Exception)
            {
                buhalts.Add(buhal);
                convert.Jsonser(buhalts, $"Admin\\{role}.json");
            }
            return;
        }
        public override int vivod(string path, string role)
        {
            int j = 3;
            var data = convert.Jsonviser<List<BuhalterList>>(path, role);
            Console.SetCursorPosition(5, 2);
            Console.WriteLine("ID:");
            Console.SetCursorPosition(10, 2);
            Console.WriteLine("Название:");
            Console.SetCursorPosition(25, 2);
            Console.WriteLine("Сумма:");
            Console.SetCursorPosition(35, 2);
            Console.WriteLine("Время записи:");
            Console.SetCursorPosition(65, 2);
            Console.WriteLine("Прибавка?");
            if (data != null)
            {
                foreach (var item in data)
                {
                    Console.SetCursorPosition(5, j);
                    Console.WriteLine(item.ID);
                    Console.SetCursorPosition(10, j);
                    Console.WriteLine(item.Name);
                    Console.SetCursorPosition(25, j);
                    Console.WriteLine(item.Summa);
                    Console.SetCursorPosition(35, j);
                    Console.WriteLine(item.DateZap);
                    Console.SetCursorPosition(65, j);
                    Console.WriteLine(item.Pribavka);
                    j++;
                }
            }
            Console.SetCursorPosition(0, j);
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            var dataSum = convert.Jsonviser<List<BuhalterList>>($"Admin\\{role}.json", role);
            double Itog = 0;
            if (dataSum != null)
            {
                foreach (var item in dataSum)
                {
                    Itog += item.Summa;
                }
            }
            Console.SetCursorPosition(65, j+1);
            Console.WriteLine("Итог: " + Itog);
            return j;
        }
        public override int vivodRead(int pos, string role)
        {
            Console.SetCursorPosition(0, 2);
            var data = convert.Jsonviser<List<BuhalterList>>($"Admin\\{role}.json", role);
            var info = data[pos];
            Console.WriteLine("  ID: " + info.ID);
            Console.WriteLine("  Название: " + info.Name);
            Console.WriteLine("  Сумма: " + info.Summa);
            Console.WriteLine("  Дата: " + info.DateZap);
            Console.WriteLine("  Прибавка: " + info.Pribavka);
            int poos = strelka.show(2, 6);
            return poos;
        }
        public override void Update(int poos, int pos, string role)
        {
            Console.SetCursorPosition(50, 5);
            Console.WriteLine("Дату менять нельзя");
            Console.SetCursorPosition(50, 6);
            Console.WriteLine("Введите True/False");
            var data = convert.Jsonviser<List<BuhalterList>>($"Admin\\{role}.json", role);
            BuhalterList first = data[pos];
            if (poos-2 == 0)
            {
                Console.SetCursorPosition(6, 2);
                first.ID = Convert.ToInt32(Console.ReadLine());
                data[pos] = first;
            }
            else if (poos-2 == 1)
            {
                Console.SetCursorPosition(12, 3);
                first.Name = Console.ReadLine();
                data[pos] = first;
            }
            else if (poos - 2 == 2)
            {
                Console.SetCursorPosition(9, 4);
                first.Summa = Convert.ToDouble(Console.ReadLine());
                data[pos] = first;
            }
            else if (poos - 2 == 3)
            {
                Console.SetCursorPosition(8, 5);
                Console.WriteLine("Дату менять нельзя!!!");
            }
            else if (poos-2 == 4)
            {
                Console.SetCursorPosition(12, 6);
                string pribavka = Console.ReadLine();
                if (pribavka == "True")
                {
                    first.Pribavka = true;
                }
                else if (pribavka == "False")
                {
                    first.Summa *= (-1);
                    first.Pribavka = false;
                }
                data[pos] = first;
            }
            convert.Jsonser(data, $"Admin\\{role}.json");
        }
        public override void Search(string name, string role)
        {
            var data = convert.Jsonviser<List<BuhalterList>>($"Admin\\{role}.json", role);
            Console.WriteLine($"\t\tДобрый день {name}");
            Console.SetCursorPosition(50, 0);
            Console.WriteLine($"Роль: {role}");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("  ID");
            Console.WriteLine("  Название");
            Console.WriteLine("  Сумма");
            Console.WriteLine("  Время записи");
            Console.WriteLine("  Прибавка(True/False)");
            int pos = strelka.show(2, 6);
            Console.SetCursorPosition(0, 8);
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
                string nameser = Console.ReadLine();
                foreach (var item in data)
                {
                    if (nameser == item.Name)
                    {
                        searchjson(item);
                    }
                }
            }
            if (pos == 4)
            {
                int price = Convert.ToInt32(Console.ReadLine());
                foreach (var item in data)
                {
                    if (price == item.Summa)
                    {
                        searchjson(item);
                    }
                }
            }
            if (pos == 5)
            {
                Console.WriteLine("Введите месяц:");
                int mounth = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите день:");
                int day = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите год:");
                int year = Convert.ToInt32(Console.ReadLine());
                DateOnly dateser = new DateOnly(year, mounth, day);
                foreach (var item in data)
                {
                    if (dateser == item.DateZap)
                    {
                        searchjson(item);
                    }
                }
            }
            if (pos == 6)
            {
                bool pribav = true;
                string pribavka = Console.ReadLine();
                if (pribavka == "True")
                {
                    pribav = true;
                }
                else if (pribavka == "False")
                {
                    pribav = false;
                }
                foreach (var item in data)
                {
                    if (pribav == item.Pribavka)
                    {
                        searchjson(item);
                    }
                }
            }
            ShowInfo(name, role, "Admin\\Search.json");
        }
        private void searchjson(BuhalterList item)
        {
            var data = convert.Jsonviser<List<BuhalterList>>("Admin\\Search.json", "Search");
            List<BuhalterList> list = new List<BuhalterList>();
            BuhalterList buh = new BuhalterList();
            buh.ID = item.ID;
            buh.Name = item.Name;
            buh.Summa = item.Summa;
            buh.DateZap = item.DateZap;
            buh.Pribavka = item.Pribavka;
            if (data == null)
            {
                list.Add(buh);
                convert.Jsonser(list, "Admin\\Search.json");
            }
            else
            {
                data.Add(buh);
                convert.Jsonser(data, "Admin\\Search.json");
            }
        }
    }
}