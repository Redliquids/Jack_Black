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
        // This might make the dealersCard list a bit redundant but it needs
        // The function "AddCardToPlayer" in Player.cs
        public Dealer()
            // It seems :base("Dealer) is needed because it's a function in Player.cs
            //And functions need the :base thing
            : base("Dealer")
        {
            PlayerCards = new List<Card>();
        }
    }
}
