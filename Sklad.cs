using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static proverka324.Enum;

namespace proverka324
{
    internal class Sklad : AdminTable
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
            List<SkladList> sklads = new List<SkladList>();
            SkladList sklad = new SkladList();
            Console.WriteLine($"\t\tДобрый день {name}");
            Console.SetCursorPosition(50, 0);
            Console.WriteLine($"Роль: {role}");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(50, 2);
            Console.WriteLine("S - Сохранить");
            Console.SetCursorPosition(50, 3);
            Console.WriteLine("Backspace - Вернуться к регистрации");
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("  Введите ID: ");
            Console.WriteLine("  Введите Название: ");
            Console.WriteLine("  Введите Цену за штуку: ");
            Console.WriteLine("  Введите Количество на складе: ");
            while (true)
            {
                int pos = strelka.show(2, 5);
                if (pos == (int)klavishi.nazad)
                {
                    return;
                }
                else if (pos == 2)
                {
                    Console.SetCursorPosition(14, 2);
                    sklad.ID = Convert.ToInt32(Console.ReadLine());
                }
                else if (pos == 3)
                {
                    Console.SetCursorPosition(20, 3);
                    sklad.Name = Console.ReadLine();
                }
                else if (pos == 4)
                {
                    Console.SetCursorPosition(25, 4);
                    sklad.Price = Convert.ToInt32(Console.ReadLine());
                }
                else if (pos == 5)
                {
                    Console.SetCursorPosition(32, 5);
                    sklad.Colvo = Convert.ToInt32(Console.ReadLine());
                }
                else if (pos == (int)klavishi.safe)
                {
                    break;
                }
            }
            try
            {
                var data1 = convert.Jsonviser<List<SkladList>>($"Admin\\{role}.json", role);
                data1.Add(sklad);
                convert.Jsonser(data1, $"Admin\\{role}.json");
            }
            catch (Exception)
            {
                sklads.Add(sklad);
                convert.Jsonser(sklads, $"Admin\\{role}.json");
            }
            return;
        }
        public override int vivod(string path, string role)
        {
            int j = 3;
            var data = convert.Jsonviser<List<SkladList>>(path, role);
            Console.SetCursorPosition(5, 2);
            Console.WriteLine("ID:");
            Console.SetCursorPosition(10, 2);
            Console.WriteLine("Название:");
            Console.SetCursorPosition(25, 2);
            Console.WriteLine("Цена за штуку:");
            Console.SetCursorPosition(45, 2);
            Console.WriteLine("Кол-во на складе:");
            if (data != null)
            {
                foreach (var item in data)
                {
                    Console.SetCursorPosition(5, j);
                    Console.WriteLine(item.ID);
                    Console.SetCursorPosition(10, j);
                    Console.WriteLine(item.Name);
                    Console.SetCursorPosition(25, j);
                    Console.WriteLine(item.Price);
                    Console.SetCursorPosition(45, j);
                    Console.WriteLine(item.Colvo);
                    j++;
                }
            }
            return j;
        }
        public override int vivodRead(int pos, string role)
        {

            Console.SetCursorPosition(0, 2);
            var data = convert.Jsonviser<List<SkladList>>($"Admin\\{role}.json", role);
            var info = data[pos];
            Console.WriteLine("  ID: " + info.ID);
            Console.WriteLine("  Название: " + info.Name);
            Console.WriteLine("  Цена за штуку: " + info.Price);
            Console.WriteLine("  Кол-во на складе: " + info.Colvo);
            int poos = strelka.show(2, 5);
            return poos;
        }
        public override void Update(int poos, int pos, string role)
        {
            var data = convert.Jsonviser<List<SkladList>>($"Admin\\{role}.json", role);
            SkladList first = data[pos];
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
                Console.SetCursorPosition(17, 4);
                first.Price = Convert.ToInt32(Console.ReadLine());
                data[pos] = first;
            }
            else if (poos - 2 == 3)
            {
                Console.SetCursorPosition(20, 5);
                first.Colvo = Convert.ToInt32(Console.ReadLine());
                data[pos] = first;
            }
            convert.Jsonser(data, $"Admin\\{role}.json");
        }
        public override void Delete(int pos, string role)
        {
            var data = convert.Jsonviser<List<SkladList>>($"Admin\\{role}.json", role);
            data.RemoveAt(pos);
            convert.Jsonser(data, $"Admin\\{role}.json");
        }
        public override void Search(string name, string role)
        {
            var data = convert.Jsonviser<List<SkladList>>($"Admin\\{role}.json", role);
            Console.WriteLine($"\t\tДобрый день {name}");
            Console.SetCursorPosition(50, 0);
            Console.WriteLine($"Роль: {role}");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("  ID");
            Console.WriteLine("  Название");
            Console.WriteLine("  Цена за штуку");
            Console.WriteLine("  Количество на складе");
            int pos = strelka.show(2, 5);
            Console.SetCursorPosition(0, 6);
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
                    if (price == item.Price)
                    {
                        searchjson(item);
                    }
                }
            }
            if (pos == 5)
            {
                int colvo = Convert.ToInt32(Console.ReadLine());
                foreach (var item in data)
                {
                    if (colvo == item.Colvo)
                    {
                        searchjson(item);
                    }
                }
            }
            ShowInfo(name, role, "Admin\\Search.json");
        }
        private void searchjson(SkladList item)
        {
            var data = convert.Jsonviser<List<SkladList>>("Admin\\Search.json", "Search");
            List<SkladList> list = new List<SkladList>();
            SkladList sklad = new SkladList();
            sklad.ID = item.ID;
            sklad.Name = item.Name;
            sklad.Price = item.Price;
            sklad.Colvo = item.Colvo;
            if (data == null)
            {
                list.Add(sklad);
                convert.Jsonser(list, "Admin\\Search.json");
            }
            else
            {
                data.Add(sklad);
                convert.Jsonser(data, "Admin\\Search.json");
            }
        }
    }
    
}