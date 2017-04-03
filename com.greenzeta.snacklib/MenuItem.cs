using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.greenzeta.snacklib
{
    public interface IMenuItem
    {
        string name { get; set; }
        double price { get; set; }
    }

    public class MenuItem : IMenuItem
    {
        public string name { get; set; }
        public double price { get; set; }
    }
}
