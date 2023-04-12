using System;
using System.Collections.Generic;
using System.Text;

namespace PokerGame
{
    public class Deck
    {
        public List<Card> Cards { get; private set; }
        private Random Rng = new Random();
        string [] AllCards = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "A", "J", "Q", "K" };
        string[] AllTypes = { "C", "D", "H", "S" };

        public Card GetCard()
        {
            Card gotten = Cards[0];
            Cards.Remove(gotten);
            return gotten;
        }

        public Deck(){
            Cards = new List<Card>();
            foreach (string card in AllCards)
            {
                foreach(string type in AllTypes)
                {
                    Cards.Add(new Card(card, type));
                }
            }
            Cards = Shuffle(Cards);
        }

        public  List<Card> Shuffle(List<Card> list){
            int n = list.Count*10;
            while (n > 1){
                n--;
                int k = Rng.Next(0, list.Count - 1);
                int k2 = Rng.Next(0, list.Count - 1);
                Card value = list[k];
                list[k] = list[k2];
                list[k2] = value;
            }
            return list;
        }
    }

   
}
