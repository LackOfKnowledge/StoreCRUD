using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using crudDemo2.Interfaces;

namespace crudDemo2.Models
{
    public class ResponseProvider : IResponseProvider
    {
        private readonly IViewer _viewer;
        private readonly IMenu _menu;

        public ResponseProvider(IViewer viewer, IMenu menu)
        {
            _viewer = viewer;
            _menu = menu;
        }
        public int GetIntFromUser(int maxValue)
        {
            int value = 0;
            bool canIParse = false;
            while(canIParse == false)
            {
                canIParse=int.TryParse(Console.ReadLine(), out value);
                if (!canIParse || value < 0 || value > maxValue) _viewer.ValueError(); 
            }
            return value;
        }

        public IItem GetItemFromUser(IItem item)
        {
            if (item is Smartphone)
            {
                item = GetSmartphone();
            }
            if (item is Notebook)
            {
                item = GetNotebook();
            }
            return item;
        }

        private IItem GetNotebook()
        {
            Console.WriteLine("Nazwa producenta");
            string manufacturer = Console.ReadLine();
            Console.WriteLine("Nazwa modelu");
            string models = Console.ReadLine();
            return new Notebook(manufacturer, models);
        }


        private IItem GetSmartphone()
        {
            Console.WriteLine("Nazwa producenta");
            string manufacturer = Console.ReadLine();
            Console.WriteLine("Nazwa modelu");
            string models = Console.ReadLine();
            return new Smartphone(manufacturer, models);
        }

        public SearchArguments SearchingArgumentFromUser(IItem item)
        {
            {
                string arg1, arg2;
                int arg3;
                if (item is Smartphone)
                {
                    _menu.InputDatThing(0);
                    arg1 = Console.ReadLine();
                    _menu.InputDatThing(1);
                    arg2 = Console.ReadLine();
                }
                else
                {
                    _menu.InputDatThing(0);
                    arg1 = Console.ReadLine();
                    _menu.InputDatThing(1);
                    arg2 = Console.ReadLine();
                }
                return new SearchArguments(arg1, arg2);
            }
        }
    }
}