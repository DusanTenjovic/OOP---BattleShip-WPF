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
    /// <summary>
    /// Interaction logic for ShipPlacement.xaml
    /// </summary>
    public partial class ShipPlacement : UserControl
    {
        public event EventHandler play;
        Engine engine;

        public ShipPlacement(Engine engine)
        {
            InitializeComponent();
            this.engine = engine;
            Ispis.Content = engine.Prikazi();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            play(this, e);
        }
    }
}
