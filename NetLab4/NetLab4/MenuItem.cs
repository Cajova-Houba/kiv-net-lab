using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLab4
{

    public class MenuFuncArgs
    {

    }

    public delegate void MenuFunc(MenuFuncArgs args = null);

    public class MenuItem
    {

        public char HotKey { get; set; }

        public string Title { get; set; }

        public MenuFunc Func { get; set; }
        
    }

    public class Menu
    {
        public Dictionary<char, MenuItem> Items { get; set; } = new Dictionary<char, MenuItem>();

        public void AddMenuItem(MenuItem item)
        {
            Items.Add(item.HotKey, item);
        }

        public void Print()
        {
            foreach(var keyvalue in Items)
            {
                Console.WriteLine($"{keyvalue.Key}: {keyvalue.Value.Title}");
            }
        }

        public void Execute(char key)
        {
            MenuItem item;
            if (Items.TryGetValue(key, out item))
            {
                item.Func();
            }
        }
    }
}
