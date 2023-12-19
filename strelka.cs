using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static proverka324.Enum;

namespace proverka324
{
    internal class strelka
    {
        public static int show(int minstrelka, int maxstrelka)
        {
            int pos = minstrelka;
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey();
                Console.SetCursorPosition(0, pos);
                Console.WriteLine("  ");
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (pos == minstrelka)
                    {
                        pos = maxstrelka;
                    }
                    pos--;
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (pos == maxstrelka)
                    {
                        pos = minstrelka;
                    }
                    pos++;
                }
                if (key.Key == ConsoleKey.Backspace)
                {
                    Console.Clear();
                    return (int)klavishi.nazad;
                }
                else if (key.Key == ConsoleKey.F1)
                {
                    return (int)klavishi.create;
                }
                else if (key.Key == ConsoleKey.Delete)
                {
                    return (int)klavishi.delte;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    return pos;
                }
                else if (key.Key == ConsoleKey.S)
                {
                    return (int)klavishi.safe;
                }
                else if (key.Key == ConsoleKey.OemPlus)
                {
                    return (int)klavishi.plus;
                }
                else if (key.Key == ConsoleKey.OemMinus)
                {
                    return (int)klavishi.minus;
                }
                else if (key.Key == ConsoleKey.F2)
                {
                    return (int)klavishi.search;
                }
                Console.SetCursorPosition(0, pos);
                Console.WriteLine("->");
            } while (key.Key != ConsoleKey.Enter);
            return pos;
        }
    }
}