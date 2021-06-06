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
        int igracNaPotezu = 0;

        public ShipPlacement(Engine engine)
        {
            InitializeComponent();
            this.engine = engine;
            postaviDugmice(engine.velicina);
            postaviBrodove(engine.velicina);
        }

        void postaviDugmice(int velicina)
        {
            int vel = 30;
            for (int i = 0; i < velicina; i++)
            {
                for (int j = 0; j < velicina; j++)
                {
                    Button b = new Button()
                    {
                        Height = 30,
                        Width = 30,
                        VerticalAlignment = 0,
                        HorizontalAlignment = 0,
                        Margin = new Thickness(50 + vel * i, 50 + vel * j, 0, 0),
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
                Height = 30,
                Width = 30,
                VerticalAlignment = 0,
                HorizontalAlignment = 0,
                Margin = new Thickness(50 , 50 , 0, 0)            
            };
        }
    }
}
