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
        List<Button> sviDugmici_1 = new List<Button>();

        public MainGame(Engine engine)
        {
            InitializeComponent();
            this.engine = engine;
            ispisIgraca.Content = engine.player0;
            ispisIgraca1.Content = engine.player1;
            ispisBrojac.Content = engine.igracNaPotezu;
            ispisBrojac1.Content = engine.igracNaPotezu;
            postaviDugmice(engine.velicina);
            grid_0.Visibility = Visibility.Visible;
            grid_1.Visibility = Visibility.Hidden;
        }

        void postaviDugmice(int velicina)
        {
            int vel = 70;
            for (int i = 0; i < velicina; i++)
            {
                for (int j = 0; j < velicina; j++)
                {
                    Button b = InicijalizacijaDugmeta(vel, i, j);
                    Button b1 = InicijalizacijaDugmeta(vel, i, j);

                    b.Click += btnClick;
                    b1.Click += btnClick_1;

                    grid_0.Children.Add(b);
                    grid_1.Children.Add(b1);

                    sviDugmici.Add(b);
                    sviDugmici_1.Add(b1);
                }
            }
        }

        private Button InicijalizacijaDugmeta(int vel, int i, int j)
        {
            return new Button()
            {
                Height = vel,
                Width = vel,
                VerticalAlignment = 0,
                HorizontalAlignment = 0,
                Margin = new Thickness(screenWidth / 15 + vel * i, screenHeight / 15 + vel * j, 0, 0),
                Content = i.ToString()
            };
        }

        private void btnClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;            
            if (engine.PotopiBrod((sviDugmici.IndexOf(button) / engine.velicina) + 1, (sviDugmici.IndexOf(button) % engine.velicina) + 1))
            {
                
                button.Background = Brushes.Red;
                button.Click -= btnClick;
            }
            else
            {
                engine.igracNaPotezu++;
                button.Background = Brushes.Gray;
                button.Click -= btnClick;
                grid_0.Visibility = grid_0.Visibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
                grid_1.Visibility = grid_1.Visibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
                ispisIgraca.Content = engine.player0;
                ispisIgraca1.Content = engine.player1;
                ispisBrojac.Content = engine.igracNaPotezu;
                ispisBrojac1.Content = engine.igracNaPotezu;

            }

            engine.ProveriZaKraj();
        }

        private void btnClick_1(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (engine.PotopiBrod((sviDugmici_1.IndexOf(button) / engine.velicina) + 1, (sviDugmici_1.IndexOf(button) % engine.velicina) + 1))
            {
                
                button.Background = Brushes.DeepPink;
                button.Click -= btnClick_1;
            }
            else
            {
                engine.igracNaPotezu++;
                button.Background = Brushes.Gray;
                button.Click -= btnClick_1;
                grid_0.Visibility = grid_0.Visibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
                grid_1.Visibility = grid_1.Visibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
                ispisIgraca.Content = engine.player0;
                ispisIgraca1.Content = engine.player1;
                ispisBrojac.Content = engine.igracNaPotezu;
                ispisBrojac1.Content = engine.igracNaPotezu;
            }
            engine.ProveriZaKraj();
        }        
    }
}
