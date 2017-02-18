using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack_Black.Models
{
    public class Card
    {
        public string Suit { get; set; }
        public int Nr { get; set; }

        public Card(string suit, int nr)
        {
            this.Suit = suit;
            this.Nr = nr;

        }

        // returns Card information in a string
        public string CardReturner()
        {
            StringBuilder CardInfo = new StringBuilder();

            //if (Nr == 10)
            switch (Nr)
            {
                case 1:
                    CardInfo.Append("Ace");
                    break;
                case 11:
                    CardInfo.Append("Jack");
                    break;
                case 12:
                    CardInfo.Append("Queen");
                    break;
                case 13:
                    CardInfo.Append("King");
                    break;
                default:
                    CardInfo.Append(Nr);
                    break;
            }
            CardInfo.Append(" " + Suit);
            return CardInfo.ToString();
        }
    }
}
