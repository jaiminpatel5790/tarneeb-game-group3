using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Elusive.Whistle
{
    /// <summary>
    /// Interaction logic for InstructionWindow.xaml
    /// </summary>
    public partial class InstructionWindow : UserControl
    {
        public InstructionWindow()
        {
            InitializeComponent();
        }

        private void InstructionWindow_GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            var main = new MainWindow();
            
        }
    }
}
