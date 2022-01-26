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

namespace QuizApp
{
    /// <summary>
    /// Interaction logic for GamemodeSelection.xaml
    /// </summary>
    public partial class GamemodeSelection : Window
    {
        public GamemodeSelection()
        {
            InitializeComponent();
        }

        private void SingleplayerBtn_Click(object sender, RoutedEventArgs e)
        {
            new SinglePlayerGameWindow().Show();
            Close();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void MultiplayerBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
