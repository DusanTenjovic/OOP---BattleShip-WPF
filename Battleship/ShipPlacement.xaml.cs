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
            postaviDugmice(engine.velicina);
            postaviBrodove(engine.velicina);
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
                        Margin = new Thickness(screenWidth/15 + vel * i, screenHeight/15 + vel * j, 0, 0),
                        Content = i.ToString()                        
                    };
                    b.Click += btnClick;

                    grid.Children.Add(b);
                    sviDugmici.Add(b);
                }
            }
        }

        void postaviBrodove(int velicina)
        {
            if (velicina == 8)
            {
                nacrtajDugme2();
            }
            else if (velicina == 10)
            {

            }
            else if (velicina == 12)
            {

            }
            else
            {
                MessageBox.Show("APOKALIPSA");
            }
        }


        private void btnClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            //engine.PostaviDeoBroda(sviDugmici.IndexOf(button) % engine.velicina, sviDugmici.IndexOf(button) / engine.velicina);
        }

        void nacrtajDugme2()
        {
            Button b = new Button()
            {
                Height = screenHeight / 38.4,
                Width = screenWidth / 19.2,
                VerticalAlignment = 0,
                HorizontalAlignment = 0,
                Margin = new Thickness(screenWidth * 5 / 7, screenHeight * 5 / 7, 0, 0),
                Content = "dvojka"
            };
            grid.Children.Add(b);
        }
        
        void nacrtajDugme3()
        {
            Button b = new Button()
            {
                Height = 100,
                Width = 300,
                VerticalAlignment = 0,
                HorizontalAlignment = 0,
                Margin = new Thickness(50, 50, 0, 0),
                Content = "trojka"
            };
        }
        void nacrtajDugme4()
        {
            Button b = new Button()
            {
                Height = 30,
                Width = 30,
                VerticalAlignment = 0,
                HorizontalAlignment = 0,
                Margin = new Thickness(50, 50, 0, 0),
                Content = "cetvorka"
            };
        }
        void nacrtajDugme5()
        {
            Button b = new Button()
            {
                Height = 30,
                Width = 30,
                VerticalAlignment = 0,
                HorizontalAlignment = 0,
                Margin = new Thickness(50, 50, 0, 0),
                Content = "petica"
            };
        }
        void nacrtajDugme6()
        {
            Button b = new Button()
            {
                Height = 30,
                Width = 30,
                VerticalAlignment = 0,
                HorizontalAlignment = 0,
                Margin = new Thickness(50, 50, 0, 0),
                Content = "sestica"
            };
        }
    }
}
