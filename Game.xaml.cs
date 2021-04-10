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

        private static String player1Name;
        private static List<Card> player1Cards;

        private static String player2Name;
        private static List<Card> player2Cards;

        private static String player3Name;
        private static List<Card> player3Cards;

        private static String player4Name;
        private static List<Card> player4Cards;


        private static Player player1;
        private static Player player2;
        private static Player player3;
        private static Player player4;




        private static Team FirstTeam;
        private static Team SecondTeam;

        private static Deck deck = new Deck();

      

        private static  List<Card> playerdeck;
        private static  List<Card> playerdeck2;
        private static List<Card> playerdeck3;
        private static  List<Card> playerdeck4;
        //List<Card> playerdeck2 = deck.Sort(deck.TakeCards(13));
        //List<Card> playerdeck3 = deck.Sort(deck.TakeCards(13));
        //List<Card> playerdeck4 = deck.Sort(deck.TakeCards(13));

        private void bGetCards_Click(object sender, RoutedEventArgs e)
        {
            deck.Shuffle();


            playerdeck = deck.Sort(deck.TakeCards(13));
            playerdeck2 = deck.Sort(deck.TakeCards(13));
            playerdeck3 = deck.Sort(deck.TakeCards(13));
            playerdeck4 = deck.Sort(deck.TakeCards(13));

            player1 = new Player("PLayer 1", playerdeck);
            player2 = new Player("Player 2", playerdeck2);
            player3 = new Player("Player 3", playerdeck3);
            player4 = new Player("Player 4", playerdeck4);
            
             FirstTeam = new Team(player1, player3);
             SecondTeam = new Team(player2, player4);


            foreach (Card card in playerdeck)
            {
                card.cardImage = card.GetCardImagePath(card.Suit, card.CardNumber, false);

            }

            foreach (Card card in playerdeck2)
            {
                card.cardImage = card.GetCardImagePath(card.Suit, card.CardNumber, false);

            }

            foreach (Card card in playerdeck3)
            {
                card.cardImage = card.GetCardImagePath(card.Suit, card.CardNumber, false);

            }

            foreach (Card card in playerdeck4)
            {
                card.cardImage = card.GetCardImagePath(card.Suit, card.CardNumber, false);

            }

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
            bidSelector.IsEnabled = true;
            suitSelector.IsEnabled = true;
            btnOkay.IsEnabled = true;


        }

        #region GettingImagesEventHandlers

        private void imgPlayer1Played_Drop(object sender, DragEventArgs e)
        {

            Image img = e.Source as Image;
            img.Source = (BitmapSource)e.Data.GetData(DataFormats.Text);

            // Helper.InsertEvent("Card Played");
        }

        private void card1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image img = e.Source as Image;
            DataObject data = new DataObject(DataFormats.Text, img.Source);

            DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);
            card1.Source = Helper.GetImage("/images/blankplayingcard.png");

        }

        private void card2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            Image img = e.Source as Image;
            DataObject data = new DataObject(DataFormats.Text, img.Source);

            DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);
            card2.Source = Helper.GetImage("/images/blankplayingcard.png");

        }
        private void card3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image img = e.Source as Image;
            DataObject data = new DataObject(DataFormats.Text, img.Source);

            DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);
            card3.Source = Helper.GetImage("/images/blankplayingcard.png");
        }

        private void card4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image img = e.Source as Image;
            DataObject data = new DataObject(DataFormats.Text, img.Source);

            DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);
            card4.Source = Helper.GetImage("/images/blankplayingcard.png");
        }

        private void card5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image img = e.Source as Image;
            DataObject data = new DataObject(DataFormats.Text, img.Source);

            DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);
            card5.Source = Helper.GetImage("/images/blankplayingcard.png");
        }

        private void card6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image img = e.Source as Image;
            DataObject data = new DataObject(DataFormats.Text, img.Source);

            DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);
            card6.Source = Helper.GetImage("/images/blankplayingcard.png");
        }

        private void card7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image img = e.Source as Image;
            DataObject data = new DataObject(DataFormats.Text, img.Source);

            DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);
            card7.Source = Helper.GetImage("/images/blankplayingcard.png");
        }

        private void card8_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image img = e.Source as Image;
            DataObject data = new DataObject(DataFormats.Text, img.Source);

            DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);
            card8.Source = Helper.GetImage("/images/blankplayingcard.png");
        }

        private void card9_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image img = e.Source as Image;
            DataObject data = new DataObject(DataFormats.Text, img.Source);

            DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);
            card9.Source = Helper.GetImage("/images/blankplayingcard.png");
        }

        private void card10_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image img = e.Source as Image;
            DataObject data = new DataObject(DataFormats.Text, img.Source);

            DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);
            card10.Source = Helper.GetImage("/images/blankplayingcard.png");
        }

        private void card11_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image img = e.Source as Image;
            DataObject data = new DataObject(DataFormats.Text, img.Source);

            DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);
            card11.Source = Helper.GetImage("/images/blankplayingcard.png");
        }

        private void card12_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image img = e.Source as Image;
            DataObject data = new DataObject(DataFormats.Text, img.Source);

            DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);
            card12.Source = Helper.GetImage("/images/blankplayingcard.png");
        }

        private void card13_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image img = e.Source as Image;
            DataObject data = new DataObject(DataFormats.Text, img.Source);

            DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);
            card13.Source = Helper.GetImage("/images/blankplayingcard.png");
        }

        //private void imgPlayer2Played_Drop(object sender, DragEventArgs e)
        //{
        //    Image img = e.Source as Image;
        //    img.Source = (BitmapSource)e.Data.GetData(DataFormats.Text);
        //  //  Helper.InsertEvent("Card Played");
        //}

        //private void imgPlayer3Played_Drop(object sender, DragEventArgs e)
        //{
        //    Image img = e.Source as Image;
        //    img.Source = (BitmapSource)e.Data.GetData(DataFormats.Text);
        //    //Helper.InsertEvent("Card Played");
        //}

        //private void imgPlayer4Played_Drop(object sender, DragEventArgs e)
        //{
        //    Image img = e.Source as Image;
        //    img.Source = (BitmapSource)e.Data.GetData(DataFormats.Text);
        //    // Helper.InsertEvent("Card Played");
        //}


        #endregion



        private void Btntomenu_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow back = new MainWindow();
            this.Close();
            back.Show();
        }

        private void Bexit_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void BtnOKay_OnClick(object sender, RoutedEventArgs e)
        {
            txtbiddingNumber.Text = bidSelector.Text;
            btnOkay.IsEnabled = false;
            bidSelector.IsEnabled = false;
            txtbiddingNumber.IsEnabled = false;
            suitSelector.IsEnabled = false;

            List<Player> playerList = new List<Player> {player2, player3, player4};

            //Console.WriteLine(player2.name);
            List<Bid> newBid = new List<Bid>();
            Bid bid = new Bid();
            Bid Highestbidder;

            newBid = bid.GoNext(playerList);

          
            txtplayer2bid.Text = newBid[0].Tricks.ToString();
            txtplayer3bid.Text = newBid[1].Tricks.ToString();
            txtplayer4bid.Text = newBid[2].Tricks.ToString();

            txtplayer2bid.IsEnabled = false;
            txtplayer3bid.IsEnabled = false;
            txtplayer4bid.IsEnabled = false;
            int ourbid = Convert.ToInt32(bidSelector.Text);
            char oursuit = 'H';
            if (suitSelector.Text == "Spades")
            {
                oursuit = 'S';
            }
            if (suitSelector.Text == "Heart")
            {
                oursuit = 'H';
            }
            if (suitSelector.Text == "Club")
            {
                oursuit = 'C';
            }
            if (suitSelector.Text == "Diamond")
            {
                oursuit = 'D';
            }
            // char oursuit = Convert.ToChar(suitSelector.Text);

            Bid player1Bid = new Bid()
            {
                IsPass = false,
                Player = player1,
                Tricks = ourbid,
                Suit = oursuit

            };

            newBid.Insert(0, player1Bid);

            Highestbidder = bid.HigherBid(newBid);

            lblHighestBid.Content = Highestbidder.ToString();
            Card newCard = new Card();
            newCard.setTrump((Enums.Suit) Highestbidder.Suit);

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
                if (Highestbidder.Player == player1)
                {
                    //Player 1 plays card
                    EnableCards();
                    
                    player1Card = putCard(player1, newCard.Trump, currentSuit, currentCardNumber);
                    currentSuit = player1Card.Suit;
                    currentCardNumber = player1Card.CardNumber;
                    currentPlayer = player1;

                    imgPlayer1Played.Source = player1Card.cardImage;
                    foreach (var card in playerdeck)
                    {
                        if (card == player1Card)
                        {
                            card1.Source = Helper.GetImage("/images/blankplayingcard.png");
                        }
                    }



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

                    //Player 4 plays card.
                    player4Card = putCard(player4, newCard.Trump, currentSuit, currentCardNumber);
                    currentSuit = player4Card.Suit;
                    currentCardNumber = player4Card.CardNumber;
                    currentPlayer = player4;

                    imgPlayer4Played.Source = player4Card.cardImage;
                }
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

            if(FirstTeam.score == 42)
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
