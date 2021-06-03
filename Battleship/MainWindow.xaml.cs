﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class MainWindow : Window
    {
        Grid grid = new Grid();
        public Engine engine = new Engine(8);

        Setup setup;
        ShipPlacement shipPlacement;

        public MainWindow()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            Content = grid;

            MinHeight = 300;
            MinWidth = 330;
            this.Height = 300;
            this.Width = 330;

            //setup = new Setup(engine);
            //grid.Children.Add(setup);

            int vel = 50;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button b = new Button()
                    {
                        Height = 30,
                        Width = 50,

                        VerticalAlignment = 0,
                        HorizontalAlignment = 0,
                        Margin = new Thickness(vel + vel * i, vel + 30*j, 0, 0),
                        Content = i.ToString()
                    };
                    grid.Children.Add(b);
                }
            }
            
            //setup.play += new EventHandler(shipSetup);
        }

        private void shipSetup(object sender, EventArgs e)
        {
            grid.Children.Clear(); 

            this.MinWidth = 460;
            this.MinHeight = 530;
            this.Width = 460;
            this.Height = 530;

            shipPlacement = new ShipPlacement(engine);

            grid.Children.Add(shipPlacement); 

            shipPlacement.play += new EventHandler(ponovo);
        }

        private void ponovo(object sender, EventArgs e)
        {
            grid.Children.Clear();
            InitializeGame();
        }
       
    }
}
