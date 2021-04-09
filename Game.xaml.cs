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

namespace CardDisplayTake3
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class OrganizedCards : Window
    {
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




        private Team FirstTeam;
        private Team SecondTeam;



        private void bGetCards_Click(object sender, RoutedEventArgs e)
        {


            var deck = new Deck();

            deck.Shuffle();




            List<Card> playerdeck = deck.Sort(deck.TakeCards(13));

            List<Card> playerdeck2 = deck.Sort(deck.TakeCards(13));
            List<Card> playerdeck3 = deck.Sort(deck.TakeCards(13));
            List<Card> playerdeck4 = deck.Sort(deck.TakeCards(13));

            //player1Name = "Player 1";
            //player1Cards = playerdeck;
            //player2Name = "Player 2";
            //player2Cards = playerdeck2;
            //player3Name = "Player 3";
            //player3Cards = playerdeck3;
            //player4Name = "Player 4";
            //player4Cards = playerdeck4;

            player1 = new Player("PLayer 1", playerdeck);
            player2 = new Player("Player 2", playerdeck2);
            player3 = new Player("Player 3", playerdeck3);
            player4 = new Player("Player 4", playerdeck4);

            //Console.WriteLine(player1.name);
            //player1.name = "Player 1";
            //player1.playersCards = playerdeck;
            //Player player2 = null;
            //player2.name = "Player 2";
            //player2.playersCards = playerdeck2;
            ////player2 = new Player("Player 2", playerdeck2);
            //player3.name = "Player 4";
            //player3.playersCards = playerdeck3;
            ////Player player3 = new Player("Player 3", playerdeck3);
            //player4.name = "Player 4";
            //player4.playersCards = playerdeck4;
            ////Player player4 = new Player("Player 4", playerdeck4);

            Team FirstTeam = new Team(player1, player3);
            Team SecondTeam = new Team(player2, player4);

            
            foreach (Card card in playerdeck)
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

        private void imgPlayer2Played_Drop(object sender, DragEventArgs e)
        {
            Image img = e.Source as Image;
            img.Source = (BitmapSource)e.Data.GetData(DataFormats.Text);
          //  Helper.InsertEvent("Card Played");
        }

        private void imgPlayer3Played_Drop(object sender, DragEventArgs e)
        {
            Image img = e.Source as Image;
            img.Source = (BitmapSource)e.Data.GetData(DataFormats.Text);
            //Helper.InsertEvent("Card Played");
        }

        private void imgPlayer4Played_Drop(object sender, DragEventArgs e)
        {
            Image img = e.Source as Image;
            img.Source = (BitmapSource)e.Data.GetData(DataFormats.Text);
            // Helper.InsertEvent("Card Played");
        }


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

            newBid.Add(player1Bid);

            Highestbidder = bid.HigherBid(newBid);

           Console.WriteLine(newBid[0].Suit);

            lblHighestBid.Content = Highestbidder.ToString();

        }

       
    }
}
