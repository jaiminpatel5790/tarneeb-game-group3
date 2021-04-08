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

        private void bGetCards_Click(object sender, RoutedEventArgs e)
        {


            var deck = new Deck();

            deck.Shuffle();




            List<Card> playerdeck = deck.Sort(deck.TakeCards(13));

            List<Card> playerdeck2 = deck.Sort(deck.TakeCards(13));
            List<Card> playerdeck3 = deck.Sort(deck.TakeCards(13));
            List<Card> playerdeck4 = deck.Sort(deck.TakeCards(13));
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
        }
    }
}
