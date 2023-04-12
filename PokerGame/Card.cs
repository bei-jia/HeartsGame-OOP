using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PokerGame
{
    public class Card
    {
        public string Num { get; private set; }

        public string Type { get; private set; }

        public Image Image { get; private set; }

        public Image BackImage { get; private set; }

        public Card(string num, string type)
        {
            this.Num = num;
            this.Type = type;
            this.Image = Image.FromFile("./png/" + num + type + ".png");
        }

        public string getValue()
        {
            return Num;
        }
    }
}
