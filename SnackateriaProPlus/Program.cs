using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.greenzeta.snacklib;

namespace SnackateriaProPlus
{

    public class MenuItemExtraChubby : MenuItemLarge
    {

        public MenuItemExtraChubby(IMenuItem pMenuItem) : base(pMenuItem)
        {
        }

        public override string GetSize()
        {
            return "XDC";
        }

        public override double GetPrice()
        {
            return base.GetPrice()*2;
        }
    }

    class Program
    {

        static void SetUpMenu(List<IMenuItem> pMenu)
        {
            pMenu.Add(new MenuItem() { name = "Popcorn", price = 8.99 });
            pMenu.Add(new MenuItem() { name = "Soda", price = 9.99 });
            pMenu.Add(new MenuItem() { name = "Candy", price = 5.99 });
            pMenu.Add(new MenuItem() { name = "Nachos", price = 4.99 });
            pMenu.Add(new MenuItem() { name = "Hot Dog", price = 7.99 });
            pMenu.Add(new MenuItem() { name = "Hot Wing", price = 7.99 });
        }

        static void PrintMenu(List<IMenuItem> pMenu)
        {
            string menuHead = " -----------------------------------------";
            Console.SetCursorPosition((Console.WindowWidth - menuHead.Length) / 2, Console.CursorTop);
            Console.WriteLine(menuHead);
            foreach( IMenuItem item in pMenu)
            {
                Console.SetCursorPosition((Console.WindowWidth - menuHead.Length) / 2, Console.CursorTop);
                Console.WriteLine("| " + item.name+" "+(new StringBuilder().Insert(0,".",(menuHead.Length - item.name.Length - (Math.Round(item.price, 2).ToString().Length) - 6)).ToString())+" $"+ Math.Round(item.price, 2).ToString() + " |");
            }
            Console.SetCursorPosition((Console.WindowWidth - menuHead.Length) / 2, Console.CursorTop);
            Console.WriteLine(menuHead);

        }

        static void Main(string[] args)
        {
            // Set the console for unicode
            System.Console.OutputEncoding = System.Text.Encoding.Unicode;

            string strOrder = "";
            double dTotal = 0;
            List<IMenuItem> lMenu = new List<IMenuItem>();
            List<IMenuItemWithSize> lOrder = new List<IMenuItemWithSize>();

            IMenuItem selectedItem;

            //Set up the menu
            SetUpMenu(lMenu);

            Console.SetCursorPosition((Console.WindowWidth - "Welcome to the Snackateria.".Length) / 2, Console.CursorTop);
            Console.WriteLine("Welcome to the Snackateria.");
            PrintMenu(lMenu);

            Console.WriteLine("I'm Chet.");
            Console.WriteLine("May I have your order?");

            // Welcome to the Snackaterium.
            // I'm... uh... Mitch.
            // Can I help your order?
            // I mean... Can you order?
            // No no...
            // I mean... Lemme start over, okay?
            // -- ahem --
            // Welcome to the Snackaterium.
            // I'm Mitch.
            // Can I HAVE your order.

            while (strOrder.ToLower() != "no")
            {
                strOrder = Console.ReadLine();

                selectedItem = null;
                for (int idx = 0; idx < lMenu.Count; idx++)
                {
                    if (strOrder.ToLower().Contains(lMenu[idx].name.ToLower()))
                    {
                        selectedItem = lMenu[idx];
                    }
                }

                if (selectedItem != null)
                {
                    Console.WriteLine("What size? We have (L)arge, (C)hubby, and (D)ouble Super Chubby\u2122!");
                    strOrder = Console.ReadLine();

                    switch (strOrder.ToUpper())
                    {
                        case "L":
                            lOrder.Add(new MenuItemLarge(selectedItem));
                            break;
                        case "C":
                            lOrder.Add(new MenuItemChubby(selectedItem));
                            break;
                        case "D":
                            lOrder.Add(new MenuItemDoubleChubby(selectedItem));
                            break;
                        case "X":
                            lOrder.Add(new MenuItemExtraChubby(selectedItem));
                            break;
                        default:
                            Console.WriteLine("Uhh... I'll have to ask my manager.");
                            break;
                    }

                    Console.WriteLine("One " + selectedItem.name + ". Anything else?");
                }
            }

            Console.WriteLine("       Receipt       ");
            Console.WriteLine("---------------------");
            for ( int idx=0; idx<lOrder.Count; idx++)
            {
                dTotal += lOrder[idx].GetPrice();
                Console.WriteLine(lOrder[idx].GetName()+"("+lOrder[idx].GetSize()+")" );
            }
            Console.WriteLine("---------------------");
            Console.WriteLine("Total:         $"+Math.Round(dTotal,2));
            Console.ReadLine();
        }
    }
}
