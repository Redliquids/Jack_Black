using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jack_Black.Models;

namespace Jack_Black.Models
{
    public class Player
    {
        public string PlayerName { get; set; }
        public List<Card> PlayerCards { get; set; }

        public Player(string playerName)
        {
            this.PlayerName = playerName;
            this.PlayerCards = new List<Card>();
        }

        // ISSUE: AddCardToPlayer() doesn't remove a card
        // at the position we draw it from
        // So there's a chance to draw the same card twice.
        public void AddCardToHand(Card card)
        {
            PlayerCards.Add(card);
        }

        // Calculates the value/points of the cards 
        public int GetValue()
        {
            int points = 0;

            for (int i = 0; i < PlayerCards.Count; i++)
            {

                // If the nr value of the first card drawn is 1 
                // it is an Ace and should add 11 points.
                if (PlayerCards[i].Nr == 1)
                {
                    points += 11;
                }
                // "Normal Nr Cards"
                else if (PlayerCards[i].Nr > 1 && PlayerCards[i].Nr < 10)
                {
                    points += PlayerCards[i].Nr;
                }
                // Else is Jack, Quueen and King and are worth 10 Points.
                else
                {
                    points += 10;
                }

                //This checks the players cards for aces
                //And sets their values appropriately.
                    if (points > 21)
                {
                    int aceCount = 0;
                    foreach (Card Card in PlayerCards)
                    {
                        if (Card.Nr == 1)
                        {
                            aceCount++;
                        }
                    }
                    points -= (aceCount * 10);
                }
            }
            return points;

        }

        public string GetCardInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Card c in PlayerCards)
            {
                sb.Append(c.CardReturner() + Environment.NewLine);
            }
            return sb.ToString();

        }

        public void HandReset()
        {
            PlayerCards.Clear();
            
        }

    }
}
