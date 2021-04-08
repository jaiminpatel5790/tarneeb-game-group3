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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Cards;

namespace CardDisplayTake3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bGetCards_Click(object sender, RoutedEventArgs e)
        {

            OrganizedCards objOrganizedCards = new OrganizedCards();

            this.Close();
            objOrganizedCards.Show();


        }

       

        private void Bexit_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btninstructions_OnClick(object sender, RoutedEventArgs e)
        {
            Instructions instructionPage = new Instructions();

            this.Close();
            instructionPage.Show();
        }
    }
}
