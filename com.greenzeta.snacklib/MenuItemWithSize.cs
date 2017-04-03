using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.greenzeta.snacklib
{
    public interface IMenuItemWithSize
    {
        void SetMenuItem(IMenuItem PmenuItem);
        string GetName();
        double GetPrice();
        string GetSize();

    }

    public class MenuItemLarge : IMenuItemWithSize
    {
        internal string name;
        internal double price;

        public MenuItemLarge()
        {

        }
        // Overlaod to pass menu item immediately in constructor
        public MenuItemLarge(IMenuItem pMenuItem)
        {
            this.SetMenuItem(pMenuItem);
        }

        public void SetMenuItem(IMenuItem pMenuItem)
        {
            this.name = pMenuItem.name;
            this.price = pMenuItem.price;
        }

        public string GetName()
        {
            return this.name;
        }

        virtual public double GetPrice()
        {
            return this.price;
        }

       virtual public string GetSize()
        {
            return "LRG";
        }

    }

    public class MenuItemChubby : MenuItemLarge
    {
        public MenuItemChubby(IMenuItem pMenuItem) : base(pMenuItem)
        {
            this.price *= 1.2;
        }

        public override string GetSize()
        {
            return "CHB";
        }
    }

    public class MenuItemDoubleChubby : MenuItemLarge
    {
        public MenuItemDoubleChubby(IMenuItem pMenuItem) : base(pMenuItem)
        {
            this.price *= 1.5;
        }

        public override string GetSize()
        {
            return "DBL";
        }
    }
}
