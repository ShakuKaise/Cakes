using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cakes
{
    internal class Cake
    {
        public int FormPrice;       // 1
        public int SizePrice;       // 2
        public int TastePrice;      // 3
        public int AmountPrice;     // 4
        public int GlazePrice;      // 5
        public int DecorationPrice; // 6
        public int AllPrice;
        public string form;         // 1
        public string size;         // 2
        public string taste;        // 3
        public string amount;       // 4
        public string glaze;        // 5
        public string decoration;   // 6
        public string AllOptions;

        public Cake(int formPrice, int sizePrice, int tastePrice, int amountPrice, int glazePrice, int decorationPrice, int allPrice, string form, string size, string taste, string amount, string glaze, string decoration, string allOptions)
        {
            FormPrice = formPrice;
            SizePrice = sizePrice;
            TastePrice = tastePrice;
            AmountPrice = amountPrice;
            GlazePrice = glazePrice;
            DecorationPrice = decorationPrice;
            AllPrice = allPrice;
            this.form = form;
            this.size = size;
            this.taste = taste;
            this.amount = amount;
            this.glaze = glaze;
            this.decoration = decoration;
            AllOptions = allOptions;
        }
    }
}