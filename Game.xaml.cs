using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Media.Animation;
using Cards;
using Tarneeb_Game_group3;
using static CardDisplayTake3.GameLogic;

namespace CardDisplayTake3
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class OrganizedCards : Window
    {
        /// <summary>
        /// Method for enabling cards to be put for player1
        /// </summary>
        public void EnableCards()
        {
            card1.IsEnabled = true;
            card2.IsEnabled = true;
            card3.IsEnabled = true;
            card4.IsEnabled = true;
            card5.IsEnabled = true;
            card6.IsEnabled = true;
            card7.IsEnabled = true;
            card8.IsEnabled = true;
            card9.IsEnabled = true;
            card10.IsEnabled = true;
            card11.IsEnabled = true;
            card12.IsEnabled = true;
            card13.IsEnabled = true;
        }

        /// <summary>
        /// Disabling the cards to be put for player1
        /// </summary>
        public void DisableCards()
        {
            card1.IsEnabled = false;
            card2.IsEnabled = false;
            card3.IsEnabled = false;
            card4.IsEnabled = false;
            card5.IsEnabled = false;
            card6.IsEnabled = false;
            card7.IsEnabled = false;
            card8.IsEnabled = false;
            card9.IsEnabled = false;
            card10.IsEnabled = false;
            card11.IsEnabled = false;
            card12.IsEnabled = false;
            card13.IsEnabled = false;
        }
        public OrganizedCards()
        {
            InitializeComponent();
        }

        //Defining player 1 object
        private static Player player1;

        //Defining player 2 object
        private static Player player2;

        //Defining player 3 object
        private static Player player3;

        //Defining player 4 object
        private static Player player4;



        // Defining first team object
        private static Team FirstTeam;

        // Defining second team object
        private static Team SecondTeam;


        // Making a new deck
        private static Deck deck = new Deck();

      
        // Defining a new list of cards for player 1 deck
        private static  List<Card> playerdeck;

        // Defining a new list of cards for player 2 deck
        private static  List<Card> playerdeck2;

        // Defining a new list of cards for player 3 deck
        private static List<Card> playerdeck3;

        // Defining a new list of cards for player 4 deck
        private static  List<Card> playerdeck4;

        // A variable for storing player 1 tricks 
        private int player1tricks = 1;

        // Bid object for storing a highest bid
        private Bid Highestbidder = null;

        // Defining a new card object
        Card newCard = new Card();

        // Defining player 1 suit to none
        Enums.Suit player1suit = Enums.Suit.None;

        //A flag for making next player go
        private bool goPlayer = false;

         /// <summary>
         /// This button click event will alow the cards to be distributed to each player and showing human player deck.
         /// </summary>
         /// <param name="sender"> sender is the parameter for checking the </param>
         /// <param name="e"> is the event that is happening</param>
        private void bGetCards_Click(object sender, RoutedEventArgs e)
        {
            EnableCards();
            deck.Shuffle();

            // Sorting and distributing cards to the players
            playerdeck = deck.Sort(deck.TakeCards(13));
            playerdeck2 = deck.Sort(deck.TakeCards(13));
            playerdeck3 = deck.Sort(deck.TakeCards(13));
            playerdeck4 = deck.Sort(deck.TakeCards(13));

            // Assigning each deck to each player
            player1 = new Player("PLayer 1", playerdeck);
            player2 = new Player("Player 2", playerdeck2);
            player3 = new Player("Player 3", playerdeck3);
            player4 = new Player("Player 4", playerdeck4);
            
            // Making teams with 2 player each
             FirstTeam = new Team(player1, player3);
             SecondTeam = new Team(player2, player4);

            // Running for each loop for geting the card image path for each card in the deck
            foreach (Card card in playerdeck)
            {
                card.cardImage = card.GetCardImagePath(card.Suit, card.CardNumber, false);

            }

            // Running for each loop for geting the card image path for each card in the deck
            foreach (Card card in playerdeck2)
            {
                card.cardImage = card.GetCardImagePath(card.Suit, card.CardNumber, false);

            }

            // Running for each loop for geting the card image path for each card in the deck
            foreach (Card card in playerdeck3)
            {
                card.cardImage = card.GetCardImagePath(card.Suit, card.CardNumber, false);

            }

            // Running for each loop for geting the card image path for each card in the deck
            foreach (Card card in playerdeck4)
            {
                card.cardImage = card.GetCardImagePath(card.Suit, card.CardNumber, false);

            }

            // Setting up card image for our deck
            card1.Source = playerdeck[0].cardImage;
            card2.Source = playerdeck[1].cardImage;
            card3.Source = playerdeck[2].cardImage;
            card4.Source = playerdeck[3].cardImage;
            card5.Source = playerdeck[4].cardImage;
            card6.Source = playerdeck[5].cardImage;
            card7.Source = playerdeck[6].cardImage;
            card8.Source = playerdeck[7].cardImage;
            card9.Source = playerdeck[8].cardImage;
            card10.Source = playerdeck[9].cardImage;
            card11.Source = playerdeck[10].cardImage;
            card12.Source = playerdeck[11].cardImage;
            card13.Source = playerdeck[12].cardImage;

            
            bGetCards.IsEnabled = false;
           
            suitSelector.IsEnabled = true;
           

            MyPopup.IsOpen = true;
           
        }

        #region GettingImagesEventHandlers

        /// <summary>
        /// Drop event for player 1 image area
        /// </summary>
        /// <param name="sender"> parameter to tally the objec for that event</param>
        /// <param name="e">e is the event data</param>
        private void imgPlayer1Played_Drop(object sender, DragEventArgs e)
        {

            Image img = e.Source as Image;
            img.Source = (BitmapSource)e.Data.GetData(DataFormats.Text);
            String str = img.Source.ToString();
            String str1 = str.Substring(36); // Diamond12.png
            String[] str2 = {".png"};
            String[] str3 = str1.Split(str2, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in str3.ToArray())
            {
                Console.WriteLine(s);
            }

            int divider = 0;
            if (str1[0] == 'D')
            {
                divider = 7;
            }
            if (str1[0] == 'C')
            {
                divider = 4;
            }
            if (str1[0] == 'H')
            {
                divider = 5;
            }
            if (str1[0] == 'S')
            {
                divider = 5;
            }

            String substr1 = str1.Substring(divider);
            //Console.WriteLine(substr1);

            String[] seperator = { "pack://application:,,,/images/cards/", ".png" };
            String[] strList = str.Split(seperator, StringSplitOptions.RemoveEmptyEntries);

            //Console.WriteLine(str1);
            foreach (string s in strList.ToArray())
            {
                Console.WriteLine(s);
            }


            goPlayer = true;
            //return player1Cards[0];
            //Console.WriteLine(strList[0]);
            //Console.WriteLine(strList[1]);

            //pack://application:,,,/images/cards/Diamond12.png}
            //Console.WriteLine(e.Data.GetData());

            // Helper.InsertEvent("Card Played");
        }

        /// <summary>
        /// An event for dragging card 1 from player's deck
        /// </summary>
        /// <param name="sender"> Is the object for checking the events</param>
        /// <param name="e"> e is the mouse button event</param>
        private void card1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image img = e.Source as Image;
            DataObject data = new DataObject(DataFormats.Text, img.Source);

            DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);
            card1.Source = Helper.GetImage("/images/blankplayingcard.png");

        }

        /// <summary>
        /// An event for dragging card 2 from player's deck
        /// </summary>
        /// <param name="sender"> Is the object for checking the events</param>
        /// <param name="e"> e is the mouse button event</param>
        private void card2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            Image img = e.Source as Image;
            DataObject data = new DataObject(DataFormats.Text, img.Source);

            DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);
            card2.Source = Helper.GetImage("/images/blankplayingcard.png");

        }
        /// <summary>
        /// An event for dragging card 3 from player's deck
        /// </summary>
        /// <param name="sender"> Is the object for checking the events</param>
        /// <param name="e"> e is the mouse button event</param>
        private void card3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image img = e.Source as Image;
            DataObject data = new DataObject(DataFormats.Text, img.Source);

            DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);
            card3.Source = Helper.GetImage("/images/blankplayingcard.png");
        }

        /// <summary>
        /// An event for dragging card 4 from player's deck
        /// </summary>
        /// <param name="sender"> Is the object for checking the events</param>
        /// <param name="e"> e is the mouse button event</param>
        private void card4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image img = e.Source as Image;
            DataObject data = new DataObject(DataFormats.Text, img.Source);

            DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);
            card4.Source = Helper.GetImage("/images/blankplayingcard.png");
        }

        /// <summary>
        /// An event for dragging card 5 from player's deck
        /// </summary>
        /// <param name="sender"> Is the object for checking the events</param>
        /// <param name="e"> e is the mouse button event</param>
        private void card5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image img = e.Source as Image;
            DataObject data = new DataObject(DataFormats.Text, img.Source);

            DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);
            card5.Source = Helper.GetImage("/images/blankplayingcard.png");
        }

        /// <summary>
        /// An event for dragging card 6 from player's deck
        /// </summary>
        /// <param name="sender"> Is the object for checking the events</param>
        /// <param name="e"> e is the mouse button event</param>
        private void card6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image img = e.Source as Image;
            DataObject data = new DataObject(DataFormats.Text, img.Source);

            DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);
            card6.Source = Helper.GetImage("/images/blankplayingcard.png");
        }


        /// <summary>
        /// An event for dragging card 7 from player's deck
        /// </summary>
        /// <param name="sender"> Is the object for checking the events</param>
        /// <param name="e"> e is the mouse button event</param>
        private void card7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image img = e.Source as Image;
            DataObject data = new DataObject(DataFormats.Text, img.Source);

            DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);
            card7.Source = Helper.GetImage("/images/blankplayingcard.png");
        }


        /// <summary>
        /// An event for dragging card 8 from player's deck
        /// </summary>
        /// <param name="sender"> Is the object for checking the events</param>
        /// <param name="e"> e is the mouse button event</param>
        private void card8_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image img = e.Source as Image;
            DataObject data = new DataObject(DataFormats.Text, img.Source);

            DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);
            card8.Source = Helper.GetImage("/images/blankplayingcard.png");
        }


        /// <summary>
        /// An event for dragging card 9 from player's deck
        /// </summary>
        /// <param name="sender"> Is the object for checking the events</param>
        /// <param name="e"> e is the mouse button event</param>
        private void card9_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image img = e.Source as Image;
            DataObject data = new DataObject(DataFormats.Text, img.Source);

            DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);
            card9.Source = Helper.GetImage("/images/blankplayingcard.png");
        }


        /// <summary>
        /// An event for dragging card 10 from player's deck
        /// </summary>
        /// <param name="sender"> Is the object for checking the events</param>
        /// <param name="e"> e is the mouse button event</param>
        private void card10_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image img = e.Source as Image;
            DataObject data = new DataObject(DataFormats.Text, img.Source);

            DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);
            card10.Source = Helper.GetImage("/images/blankplayingcard.png");
        }


        /// <summary>
        /// An event for dragging card 11 from player's deck
        /// </summary>
        /// <param name="sender"> Is the object for checking the events</param>
        /// <param name="e"> e is the mouse button event</param>
        private void card11_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image img = e.Source as Image;
            DataObject data = new DataObject(DataFormats.Text, img.Source);

            DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);
            card11.Source = Helper.GetImage("/images/blankplayingcard.png");
        }


        /// <summary>
        /// An event for dragging card 12 from player's deck
        /// </summary>
        /// <param name="sender"> Is the object for checking the events</param>
        /// <param name="e"> e is the mouse button event</param>
        private void card12_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image img = e.Source as Image;
            DataObject data = new DataObject(DataFormats.Text, img.Source);

            DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);
            card12.Source = Helper.GetImage("/images/blankplayingcard.png");
        }

        /// <summary>
        /// An event for dragging card 13 from player's deck
        /// </summary>
        /// <param name="sender"> Is the object for checking the events</param>
        /// <param name="e"> e is the mouse button event</param>
        private void card13_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image img = e.Source as Image;
            DataObject data = new DataObject(DataFormats.Text, img.Source);

            DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);
            card13.Source = Helper.GetImage("/images/blankplayingcard.png");
        }



        #endregion


        /// <summary>
        /// Will bring back to menu 
        /// </summary>
        /// <param name="sender"> Is the object for checking the events</param>
        /// <param name="e"> e is the mouse button event</param>
        private void Btntomenu_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow back = new MainWindow();
            this.Close();
            back.Show();
        }

        /// <summary>
        /// Will exit the game
        /// </summary>
        /// <param name="sender"> Is the object for checking the events</param>
        /// <param name="e"> e is the mouse button event</param>
        private void Bexit_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// is the event that will be shot when okay id clicked from the popup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOKay_OnClick(object sender, RoutedEventArgs e)
        {

            MyPopup.IsOpen = false;
           
            
           
            txtbiddingNumber.IsEnabled = false;
            suitSelector.IsEnabled = true;
            player1tricks = Convert.ToInt32(pop1selector.Text);
            txtbiddingNumber.Text = player1tricks.ToString();

            List<Player> playerList = new List<Player> {player2, player3, player4};

            //Console.WriteLine(player2.name);
            List<Bid> newBid = new List<Bid>();
            Bid bid = new Bid();
            

            newBid = bid.GoNext(playerList);

           //Displaying tricks for each player
            txtplayer2bid.Text = newBid[0].Tricks.ToString();
            txtplayer3bid.Text = newBid[1].Tricks.ToString();
            txtplayer4bid.Text = newBid[2].Tricks.ToString();

            txtplayer2bid.IsEnabled = false;
            txtplayer3bid.IsEnabled = false;
            txtplayer4bid.IsEnabled = false;

            
            // Checking highest bid
            Highestbidder = bid.HigherBid(newBid);
            
            //If the tricks from 3 players is higher than player 1 
            if (Highestbidder.Tricks > player1tricks)
            {
                MyPopup.IsOpen = false;
                newCard.setTrump((Enums.Suit)Highestbidder.Suit);
                lblHighestBid.Content = "Tarneeb suit is " + newCard.Trump + " of " + Highestbidder.Player;

                // Running until any of the team reaches 42 score
                while (FirstTeam.score != 42 && SecondTeam.score != 42)
                {
                    List<Card> listOfCards = new List<Card>();

                    Enums.Suit currentSuit = Enums.Suit.None;
                    Enums.CardNumber currentCardNumber = 0;
                    Player currentPlayer = null;

                    Player startingPlayer = Highestbidder.Player;
                    
                    
                    Card player1Card = null;
                    Card player2Card = null;
                    Card player3Card = null;
                    Card player4Card = null;


                    
                    if (Highestbidder.Player == player2)
                    {
                        //Player 2 plays card
                        player2Card = putCard(player2, newCard.Trump, currentSuit, currentCardNumber);
                        currentSuit = player2Card.Suit;
                        currentCardNumber = player2Card.CardNumber;
                        currentPlayer = player2;

                        imgPlayer2Played.Source = player2Card.cardImage;

                        //Player 3 plays card
                        player3Card = putCard(player3, newCard.Trump, currentSuit, currentCardNumber);
                        currentSuit = player3Card.Suit;
                        currentCardNumber = player3Card.CardNumber;
                        currentPlayer = player3;

                        imgPlayer3Played.Source = player3Card.cardImage;

                        //Player 4 plays card
                        player4Card = putCard(player4, newCard.Trump, currentSuit, currentCardNumber);
                        currentSuit = player4Card.Suit;
                        currentCardNumber = player4Card.CardNumber;
                        currentPlayer = player4;

                        imgPlayer4Played.Source = player4Card.cardImage;

                        //Player 1 plays card
                        player1Card = putCard(player1, newCard.Trump, currentSuit, currentCardNumber);
                        currentSuit = player1Card.Suit;
                        currentCardNumber = player1Card.CardNumber;
                        currentPlayer = player1;

                        imgPlayer1Played.Source = player1Card.cardImage;
                    }
                    if (Highestbidder.Player == player3)
                    {
                        //Player 3 plays card
                        player3Card = putCard(player3, newCard.Trump, currentSuit, currentCardNumber);
                        currentSuit = player3Card.Suit;
                        currentCardNumber = player3Card.CardNumber;
                        currentPlayer = player3;

                        imgPlayer3Played.Source = player3Card.cardImage;

                        //Player 4 plays card
                        player4Card = putCard(player4, newCard.Trump, currentSuit, currentCardNumber);
                        currentSuit = player4Card.Suit;
                        currentCardNumber = player4Card.CardNumber;
                        currentPlayer = player4;

                        imgPlayer4Played.Source = player4Card.cardImage;

                        //Player 1 plays card
                        player1Card = putCard(player1, newCard.Trump, currentSuit, currentCardNumber);
                        currentSuit = player1Card.Suit;
                        currentCardNumber = player1Card.CardNumber;
                        currentPlayer = player1;

                        imgPlayer1Played.Source = player1Card.cardImage;

                        //Player 2 plays card
                        player2Card = putCard(player2, newCard.Trump, currentSuit, currentCardNumber);
                        currentSuit = player2Card.Suit;
                        currentCardNumber = player2Card.CardNumber;
                        currentPlayer = player2;

                        imgPlayer2Played.Source = player2Card.cardImage;

                    }
                    if (Highestbidder.Player == player4)
                    {
                        //Player 4 plays card
                        player4Card = putCard(player4, newCard.Trump, currentSuit, currentCardNumber);
                        currentSuit = player4Card.Suit;
                        currentCardNumber = player4Card.CardNumber;
                        currentPlayer = player4;

                        imgPlayer4Played.Source = player4Card.cardImage;

                        //Player 1 plays card
                        player1Card = putCard(player1, newCard.Trump, currentSuit, currentCardNumber);
                        currentSuit = player1Card.Suit;
                        currentCardNumber = player1Card.CardNumber;
                        currentPlayer = player1;

                        imgPlayer1Played.Source = player1Card.cardImage;

                        //Player 2 plays card
                        player2Card = putCard(player2, newCard.Trump, currentSuit, currentCardNumber);
                        currentSuit = player2Card.Suit;
                        currentCardNumber = player2Card.CardNumber;
                        currentPlayer = player2;

                        imgPlayer2Played.Source = player2Card.cardImage;

                        //Player 3 plays card
                        player3Card = putCard(player3, newCard.Trump, currentSuit, currentCardNumber);
                        currentSuit = player3Card.Suit;
                        currentCardNumber = player3Card.CardNumber;
                        currentPlayer = player3;

                        imgPlayer3Played.Source = player3Card.cardImage;


                    }

                    List<Card> roundCards = new List<Card>();
                    roundCards.Add(player1Card);
                    roundCards.Add(player2Card);
                    roundCards.Add(player3Card);
                    roundCards.Add(player4Card);

                    // Choosing which card is the highest
                    Card WinningCard = HighestCard(roundCards, (Enums.Suit)Highestbidder.Suit);

                    if (WinningCard == player1Card || WinningCard == player3Card)
                    {
                        lblroundwinners.Content += "Team 1 Wins\n";
                        FirstTeam.score += 7;
                    }
                    else
                    {
                        lblroundwinners.Content += "Team 2 Wins\n";
                        SecondTeam.score += 7;

                    }

                }

                if (FirstTeam.score == 42)
                {
                    lblroundwinners.Content += "This game has been won by first team!";
                }

                if (SecondTeam.score == 42)
                {
                    lblroundwinners.Content += "This game has been won by second team!";
                }

            }
            else
            {
                MyPopup2.IsOpen = true;
                btnGame.IsEnabled = true;
                
            }


        }


        private void BtnGame_OnClick(object sender, RoutedEventArgs e)
        {
            
            MyPopup2.IsOpen = false;
            if (suitSelector.Text == "Spade")
            {
                player1suit = Enums.Suit.Spade;
            }
            if (suitSelector.Text == "Club")
            {
                player1suit = Enums.Suit.Club;
            }
            if (suitSelector.Text == "Heart")
            {
                player1suit = Enums.Suit.Heart;
            }
            if (suitSelector.Text == "Diamond")
            {
                player1suit = Enums.Suit.Diamond;
            }
            newCard.setTrump(player1suit);
            lblHighestBid.Content = "Tarneeb suit is " + player1suit + " of " + player1;

            while (FirstTeam.score != 42 && SecondTeam.score != 42)
            {
                List<Card> listOfCards = new List<Card>();

                Enums.Suit currentSuit = Enums.Suit.None;
                Enums.CardNumber currentCardNumber = 0;
                Player currentPlayer = null;

                Player startingPlayer = Highestbidder.Player;




                //Card player1Card = putCard(Highestbidder.Player, newCard.Trump, currentSuit, currentCardNumber);
                Card player1Card = null;
                Card player2Card = null;
                Card player3Card = null;
                Card player4Card = null;


                //currentSuit = player1Card.Suit;
                //currentCardNumber = player1Card.CardNumber;
                //currentPlayer = Highestbidder.Player;
                //If player 1 is the highest bidder, then the order of gameplay would be player1, player2, player3, player4
                //if (Highestbidder.Player == player1)
                //{
                    //Player 1 plays card
                    EnableCards();

                //Task t = Task.Run(() => imgPlayer1Played_Drop(null, null));
                //t.Wait();
                
               
                player1Card = putCard(player1, newCard.Trump, currentSuit, currentCardNumber);
                currentSuit = player1Card.Suit;
                currentCardNumber = player1Card.CardNumber;
                currentPlayer = player1;

                imgPlayer1Played.Source = player1Card.cardImage;
                //foreach (var card in playerdeck)
                //{
                //    if (card == player1Card)
                //    {
                //        card1.Source = Helper.GetImage("/images/blankplayingcard.png");
                //    }
                //}

                //while (goPlayer) 
                //{
                //Player 2 plays card
                //System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
                //Console.WriteLine("[DONE]");

                player2Card = putCard(player2, newCard.Trump, currentSuit, currentCardNumber);
                        currentSuit = player2Card.Suit;
                        currentCardNumber = player2Card.CardNumber;
                        currentPlayer = player2;

                        imgPlayer2Played.Source = player2Card.cardImage;


                        //Player 3 plays card
                        player3Card = putCard(player3, newCard.Trump, currentSuit, currentCardNumber);
                        currentSuit = player3Card.Suit;
                        currentCardNumber = player3Card.CardNumber;
                        currentPlayer = player3;

                        imgPlayer3Played.Source = player3Card.cardImage;

                        //Player 4 plays card.
                        player4Card = putCard(player4, newCard.Trump, currentSuit, currentCardNumber);
                        currentSuit = player4Card.Suit;
                        currentCardNumber = player4Card.CardNumber;
                        currentPlayer = player4;

                        imgPlayer4Played.Source = player4Card.cardImage;

                        goPlayer = false;
                    //}

                    
               

                List<Card> roundCards = new List<Card>();
                roundCards.Add(player1Card);
                roundCards.Add(player2Card);
                roundCards.Add(player3Card);
                roundCards.Add(player4Card);

                Card WinningCard = HighestCard(roundCards, (Enums.Suit)Highestbidder.Suit);

                if (WinningCard == player1Card || WinningCard == player3Card)
                {
                    lblroundwinners.Content += "Team 1 Wins\n";
                    FirstTeam.score += 7;
                }
                else
                {
                    lblroundwinners.Content += "Team 2 Wins\n";
                    SecondTeam.score += 7;

                }

            }

            if (FirstTeam.score == 42)
            {
                lblroundwinners.Content += "This game has been won by first team!";
            }

            if (SecondTeam.score == 42)
            {
                lblroundwinners.Content += "This game has been won by second team!";
            }
        }
    }
}
