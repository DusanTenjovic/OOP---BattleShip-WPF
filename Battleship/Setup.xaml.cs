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

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            play(this, e);
        }

        private void velicina_8_Click(object sender, RoutedEventArgs e)
        {

        }

        private void velicina_10_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void velicina_12_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
