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
        struct Polje
        {
            public int x;
            public int y;
        }
        List<Polje> TrenutniBrod = new List<Polje>();

        public bool[,] matrica_zauzeta_0;
        public bool[,] matrica_zauzeta_1;
        
        public bool[,] matrica_brodova_0;
        public bool[,] matrica_brodova_1;
        
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
        bool trn = false;
        bool prviKorakBroda = true;
        bool prethodniPostavljen = true;

        public void PostaviBrod(int x)
        {
            if (velicineBrodova.Contains(x) && prethodniPostavljen)
            {
                if (TrenutniBrod.Count() == limit) UokviriBrod();
                limit = x;
                trn = true;
                prviKorakBroda = true;
            }
            else if (!velicineBrodova.Contains(x))
                MessageBox.Show("Nema takvog broda");
            else if (!prethodniPostavljen)
                MessageBox.Show("Nije zavrsen prethodni brod");
        }

        public void KompletanBrod()
        {
            if (TrenutniBrod.Count() == limit)
            {
                prethodniPostavljen = true;
                velicineBrodova.Remove(limit);
            }
        }

        int trnX;
        int trnY;

        public bool PostaviDeoBroda(int x, int y)
        {
            if (igracNaPotezu % 2 == 0)
            {
                if (!matrica_zauzeta_0[x, y] && (TrenutniBrod.Count() < limit))
                {
                    if (!prviKorakBroda)
                    {
                        Console.WriteLine("Nije prvi korak");
                        if (((Math.Abs(x - trnX) == 1) && y == trnY) ||
                            ((Math.Abs(y - trnY) == 1) && x == trnX))
                        {
                            Console.WriteLine("jeste sused");
                            trnX = x;
                            trnY = y;
                            matrica_brodova_0[x, y] = true;
                            Polje polje = new Polje() { x = x, y = y };
                            TrenutniBrod.Add(polje);

                            matrica_zauzeta_0[x, y] = true;

                            matrica_zauzeta_0[x - 1, y + 1] = true;
                            matrica_zauzeta_0[x, y + 1] = (true && !trn) || matrica_zauzeta_0[x, y + 1];
                            matrica_zauzeta_0[x + 1, y + 1] = true;
                            matrica_zauzeta_0[x - 1, y] = (true && !trn) || matrica_zauzeta_0[x - 1, y];
                            matrica_zauzeta_0[x + 1, y] = (true && !trn) || matrica_zauzeta_0[x + 1, y];
                            matrica_zauzeta_0[x - 1, y - 1] = true;
                            matrica_zauzeta_0[x, y - 1] = (true && !trn) || matrica_zauzeta_0[x, y - 1];
                            matrica_zauzeta_0[x + 1, y - 1] = true;

                            return true;
                        }
                        else
                        {
                            Console.WriteLine("nije sused");
                            return false;                            
                        }
                    }
                    else
                    {
                        prviKorakBroda = false;
                        prethodniPostavljen = false;
                        Console.WriteLine("Prvi korak");
                        trnX = x;
                        trnY = y;
                        matrica_brodova_0[x, y] = true;
                        Polje polje = new Polje() { x = x, y = y };
                        TrenutniBrod.Add(polje);

                        matrica_zauzeta_0[x, y] = true;

                        matrica_zauzeta_0[x - 1, y + 1] = true;
                        matrica_zauzeta_0[x, y + 1] = (true && !trn) || matrica_zauzeta_0[x, y + 1];
                        matrica_zauzeta_0[x + 1, y + 1] = true;
                        matrica_zauzeta_0[x - 1, y] = (true && !trn) || matrica_zauzeta_0[x - 1, y];
                        matrica_zauzeta_0[x + 1, y] = (true && !trn) || matrica_zauzeta_0[x + 1, y];
                        matrica_zauzeta_0[x - 1, y - 1] = true;
                        matrica_zauzeta_0[x, y - 1] = (true && !trn) || matrica_zauzeta_0[x, y - 1];
                        matrica_zauzeta_0[x + 1, y - 1] = true;

                        return true;
                    }
                }
                else
                {
                    trn = true;
                    MessageBox.Show("Nije validan potez!");
                    return false;
                }
                
            }
            else
            {
                if (!matrica_zauzeta_1[x, y] && (TrenutniBrod.Count() < limit))
                {
                    if (!prviKorakBroda)
                    {
                        if ((Math.Abs(x - trnX) == 1) || (Math.Abs(y - trnY) == 1))
                        {
                            trnX = x;
                            trnY = y;
                            matrica_brodova_1[x, y] = true;

                            matrica_zauzeta_1[x, y] = true;
                            matrica_zauzeta_1[x - 1, y + 1] = true;
                            matrica_zauzeta_1[x, y + 1] = true && !trn || matrica_zauzeta_1[x, y + 1];
                            matrica_zauzeta_1[x + 1, y + 1] = true;
                            matrica_zauzeta_1[x - 1, y] = true && !trn || matrica_zauzeta_1[x - 1, y];
                            matrica_zauzeta_1[x + 1, y] = true && !trn || matrica_zauzeta_1[x + 1, y];
                            matrica_zauzeta_1[x - 1, y - 1] = true;
                            matrica_zauzeta_1[x, y - 1] = true && !trn || matrica_zauzeta_1[x, y - 1];
                            matrica_zauzeta_1[x + 1, y - 1] = true;

                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        prviKorakBroda = false;

                        trnX = x;
                        trnY = y;
                        matrica_brodova_1[x, y] = true;

                        matrica_zauzeta_1[x, y] = true;
                        matrica_zauzeta_1[x - 1, y + 1] = true;
                        matrica_zauzeta_1[x, y + 1] = true && !trn || matrica_zauzeta_1[x, y + 1];
                        matrica_zauzeta_1[x + 1, y + 1] = true;
                        matrica_zauzeta_1[x - 1, y] = true && !trn || matrica_zauzeta_1[x - 1, y];
                        matrica_zauzeta_1[x + 1, y] = true && !trn || matrica_zauzeta_1[x + 1, y];
                        matrica_zauzeta_1[x - 1, y - 1] = true;
                        matrica_zauzeta_1[x, y - 1] = true && !trn || matrica_zauzeta_1[x, y - 1];
                        matrica_zauzeta_1[x + 1, y - 1] = true;

                        return true;
                    }
                    
                }
                else
                {
                    trn = false;
                    MessageBox.Show("Nije validan potez!");
                    return false;
                }
            }
        }

        public void UokviriBrod()
        {
            if (TrenutniBrod.Count() != 0)
            {
                int minX = TrenutniBrod.Min(polje => polje.x);
                int minY = TrenutniBrod.Min(polje => polje.y);
                int maxX = TrenutniBrod.Max(polje => polje.x);
                int maxY = TrenutniBrod.Max(polje => polje.y);

                for (int i = minX - 1; i <= maxX + 1; i++)
                {
                    for (int j = minY - 1; j <= maxY + 1; j++)
                    {
                        if (igracNaPotezu % 2 == 0)
                        {
                            matrica_zauzeta_0[i, j] = true;
                        }
                        else
                            matrica_zauzeta_1[i, j] = true;
                    }
                }
                TrenutniBrod.Clear();
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
