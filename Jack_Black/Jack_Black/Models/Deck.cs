using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack_Black.Models
{
    public class Deck
    {
        public List<Card> CardDeck { get; set; }
        public Random RandomNr { get; set; }

        public Deck()
        {
            this.RandomNr = new Random();//Instantiated in this Constructor cus i use it in drawCard();
            this.CardDeck = new List<Card>();

            string[] suitnames =
                { "of Spades", "of Hearts", "of Diamonds", "of Clubs" };

            foreach (string suit in suitnames)
            {
                for (int i = 1; i <= 13; i++)
                {
                    CardDeck.Add(new Card(suit, i));
                }
            }
        }

        public Card GetCard()
        {
            int indexpos = RandomNr.Next(CardDeck.Count);
            Card retVal = CardDeck[indexpos];
            CardDeck.RemoveAt(indexpos);

            return retVal;
        }

        public void DeckReset()
        {
            CardDeck.Clear();
        }
    }
}
