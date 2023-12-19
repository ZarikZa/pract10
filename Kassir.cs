using static proverka324.Enum;

namespace proverka324
{
    internal class Kassir
    {
        public void ShowInfo(string name, string role)
        {
            var data = convert.Jsonviser<List<KassirList>>($"Admin\\Склад-менеджер.json", role);
            List<KassirList> kassas = new List<KassirList>();
            foreach (var item in data)
            {
                KassirList kassa = new KassirList();
                kassa.ID = item.ID;
                kassa.Name = item.Name;
                kassa.Price = item.Price;
                kassas.Add(kassa);
            }
            convert.Jsonser(kassas, $"Admin\\{role}.json");
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"\t\tДобрый день {name}");
                Console.SetCursorPosition(50, 0);
                Console.WriteLine($"Роль: {role}");
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
                Console.SetCursorPosition(80, 2);
                Console.WriteLine("S - Завершить покупку");
                Console.SetCursorPosition(80, 3);
                Console.WriteLine("Backspace - Вернуться к регистрации");
                int j = vivod($"Admin\\{role}.json", role);
                int pos = strelka.show(3, j-1);
                if (pos == (int)klavishi.nazad)
                {
                    return;
                }
                if (pos == (int)klavishi.safe)
                {
                    return;
                }
                Read(pos, role);
            }
        }
        public int vivod(string path, string role)
        {
            int j = 3;
            var data = convert.Jsonviser<List<KassirList>>(path, role);
            Console.SetCursorPosition(5, 2);
            Console.WriteLine("ID:");
            Console.SetCursorPosition(10, 2);
            Console.WriteLine("Название:");
            Console.SetCursorPosition(25, 2);
            Console.WriteLine("Цена за штуку:");
            Console.SetCursorPosition(45, 2);
            Console.WriteLine("Количество:");
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
                    Console.SetCursorPosition(50, j);
                    Console.WriteLine(item.Colvol);
                    j++;
                }
            }
            return j;
        }
        private void Read(int pos, string role)
        {
            int colvo = 0;
            var data = convert.Jsonviser<List<SkladList>>($"Admin\\Склад-менеджер.json", role);
            while (true)
            {
                Console.Clear();
                var datakas = convert.Jsonviser<List<KassirList>>($"Admin\\{role}.json", role);
                Console.WriteLine("\t\tДобрый день админ");
                Console.SetCursorPosition(50, 0);
                Console.WriteLine($"Роль: {role}");
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
                Console.SetCursorPosition(80, 2);
                Console.WriteLine("S - Сохранить");
                Console.SetCursorPosition(80, 3);
                Console.WriteLine("+ - Увеличить количество товара");
                Console.SetCursorPosition(80, 4);
                Console.WriteLine("- - Уменьшить количество товар");
                Console.SetCursorPosition(80, 5);
                Console.WriteLine("Backspace - Вернуться");
                int poos = vivodRead(pos, role);
                if (poos == (int)klavishi.plus)
                {
                    colvo++;
                    if (data[pos-3].Colvo <= colvo)
                    {
                        colvo = data[pos-3].Colvo;
                    }
                }
                if (poos == (int)klavishi.minus)
                {
                    colvo--;
                    if (colvo <= 0)
                    {
                        colvo = 0;
                    }
                }
                if (poos == (int)klavishi.safe)
                {
                    List<BuhalterList> dataBuh2 = new List<BuhalterList> ();
                    List<BuhalterList> dataBuh = convert.Jsonviser<List<BuhalterList>>("Admin\\Бухгалтер.json", role);
                    BuhalterList buh = new BuhalterList();
                    buh.Name = datakas[pos-3].Name;
                    buh.Summa = datakas[pos-3].Colvol * datakas[pos-3].Price;
                    buh.DateZap = DateOnly.FromDateTime(DateTime.Now);
                    buh.Pribavka = true;
                    if (dataBuh != null)
                    {
                        dataBuh.Add(buh);
                        convert.Jsonser(dataBuh, "Admin\\Бухгалтер.json");
                    }
                    else
                    {
                        dataBuh2.Add(buh);
                        convert.Jsonser(dataBuh2, "Admin\\Бухгалтер.json");
                    }
                    data[pos-3].Colvo -= colvo;
                    convert.Jsonser(data, "Admin\\Склад-менеджер.json");
                    return;
                }
                if (poos == (int)klavishi.nazad)
                {
                    break;
                }
                datakas[pos-3].Colvol = colvo;
                convert.Jsonser(datakas, $"Admin\\{role}.json");
            }
        }
        public virtual int vivodRead(int pos, string role)
        {
            Console.SetCursorPosition(0, 2);
            var data = convert.Jsonviser<List<KassirList>>($"Admin\\{role}.json", role);
            var info = data[pos-3];
            Console.WriteLine("  ID: " + info.ID);
            Console.WriteLine("  Название: "  + info.Name);
            Console.WriteLine("  Цена за штуку: " + info.Price);
            Console.WriteLine("  Количество: " + info.Colvol);
            int poos = strelka.show(2, 5);
            return poos;
        }

    }
}