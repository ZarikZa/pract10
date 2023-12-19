
using proverka324;
using System.Diagnostics;
using System.Linq;

class Program
{ 
    static void Main(string[] args)
    {
        string login = "";
        List<char> password = new List<char>();
        string role = "";
        string pasw = "";
        string name = "";
        while (true)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Directory.CreateDirectory(desktop + "\\Admin");
            List<Admin> data = convert.Jsonviser<List<Admin>>("Admin\\Админ.json", "Админ");
            if (data == null)
            {
                List<Admin> admins = new List<Admin>();
                Admin admin = new Admin();
                admin.Login = "admin";
                admin.Password = "admin";
                admin.Role = "Админ";
                admins.Add(admin);
                convert.Jsonser(admins, "Admin\\Админ.json");
                data = convert.Jsonviser<List<Admin>>("Admin\\Админ.json", "Админ");
            }
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("\t\t\tИнформационная система табачный магазин 10_ЛАБА_ПРОСТО_ЖЕСТЬ");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("  Логин: ");
            Console.WriteLine("  Пароль: ");
            Console.WriteLine("  Авторизоваться");
            int pos = strelka.show(2, 4);
            switch (pos)
            {
                case 2:
                    Console.SetCursorPosition(9, pos);
                    login = Console.ReadLine();
                    break;
                case 3:
                    ConsoleKeyInfo pasword;
                    int i = 10;
                    Console.SetCursorPosition(10, pos);
                    while (true)
                    {
                        pasword = Console.ReadKey(true);
                        if (pasword.Key == ConsoleKey.Enter)
                        {
                            foreach (char r in password)
                            {
                                pasw += r;
                            }
                            password.Clear();
                            Console.SetCursorPosition(0, pos);
                            break;
                        }
                        if (pasword.Key == ConsoleKey.Backspace)
                        {
                            i--;
                            password.Remove(password.Last());
                            Console.SetCursorPosition(i, pos);
                            Console.Write(" ");
                        }
                        else
                        {
                            char charr = Convert.ToChar(pasword.KeyChar);
                            password.Add(charr);
                            Console.Write("*");
                            i++;
                        }
                    }
                    break;
                case 4:
                    foreach (var item in data)
                    {
                        if (login == item.Login)
                        {
                            if (pasw == item.Password)
                            { 
                                role = item.Role;
                                pasw = "";
                                var datakad = convert.Jsonviser<List<Kadrovik>>("Admin\\Кадровик.json", "Кадровик");
                                if (datakad != null)
                                {
                                    foreach(var k in datakad)
                                    {
                                        if (item.ID == k.ID_Sot)
                                        {
                                            name = k.Name;
                                        }
                                    }
                                }
                                break;
                            }
                        }
                    }
                    if (role == "Админ")
                    {
                        AdminTable adminTable = new AdminTable();
                        if (name != "")
                        {
                            adminTable.ShowInfo(name, role, $"Admin\\{role}.json"); 
                        }
                        else
                        {
                            adminTable.ShowInfo("Админ", role, $"Admin\\{role}.json"); 
                        }
                    }
                    if (role == "Кадровик")
                    {
                        Kadr kadrov = new Kadr();
                        if (name != "")
                        {
                            kadrov.ShowInfo(name, role, $"Admin\\{role}.json"); 
                        }
                        else
                        {
                            kadrov.ShowInfo("Кадровик", role, $"Admin\\{role}.json"); 
                        }
                    }
                    if (role == "Склад-менеджер")
                    {
                        Sklad sklad = new Sklad();
                        if (name != "")
                        {
                            sklad.ShowInfo(name, role, $"Admin\\{role}.json"); 
                        }
                        else
                        {
                            sklad.ShowInfo("Склад-менеджер", role, $"Admin\\{role}.json"); 
                        }
                    }
                    if (role == "Кассир")
                    {
                        Kassir Kassa = new Kassir();
                        if (name != "")
                        {
                            Kassa.ShowInfo(name, role); 
                        }
                        else
                        {
                            Kassa.ShowInfo("Кассир", role); 
                        }
                    }
                    if (role == "Бухгалтер")
                    {
                        Buhalter buh = new Buhalter();
                        if (name != "")
                        {
                            buh.ShowInfo(name, role, $"Admin\\{role}.json"); 
                        }
                        else
                        {
                            buh.ShowInfo("Бухгалтер", role, $"Admin\\{role}.json"); 
                        }
                    }
                    break;
            }
        }
    }
}