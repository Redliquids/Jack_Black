using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack_Black.Models
{
    public class Dealer : Player
    {
        public List<Card> dealersCards { get; set; }

        // Dealer Inherits from Player and has it's name set to "Dealer"
        public Dealer()// It s eems :base("Dealer) is needed because it's a function in Player
            //And functions need the :base thing
            :base("Dealer")
        {
            PlayerCards = new List<Card>();
        }
    }
}
