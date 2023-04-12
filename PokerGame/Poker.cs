using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PokerGame
{
    public partial class Poker : PictureBox
    {
        public Card Card { get; set; }
        private bool IsSelect { get; set; } = false;
        public string PlayerName { get; set; }
        public bool IsShow { get; set; } = false;
        public string Type { get; set; }
        public Poker()
        {
            InitializeComponent();
        }

        public void SetNull()
        {
            BackColor = Color.Transparent;
            Card = null;
        }
        public bool IsSelete()
        {
            if (IsFill())
            {
                return IsSelect;
            }
            else
            {
                return false;
            }
        }
        public void Select()
        {
            if (!IsFill())
            {
                return;
            }
            if (IsSelect)
            {
                return;
            }
            var p = this.Location;
            if (Type == "Player")
            {
                p.Offset(0, -30);
            }
            else if (Type == "AI1")
            {
                p.Offset(30, 0);
            }
            else if (Type == "AI2")
            {
                p.Offset(0, 30);
            }
            else if (Type == "AI3")
            {
                p.Offset(-30, 0);
            }
            this.Location = p;
            IsSelect = true;
        }

        public void UnSelect()
        {
            if (!IsFill())
            {
                return;
            }
            if (!IsSelect)
            {
                return;
            }
            var p = this.Location;
            if (Type == "Player")
            {
                p.Offset(0, 30);
            }
            else if (Type == "AI1")
            {
                p.Offset(-30, 0);
            }
            else if (Type == "AI2")
            {
                p.Offset(0, -30);
            }
            else if (Type == "AI3")
            {
                p.Offset(30, 0);
            }
            this.Location = p;
            IsSelect = false;
        }

        public void CardClick(object sender, EventArgs e)
        {
            if (IsSelect)
            {
                UnSelect();
            }
            else
            {
                Select();
            }
        }

        /// <summary>
        /// 填充牌
        /// </summary>
        /// <param name="card"></param>
        internal void Fill(Card card)
        {
            if (Type == "Player")
            {
                this.Click += this.CardClick;
            }
            Card = card;
            if (IsShow)
            {
                this.Image = card.Image;
            }
            else
            {
                this.Image = Image.FromFile("./png/back.png");
            }
            UnSelect();
            this.Visible = true;
        }

        /// <summary>
        /// 取出牌
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        internal Card UnFill()
        {
            if(Type == "Player")
            {
                this.Click -= this.CardClick;
            }
            this.Image = null;
            var card = Card;
            UnSelect();
            SetNull();
            this.Visible = false;
            return card;
        }

        internal bool IsFill()
        {
            return Card != null;
        }
    }
}
