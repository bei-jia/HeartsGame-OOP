using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokerGame
{
    public class Game
    {
        /// <summary>
        /// Deck
        /// </summary>
        public Deck Deck;
        /// <summary>
        /// Random number
        /// </summary>
        public Random Rng = new Random();
        /// <summary>
        /// Player cards
        /// </summary>
        public List<Poker> Player = new List<Poker>();
        /// <summary>
        /// cards for AI 1
        /// </summary>
        public List<Poker> Ai1 = new List<Poker>();
        /// <summary>
        /// cards for AI 2
        /// </summary>
        public List<Poker> Ai2 = new List<Poker>();
        /// <summary>
        /// cards for AI 3
        /// </summary>
        public List<Poker> Ai3 = new List<Poker>();
        /// <summary>
        /// cards for AI 4
        /// </summary>
        public List<Poker> Played = new List<Poker>();
        /// <summary>
        /// Round
        /// </summary>
        public int Round = 1;
        /// <summary>
        /// stage
        /// </summary>
        public string Stage = "";
        Button Btn;
        public Game(Button btn)
        {
            Deck = new Deck();
            Btn = btn;
        }

        public string GetStageStatus()
        {
            return $"Round:{Round},Trick:{Stage}";
        }

        /// <summary>
        /// Start game
        /// </summary>
        public void Start()
        {
            Deck = new Deck();
            Player.ForEach(e => { e.IsShow = true; e.Type = "Player"; e.Fill(Deck.GetCard());  });
            Ai1.ForEach(e => { e.IsShow = false; e.Type = "AI1"; e.Fill(Deck.GetCard());  });
            Ai2.ForEach(e => { e.IsShow = false; e.Type = "AI2"; e.Fill(Deck.GetCard());  });
            Ai3.ForEach(e => { e.IsShow = false; e.Type = "AI3"; e.Fill(Deck.GetCard());  });
            Played.ForEach(e => { e.IsShow = true; e.Type = "Played"; e.Visible = false; });
            Round = 1;
        }
        public string MainLogic(string stage,Action callback = null)
        {
            
            if (stage == "Swap 3 cards")
            {
                GetRngPoker(GetUnSelect(Ai1)).Select();
                GetRngPoker(GetUnSelect(Ai1)).Select();
                GetRngPoker(GetUnSelect(Ai1)).Select();
                GetRngPoker(GetUnSelect(Ai2)).Select();
                GetRngPoker(GetUnSelect(Ai2)).Select();
                GetRngPoker(GetUnSelect(Ai2)).Select();
                GetRngPoker(GetUnSelect(Ai3)).Select();
                GetRngPoker(GetUnSelect(Ai3)).Select();
                GetRngPoker(GetUnSelect(Ai3)).Select();
            }
            if (stage == "End swap")
            {
                var playerSelect = GetSelectPoker(Player);
                if(playerSelect.Count != 3)
                {
                    throw new Exception("You didn't pick 3 cards");
                }
                var a1Select = GetSelectPoker(Ai1);
                var a2Select = GetSelectPoker(Ai2);
                var a3Select = GetSelectPoker(Ai3);
                var ai1Card1 = GetSelectPoker(Ai1)[0].UnFill();
                var ai1Card2 = GetSelectPoker(Ai1)[0].UnFill();
                var ai1Card3 = GetSelectPoker(Ai1)[0].UnFill();
                TransPoker(playerSelect, Ai1);
                TransPoker(a3Select, Player);
                TransPoker(a2Select, Ai3);
                AddPoker(ai1Card1, Ai2);
                AddPoker(ai1Card2, Ai2);
                AddPoker(ai1Card3, Ai2);
            }
            if (stage == "End throw card")
            {
                var playerSelect = GetSelectPoker(Player);
                if (playerSelect.Count != 1)
                {
                    throw new Exception("You can only throw one card at a time");
                }
                TransPoker(playerSelect, Played);
                Task.Run(() =>
                {
                    Btn.Invoke(new Action(() =>
                    {
                        Btn.Visible = false;
                    }));
                    var a1 = GetRngPoker(Ai1);
                    Thread.Sleep(500);
                    Btn.Invoke(new Action(() =>
                    {
                        a1.Select();
                    }));
                    Thread.Sleep(500);
                    Btn.Invoke(new Action(() =>
                    {
                        TransPoker(a1, Played);
                    }));

                    var a2 = GetRngPoker(Ai2);
                    Thread.Sleep(500);
                    Btn.Invoke(new Action(() =>
                    {
                        a2.Select();
                    }));
                    Thread.Sleep(500);
                    Btn.Invoke(new Action(() =>
                    {
                        TransPoker(a2, Played);
                    }));

                    var a3 = GetRngPoker(Ai3);
                    Thread.Sleep(500);
                    Btn.Invoke(new Action(() =>
                    {
                        a3.Select();
                    }));
                    Thread.Sleep(500);
                    Btn.Invoke(new Action(() =>
                    {
                        TransPoker(a3, Played);
                        callback();
                    }));

                });



            }
            this.Stage = stage;
            return GetStageStatus();
        }

        /// <summary>
        /// 转移牌
        /// </summary>
        /// <param name="sps">牌</param>
        /// <param name="dps">要添加到的玩家牌组</param>
        /// <returns></returns>
        public void TransPoker(List<Poker> sps, List<Poker> dps)
        {
            sps.ForEach(e => TransPoker(e, dps));
        }

        /// <summary>
        /// 转移牌
        /// </summary>
        /// <param name="p">牌</param>
        /// <param name="dps">要添加到的玩家牌组</param>
        /// <returns></returns>
        public void TransPoker(Poker p, List<Poker> dps)
        {
            AddPoker(p.UnFill(), dps);
        }

        /// <summary>
        /// 添加牌
        /// </summary>
        /// <param name="p">牌</param>
        /// <param name="dps">要添加到的玩家牌组</param>
        /// <returns></returns>
        public void AddPoker(Card c, List<Poker> dps)
        {
            var unFill = GetUnFillPokerSlot(dps);
            unFill[0].Fill(c);
        }

        public void SortPokerSlot(List<Poker> dps)
        {

        }

        /// <summary>
        /// 获取一张随机牌位
        /// </summary>
        /// <param name="ps"></param>
        /// <returns></returns>
        public Poker GetRngPoker(List<Poker> ps)
        {
            var nps = GetFillPokerSlot(ps);
            return nps[Rng.Next(nps.Count)];
        }

        /// <summary>
        /// 获取未选择的牌
        /// </summary>
        /// <param name="ps"></param>
        /// <returns></returns>
        public List<Poker> GetUnSelect(List<Poker> ps)
        {
            return ps.Where(e => e.IsSelete() == false && e.IsFill()).ToList();
        }

        /// <summary>
        /// 获取选择的牌
        /// </summary>
        /// <returns></returns>
        public List<Poker> GetSelectPoker(List<Poker> ps)
        {
            return ps.Where(e => e.IsSelete()).ToList();
        }

        /// <summary>
        /// 获取填充了牌的牌位
        /// </summary>
        /// <returns></returns>
        public List<Poker> GetFillPokerSlot(List<Poker> ps)
        {
            return ps.Where(e => e.IsFill() == true).ToList();
        }

        /// <summary>
        /// 获取未填充牌的牌位
        /// </summary>
        /// <returns></returns>
        public List<Poker> GetUnFillPokerSlot(List<Poker> ps)
        {
            return ps.Where(e => e.IsFill() == false).ToList();
        }
    }
}
