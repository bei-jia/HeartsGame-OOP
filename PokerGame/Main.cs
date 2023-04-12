using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokerGame
{
    public partial class Main : Form
    {
        Game Game { get; set; }
        public Main()
        {
            InitializeComponent();
            Game = new Game(btnConfirm);
            InitSlot(Game);
        }
        public void InitSlot(Game game)
        {
            game.Player.Add(P1Card1);
            game.Player.Add(P1Card2);
            game.Player.Add(P1Card3);
            game.Player.Add(P1Card4);
            game.Player.Add(P1Card5);
            game.Player.Add(P1Card6);
            game.Player.Add(P1Card7);
            game.Player.Add(P1Card8);
            game.Player.Add(P1Card9);
            game.Player.Add(P1Card10);
            game.Player.Add(P1Card11);
            game.Player.Add(P1Card12);
            game.Player.Add(P1Card13);
            game.Ai1.Add(poker1);
            game.Ai1.Add(poker2);
            game.Ai1.Add(poker3);
            game.Ai1.Add(poker4);
            game.Ai1.Add(poker5);
            game.Ai1.Add(poker6);
            game.Ai1.Add(poker7);
            game.Ai1.Add(poker8);
            game.Ai1.Add(poker9);
            game.Ai1.Add(poker10);
            game.Ai1.Add(poker11);
            game.Ai1.Add(poker12);
            game.Ai1.Add(poker13);
            game.Ai2.Add(poker14);
            game.Ai2.Add(poker15);
            game.Ai2.Add(poker16);
            game.Ai2.Add(poker17);
            game.Ai2.Add(poker18);
            game.Ai2.Add(poker19);
            game.Ai2.Add(poker20);
            game.Ai2.Add(poker21);
            game.Ai2.Add(poker22);
            game.Ai2.Add(poker23);
            game.Ai2.Add(poker24);
            game.Ai2.Add(poker25);
            game.Ai2.Add(poker26);
            game.Ai3.Add(poker27);
            game.Ai3.Add(poker28);
            game.Ai3.Add(poker29);
            game.Ai3.Add(poker30);
            game.Ai3.Add(poker31);
            game.Ai3.Add(poker32);
            game.Ai3.Add(poker33);
            game.Ai3.Add(poker34);
            game.Ai3.Add(poker35);
            game.Ai3.Add(poker36);
            game.Ai3.Add(poker37);
            game.Ai3.Add(poker38);
            game.Ai3.Add(poker39);
            game.Played.Add(played1);
            game.Played.Add(played2);
            game.Played.Add(played3);
            game.Played.Add(played4);
            game.Played.Add(played5);
            game.Played.Add(played6);
            game.Played.Add(played7);
            game.Played.Add(played8);
            game.Played.Add(played9);
            game.Played.Add(played10);
            game.Played.Add(played11);
            game.Played.Add(played12);
            game.Played.Add(played13);
            game.Played.Add(played14);
            game.Played.Add(played15);
            game.Played.Add(played16);
            game.Played.Add(played17);
            game.Played.Add(played18);
            game.Played.Add(played19);
            game.Played.Add(played20);
            game.Played.Add(played21);
            game.Played.Add(played22);
            game.Played.Add(played23);
            game.Played.Add(played24);
            game.Played.Add(played25);
            game.Played.Add(played26);
            game.Played.Add(played27);
            game.Played.Add(played28);
            game.Played.Add(played29);
            game.Played.Add(played30);
            game.Played.Add(played31);
            game.Played.Add(played32);
            game.Played.Add(played33);
            game.Played.Add(played34);
            game.Played.Add(played35);
            game.Played.Add(played36);
            game.Played.Add(played37);
            game.Played.Add(played38);
            game.Played.Add(played39);
            game.Played.Add(played40);
            game.Played.Add(played41);
            game.Played.Add(played42);
            game.Played.Add(played43);
            game.Played.Add(played44);
            game.Played.Add(played45);
            game.Played.Add(played46);
            game.Played.Add(played47);
            game.Played.Add(played48);
            game.Played.Add(played49);
            game.Played.Add(played50);
            game.Played.Add(played51);
            game.Played.Add(played52);
        }
        public void Start()
        {
            Game.Start();
            lblStatus.Text = Game.MainLogic("Swap 3 cards");
            btnConfirm.Visible = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if(Game.Stage == "Swap 3 cards")
                {
                    lblStatus.Text = Game.MainLogic("End swap");
                    btnConfirm.Visible = false;
                    lblStatus.Text = Game.MainLogic("Throw card");
                    btnConfirm.Visible = true;
                }
                else if (Game.Stage == "Throw card")
                {
                    lblStatus.Text = Game.MainLogic("End throw card",()=>
                    {
                        lblStatus.Text = Game.MainLogic("Throw card");
                        btnConfirm.Visible = true;
                    });
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



    }
}
