using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Battleship
{
    public class Engine
    {
        private bool[,] matrica_zauzeta_0;
        private bool[,] matrica_zauzeta_1;

        private bool[,] matrica_brodova_0;
        private bool[,] matrica_brodova_1;

        private string player1;
        private string player2;

        int igracNaPotezu = 0;

        public List<int> velicineBrodova;
        public int velicina = 8;


        public void NapraviMatricu()
        {
            matrica_zauzeta_0 = new bool[velicina + 2, velicina + 2]; // Defaultno je false...
            matrica_zauzeta_1 = new bool[velicina + 2, velicina + 2];

            matrica_brodova_0 = new bool[velicina + 2, velicina + 2];
            matrica_brodova_1 = new bool[velicina + 2, velicina + 2];

            if (velicina == 8)
            {
                velicineBrodova = new List<int>() { 4, 3, 2, 2 };
            }
            else if (velicina == 10)
            {
                velicineBrodova = new List<int>() { 5, 4, 3, 3, 2, 2, 2 };
            }
            else
            {
                velicineBrodova = new List<int>() { 6, 5, 4, 4, 3, 3, 2, 2 };
            }
        }

        public int limit = 0;
        public void PostaviBrod(int x)
        {
            if (velicineBrodova.Contains(x))
            {
                limit = x;
                velicineBrodova.Remove(x);
            }
            else
                MessageBox.Show("Nema takvog broda");
        }

        public void PostaviDeoBroda(int x, int y)
        {
            if (igracNaPotezu % 2 == 0)
            {
                if (!matrica_zauzeta_0[x,y])
                {
                    matrica_zauzeta_0[x, y] = true;
                    matrica_zauzeta_0[x - 1, y + 1] = true;
                    matrica_zauzeta_0[x, y+1] = true;
                    matrica_zauzeta_0[x+1, y+1] = true;
                    matrica_zauzeta_0[x-1, y] = true;
                    matrica_zauzeta_0[x+1, y] = true;
                    matrica_zauzeta_0[x-1, y-1] = true;
                    matrica_zauzeta_0[x, y-1] = true;
                    matrica_zauzeta_0[x+1, y-1] = true;

                    matrica_brodova_0[x, y] = true;
                }
            }
            else
            {
                if (!matrica_zauzeta_1[x, y])
                {
                    matrica_zauzeta_1[x, y] = true;
                    matrica_zauzeta_1[x - 1, y + 1] = true;
                    matrica_zauzeta_1[x, y + 1] = true;
                    matrica_zauzeta_1[x + 1, y + 1] = true;
                    matrica_zauzeta_1[x - 1, y] = true;
                    matrica_zauzeta_1[x + 1, y] = true;
                    matrica_zauzeta_1[x - 1, y - 1] = true;
                    matrica_zauzeta_1[x, y - 1] = true;
                    matrica_zauzeta_1[x + 1, y - 1] = true;

                    matrica_brodova_1[x, y] = true;
                }
            }
        }

        public void PostaviVelicinu(int velicina)
        {
            this.velicina = velicina;
        }

        public void PostaviImeIgraca(string ime, int brojIgraca)
        {
            if (brojIgraca == 1)
            {
                player1 = ime;
            }
            else
                player2 = ime;
        }

        public string Prikazi()
        {
            return velicina.ToString();
        }
    }
}
