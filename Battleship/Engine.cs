using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Engine
    {
        private bool[,] matrica1;
        private bool[,] matrica2;

        private string player1;
        private string player2;

        int igracNaPotezu = 0;

        public List<int> velicineBrodova;
        public int velicina = 8;

        public void NapraviMatricu()
        {
            matrica1 = new bool[velicina + 2, velicina + 2];
            matrica2 = new bool[velicina + 2, velicina + 2];
            
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

        //public bool postavideobroda(int x, int y)
        //{
        //    if (igracNaPotezu % 2 == 0)
        //    {

        //    }
        //}

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
