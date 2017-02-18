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

        public Deck testdeck { get; set; }
        public Player testplayer { get; set; }
        public Dealer testdealer { get; set; }

        public Game()
        {
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||");
            Console.WriteLine("||||| Welcome To The BlackJack Table |||||");
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||");


            testdeck = new Deck();
            testdealer = new Dealer();
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            testplayer = new Player(name);

            StartGame();
        }

        public void StartGame()
        {
            //testplayer/Dealer   both have the function AddCardToPlayer
            //Which takes a card using GetCard() from Deck.cs 
            //and adds it to their List<PlayerCards>
            testdealer.AddCardToPlayer(
                testdeck.GetCard());
            testplayer.AddCardToPlayer(
                testdeck.GetCard());
            //Both players draw a card.
            ShowPlayersCards();//Displays the cards
            HitOrStay();//Asks user to draw or stay
        }

        public void ShowPlayersCards()
        {
            Console.Clear();
            Console.Write("Dealers Points: ");
            Console.WriteLine(testdealer.GetValue());// Whenever i use GetValue() i also add?

            Console.WriteLine();

            //Console.Write("Players Cards: ");
            //Console.Write(testplayer.PlayerName + " ");


                Console.WriteLine("Your Points: " + testplayer.GetValue());
            Console.WriteLine(testplayer.GetCardInfo());

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

        //Currently the points checker doesnt work propperly.

        public void Hit()
        {
            testplayer.AddCardToPlayer(testdeck.GetCard());//Adds random card to player

            if (testplayer.GetValue() > 21)
            {
                PlayerBusted();
            }
            else
            {
                ShowPlayersCards();
            }
        }

        //Currently the points checker doesnt work propperly.
        public void Stay()
        {
            // Instructions say 17 or more. Why would you stop at 17 if player has 18
            // And you still have a chance to draw a card that beats his?
            Console.Write("Dealers Cards: ");
            do
            {
                testdealer.AddCardToPlayer(testdeck.GetCard());

            } while (testdealer.GetValue() < testplayer.GetValue());

            Console.WriteLine(testdealer.GetCardInfo());

            if (testdealer.GetValue() > 21)
            {
                DealerBusted();
            }
            else
            {

                Console.Write("Dealers Points: ");
                Console.WriteLine(testdealer.GetValue());

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
            testplayer.HandReset();
            testdealer.HandReset();
            StartGame();
        }
    }
}
