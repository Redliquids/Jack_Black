using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack_Black.Models
{
    public class Deck
    {
        // The Deck of cards.
        public List<Card> CardDeck { get; set; }
        // Used to get a random card in GetCard() function
        public Random RandomNr { get; set; }

        public Deck()
        {
            this.RandomNr = new Random();
            this.CardDeck = new List<Card>();

            string[] suitnames =
                { "of Spades", "of Hearts", "of Diamonds", "of Clubs" };

            // Foreach suit add 13 cards and the suit name to our list/deck of cards
            // This creates our deck of cards.
            foreach (string suit in suitnames)
            {
                // WARNING: This might create a bug making no card have the Value of 1
                // Meaning the deck will have no Ace's
                // To fix this simply set: int i = 0;
                for (int i = 1; i < 14; i++)
                {
                    CardDeck.Add(new Card(suit, i));
                }
            }
        }


        public Card GetCard()
        {
            // Gets random Card in the list of cards (our deck)
            int indexpos = RandomNr.Next(CardDeck.Count);
            // retVal = the random card we drew.
            Card retVal = CardDeck[indexpos];
            // remove the card we drew from the deck
            CardDeck.RemoveAt(indexpos);

            return retVal;
        }
    }
}
