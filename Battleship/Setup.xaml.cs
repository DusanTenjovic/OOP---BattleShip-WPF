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

namespace Battleship
{ 
    public partial class Setup : UserControl
    {
        public event EventHandler play;
        Engine engine;


        public Setup(Engine engine)
        {
            InitializeComponent();
            this.engine = engine;
        }

        public void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            engine.NapraviMatricu();
            engine.player0 = (txtLetterInput.Text.Trim() == "") ? "Player 1" : txtLetterInput.Text.Trim();
            engine.player1 = (txtLetterInput_Copy.Text.Trim() == "") ? "Player 2" : txtLetterInput_Copy.Text.Trim();
            play(this, e);
        }

        private void velicina_8_Click(object sender, RoutedEventArgs e)
        {
            engine.PostaviVelicinu(8);
        }

        private void velicina_10_Click(object sender, RoutedEventArgs e)
        {
            engine.PostaviVelicinu(10);
        }

        private void velicina_12_Click(object sender, RoutedEventArgs e)
        {
            engine.PostaviVelicinu(12);
        }
    }
}
