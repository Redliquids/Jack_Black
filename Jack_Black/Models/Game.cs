using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jack_Black.Models;

namespace Jack_Black.Models
{
    public class Game
    {

        public Deck deck { get; set; }
        public Player player { get; set; }
        public Dealer dealer { get; set; }

        public Game()
        {
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||");
            Console.WriteLine("||||| Welcome To The BlackJack Table |||||");
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||");


            deck = new Deck();
            dealer = new Dealer();
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            player = new Player(name);

            StartGame();
        }

        public void StartGame()
        {
            dealer.AddCardToHand(
                deck.GetCard());
            player.AddCardToHand(
                deck.GetCard());

            ShowPlayersCards();
            HitOrStay();//Asks user to draw a card or stay
        }

        public void ShowPlayersCards()
        {
            Console.Clear();
            Console.Write("Dealers Points: ");
            Console.WriteLine(dealer.GetValue());// Whenever i use GetValue() i also add?

            Console.WriteLine();

            //Console.Write("Players Cards: ");
            //Console.Write(testplayer.PlayerName + " ");


                Console.WriteLine("Your Points: " + player.GetValue());
            Console.WriteLine(player.GetCardInfo());

            Console.WriteLine();
            Console.WriteLine();

            HitOrStay();
        }

        public void HitOrStay()
        {
            Console.WriteLine();
            //Console.WriteLine("Your Current Value: " + testplayer.GetValue());
            // getValue() seems to add card?

            Console.WriteLine();
            Console.WriteLine("F For Hit");
            Console.WriteLine("S For Stay");


            Console.WriteLine();

            char choice = Console.ReadKey().KeyChar;

            switch (choice)
            {
                case 'f':
                    Console.WriteLine();
                    Hit();
                    break;
                case 's':
                    Console.WriteLine();
                    Stay();
                    break;
                default:
                    ShowPlayersCards();
                    break;
            }

            Console.ReadKey();
        }

        //Adds random card to player from the deck list.
        public void Hit()
        {
            player.AddCardToHand(deck.GetCard());

            if (player.GetValue() > 21)
            {
                PlayerBusted();
            }
            else
            {
                ShowPlayersCards();
            }
        }

        public void Stay()
        {
            Console.Write("Dealers Cards: ");
            do
            {
                dealer.AddCardToHand(deck.GetCard());

            } while (dealer.GetValue() < player.GetValue());

            Console.WriteLine(dealer.GetCardInfo());

            if (dealer.GetValue() > 21)
            {
                DealerBusted();
            }
            else
            {

                Console.Write("Dealers Points: ");
                Console.WriteLine(dealer.GetValue());

                Console.WriteLine("House Wins.");
                Console.WriteLine("Press any key to Continue.");
                Console.ReadKey();
                QuitOrGoAgain();


            }
        }
        public void DealerBusted()
        {
            Console.WriteLine("House is over 21 and is busted.");
            Console.WriteLine();
            Console.WriteLine("YOU WIN!");
            Console.WriteLine();
            QuitOrGoAgain();
        }
        public void PlayerBusted()
        {
            Console.WriteLine("Over 21. Busted.");
            Console.WriteLine();
            QuitOrGoAgain();
        }

        public void QuitOrGoAgain()
        {
            Console.WriteLine("Press 1. To Play Again");
            Console.WriteLine("Press 2. To Quit");

            char input = Console.ReadKey().KeyChar;

            switch (input)
            {
                case '1':
                    Reset();
                    break;
                case '2':
                    Environment.Exit(0);
                    break;
                default:
                    QuitOrGoAgain();
                    break;
            }
        }
        public void Reset()
        {
            Console.Clear();
            player.HandReset();
            dealer.HandReset();
            StartGame();
        }
    }
}
