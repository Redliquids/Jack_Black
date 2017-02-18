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
        //This Function takes Cards and adds it to the PlayerCards List
        public void AddCardToPlayer(Card card)
        {
            PlayerCards.Add(card);
        }

        
        public int GetValue()
        {
            int points = 0;//Part of GetValue
            // Int i will be less than PlayerCards.Count everytime i draw a card.
            // Therefore it will run everytime i draw a card.
            // Should also be called everytime i draw a card.
            for (int i = 0; i < PlayerCards.Count; i++)
                // It seems this doesnt work propperly,
                // It doesnt check the values & add the values of each card
            {

                //If PlayerCards[thecard].it's assigned nr == 1
                // set points to 11 (cus 1 == ace == 11)
                if (PlayerCards[i].Nr == 1)
                {
                    points += 11;
                }
                //if the pulled card is 2-10, set that value to the score
                //Cus it's just a normal card.
                else if (PlayerCards[i].Nr > 1 && PlayerCards[i].Nr < 10)
                {
                    points += PlayerCards[i].Nr;
                }
                //The Knight,King & Queens values are 10, which are the only
                //Cards left. Therefore set the rest to 10 Almost like exception handling
                else
                {
                    points += 10;
                }


                // Ace value Checker ONLY IF  POINTS > 21
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
                    // points = points - ("Either 1 || 10);
                    points -= (aceCount * 10);
                    // It wurks!
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
