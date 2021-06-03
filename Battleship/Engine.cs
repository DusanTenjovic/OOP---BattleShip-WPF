using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Engine
    {
        private int[,] matrica1;
        private int[,] matrica2;

        List<int> velicineBrodova;
        int N;

        public Engine(int n)
        {
            matrica1 = new int[n, n];
            matrica2 = new int[n, n];
            N = n;
            if (n == 8)
            {
                velicineBrodova = new List<int>() { 4, 3, 2, 2 };
                this.N = 8;
            }
            else if (n == 10)
            {
                velicineBrodova = new List<int>() { 5, 4, 3, 3, 2, 2, 2 };
                this.N = 10;
            }
            else
            {
                velicineBrodova = new List<int>() { 6, 5, 4, 4, 3, 3, 2, 2 };
                this.N = 12;
            }
        }

        public string Prikazi()
        {
            return N.ToString();
        }
    }
}
