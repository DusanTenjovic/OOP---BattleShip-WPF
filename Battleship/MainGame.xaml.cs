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

namespace Battleship
{
    /// <summary>
    /// Interaction logic for MainGame.xaml
    /// </summary>
    public partial class MainGame : UserControl
    {
        public event EventHandler play;
        Engine engine = new Engine();

        double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
        double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;

        List<Button> sviDugmici = new List<Button>();

        public MainGame(Engine engine)
        {
            InitializeComponent();
            this.engine = engine;
            postaviDugmice(engine.velicina);
        }

        void postaviDugmice(int velicina)
        {
            int vel = 70;
            for (int i = 0; i < velicina; i++)
            {
                for (int j = 0; j < velicina; j++)
                {
                    Button b = new Button()
                    {
                        Height = vel,
                        Width = vel,
                        VerticalAlignment = 0,
                        HorizontalAlignment = 0,
                        Margin = new Thickness(screenWidth / 15 + vel * i, screenHeight / 15 + vel * j, 0, 0),
                        Content = i.ToString()
                    };
                    b.Click += btnClick;
                    grid.Children.Add(b);
                    sviDugmici.Add(b);
                }
            }
        }

        private void btnClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if(engine.PotopiBrod((sviDugmici.IndexOf(button) / engine.velicina) + 1, (sviDugmici.IndexOf(button) % engine.velicina) + 1))
            {
                button.Background = Brushes.Red;
                button.Click -= btnClick;
            }

            engine.ProveriZaKraj();
        }
    }
}
