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
        List<Button> sviDugmici = new List<Button>();

        double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
        double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;

        public ShipPlacement(Engine engine)
        {
            InitializeComponent();
            this.engine = engine;
            ispisIgraca.Content = engine.VratiImeIgraca();
            postaviDugmice(engine.velicina);
            postaviBrodove(engine.velicina);
        }

        private void btnNextPlayer_CLick (object sender, RoutedEventArgs e)
        {
            engine.brojacPostavljenihPolja = 0;
            engine.UokviriBrod(true);
            engine.igracNaPotezu++;                  
            engine.NapraviMatricu();           
            play(this, e);
        }

        int pamtiVel;
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
                        Margin = new Thickness(screenWidth/15 + vel * i, screenHeight/15 + vel * j, 0, 0),
                        Content = i.ToString()                        
                    };
                    b.Click += btnClick;
                    grid.Children.Add(b);
                    sviDugmici.Add(b);
                }
                pamtiVel = vel * i;
            }
        }

        void postaviBrodove(int velicina)
        {
            nacrtajDugme2(1);
            nacrtajDugme3(2);
            nacrtajDugme4(3);
            nacrtajDugme5(4);
            nacrtajDugme6(5);
        }

        private void btnClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            
            if (engine.PostaviDeoBroda((sviDugmici.IndexOf(button) / engine.velicina) + 1, (sviDugmici.IndexOf(button) % engine.velicina) + 1))
            {
                button.Background = Brushes.Gray;
                engine.brojacPostavljenihPolja++;
                engine.KompletanBrod();
            }

            if (engine.ProveriZaKrajPostavljanja())
            {
                btnNextPlayer.Click += btnNextPlayer_CLick;
            }

            postaviDebug(engine.velicina);
            postaviDebug_2(engine.velicina);
        }

        private void postaviDebug(int velicina)
        {
            int vel = 25;
            for (int i = 0; i < velicina; i++)
            {
                for (int j = 0; j < velicina; j++)
                {
                    Button b = new Button()
                    {
                        Height = 20,
                        Width = 20,
                        VerticalAlignment = 0,
                        HorizontalAlignment = 0,
                        Margin = new Thickness(12 * screenWidth / 15 + vel * i, 6 * screenHeight / 15 + vel * j, 0, 0),
                        Content = i.ToString(),
                        Background = engine.KojaJeZauzeta(i+1, j+1) ? Brushes.Red : Brushes.Blue
                    };
                    grid.Children.Add(b);
                }
            }
        }

        private void postaviDebug_2(int velicina)
        {
            int vel = 25;
            for (int i = 0; i < velicina; i++)
            {
                for (int j = 0; j < velicina; j++)
                {
                    Button b = new Button()
                    {
                        Height = 20,
                        Width = 20,
                        VerticalAlignment = 0,
                        HorizontalAlignment = 0,
                        Margin = new Thickness(9 * screenWidth / 15 + vel * i, 6 * screenHeight / 15 + vel * j, 0, 0),
                        Content = i.ToString(),
                        Background = engine.KojaJeBrodova(i+1, j+1) ? Brushes.Red : Brushes.Blue
                    };
                    grid.Children.Add(b);
                }
            }
        }


        int duz = 900;
        int vis = 400;
        int Vel = 50;
        int razmak = 20;

        void nacrtajDugme2(int x)
        {
            Button b = new Button()
            {
                Height = Vel,
                Width = 2 * Vel,
                VerticalAlignment = 0,
                HorizontalAlignment = 0,
                Margin = new Thickness(pamtiVel + 250, vis - x * Vel * 1.2, 0, 0),
                Content = "2"
            };
            b.Click += click_2;
            grid.Children.Add(b);
        }

        private void click_2(object sender, RoutedEventArgs e) => engine.PostaviBrod(2);

        void nacrtajDugme3(int x)
        {
            Button b = new Button()
            {
                Height =  Vel,
                Width = 3 * Vel,
                VerticalAlignment = 0,
                HorizontalAlignment = 0,
                Margin = new Thickness(pamtiVel + 250, vis - x * Vel * 1.2, 0, 0),
                Content = "3"
            };
            b.Click += click_3;
            grid.Children.Add(b);
        }

        private void click_3(object sender, RoutedEventArgs e) => engine.PostaviBrod(3);

        void nacrtajDugme4(int x)
        {
            Button b = new Button()
            {
                Height = Vel,
                Width = 4 * Vel,
                VerticalAlignment = 0,
                HorizontalAlignment = 0,
                Margin = new Thickness(pamtiVel + 250, vis - x * Vel * 1.2, 0, 0),
                Content = "4"
            };
            b.Click += click_4;
            grid.Children.Add(b);
        }

        private void click_4(object sender, RoutedEventArgs e) => engine.PostaviBrod(4);

        void nacrtajDugme5(int x)
        {
            Button b = new Button()
            {
                Height =  Vel,
                Width = 5 * Vel,
                VerticalAlignment = 0,
                HorizontalAlignment = 0,
                Margin = new Thickness(pamtiVel + 250, vis - x * Vel * 1.2, 0, 0),
                Content = "5"
            };
            b.Click += click_5;
            grid.Children.Add(b);
        }

        private void click_5(object sender, RoutedEventArgs e) => engine.PostaviBrod(5);

        void nacrtajDugme6(int x)
        {
            Button b = new Button()
            {
                Height =  Vel,
                Width = 6 * Vel,
                VerticalAlignment = 0,
                HorizontalAlignment = 0,
                Margin = new Thickness(pamtiVel + 250, vis - x * Vel * 1.2, 0, 0),
                Content = "6"
            };
            b.Click += click_6;
            grid.Children.Add(b);
        }

        private void click_6(object sender, RoutedEventArgs e) => engine.PostaviBrod(6);

        //private void UNDO_Click(object sender, RoutedEventArgs e)
        //{
        //    engine.Undo();
  
        //    postaviDebug(engine.velicina);
        //    postaviDebug_2(engine.velicina);
        //}
    }
}
