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
        List<List<Polje>> SviZavrseniBrodovi = new List<List<Polje>>();

        public bool[,] matrica_zauzeta_0;
        public bool[,] matrica_zauzeta_1;
        
        public bool[,] matrica_brodova_0;
        public bool[,] matrica_brodova_1;
        
        public string player0;
        public string player1;

        int brojPogodjenih_0;
        int brojPogodjenih_1;

        public int igracNaPotezu = 0;

        public bool KojaJeZauzeta(int i, int j)
        {
            if (igracNaPotezu % 2 == 0) return matrica_zauzeta_0[i, j];
            else return matrica_zauzeta_1[i, j];
        }

        public bool KojaJeBrodova(int i, int j)
        {
            if (igracNaPotezu % 2 == 0) return matrica_brodova_0[i, j];
            else return matrica_brodova_1[i, j];
        }

        public List<int> velicineBrodova;
        int brojSegmenata;
        public int velicina = 8;


        public void NapraviMatricu()
        {
            if (igracNaPotezu == 0)
            {
                matrica_zauzeta_0 = new bool[velicina + 2, velicina + 2];
                matrica_brodova_0 = new bool[velicina + 2, velicina + 2];
                prethodniPostavljen = true;

                PostaviVelicineBrodova();
            }
            else if(igracNaPotezu == 1)
            {
                matrica_brodova_1 = new bool[velicina + 2, velicina + 2];
                matrica_zauzeta_1 = new bool[velicina + 2, velicina + 2];
                prethodniPostavljen = true;

                PostaviVelicineBrodova();
            }
        }

        private void PostaviVelicineBrodova()
        {
            if (velicina == 8)
            {
                velicineBrodova = new List<int>() { 4, 3, 2, 2 };
                brojSegmenata = 11;
            }
            else if (velicina == 10)
            {
                velicineBrodova = new List<int>() { 5, 4, 3, 3, 2, 2, 2 };
                brojSegmenata = 21;
            }
            else
            {
                velicineBrodova = new List<int>() { 6, 5, 4, 4, 3, 3, 2, 2 };
                brojSegmenata = 29;
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
                if (TrenutniBrod.Count() == limit) UokviriBrod(true);
                limit = x;
                trn = true;
                prviKorakBroda = true;
            }
            else if (!velicineBrodova.Contains(x))
                MessageBox.Show("Nema takvog broda");
            else if (!prethodniPostavljen)
                MessageBox.Show("Nije zavrsen prethodni brod");
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
                        foreach (Polje polje in TrenutniBrod)
                        {
                            trnX = polje.x;
                            trnY = polje.y;
                            if (((Math.Abs(x - trnX) == 1) && y == trnY) ||
                            ((Math.Abs(y - trnY) == 1) && x == trnX))
                            {

                                trnX = x;
                                trnY = y;
                                matrica_brodova_0[x, y] = true;
                                Polje polje1 = new Polje() { x = x, y = y };
                                TrenutniBrod.Add(polje1);

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
                        return false;
                    }
                    else
                    {
                        prviKorakBroda = false;
                        prethodniPostavljen = false;
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
                        foreach (Polje polje1 in TrenutniBrod)
                        {
                            trnX = polje1.x;
                            trnY = polje1.y;

                            if (((Math.Abs(x - trnX) == 1) && y == trnY) ||
                            ((Math.Abs(y - trnY) == 1) && x == trnX))
                            {
                                trnX = x;
                                trnY = y;
                                matrica_brodova_1[x, y] = true;
                                Polje polje = new Polje() { x = x, y = y };
                                TrenutniBrod.Add(polje);

                                matrica_zauzeta_1[x, y] = true;

                                matrica_zauzeta_1[x - 1, y + 1] = true;
                                matrica_zauzeta_1[x, y + 1] = (true && !trn) || matrica_zauzeta_1[x, y + 1];
                                matrica_zauzeta_1[x + 1, y + 1] = true;
                                matrica_zauzeta_1[x - 1, y] = (true && !trn) || matrica_zauzeta_1[x - 1, y];
                                matrica_zauzeta_1[x + 1, y] = (true && !trn) || matrica_zauzeta_1[x + 1, y];
                                matrica_zauzeta_1[x - 1, y - 1] = true;
                                matrica_zauzeta_1[x, y - 1] = (true && !trn) || matrica_zauzeta_1[x, y - 1];
                                matrica_zauzeta_1[x + 1, y - 1] = true;

                                return true;
                            }                            
                        }
                        return false;

                    }
                    else
                    {
                        prviKorakBroda = false;
                        prethodniPostavljen = false;
                        trnX = x;
                        trnY = y;
                        matrica_brodova_1[x, y] = true;
                        Polje polje = new Polje() { x = x, y = y };
                        TrenutniBrod.Add(polje);

                        matrica_zauzeta_1[x, y] = true;

                        matrica_zauzeta_1[x - 1, y + 1] = true;
                        matrica_zauzeta_1[x, y + 1] = (true && !trn) || matrica_zauzeta_1[x, y + 1];
                        matrica_zauzeta_1[x + 1, y + 1] = true;
                        matrica_zauzeta_1[x - 1, y] = (true && !trn) || matrica_zauzeta_1[x - 1, y];
                        matrica_zauzeta_1[x + 1, y] = (true && !trn) || matrica_zauzeta_1[x + 1, y];
                        matrica_zauzeta_1[x - 1, y - 1] = true;
                        matrica_zauzeta_1[x, y - 1] = (true && !trn) || matrica_zauzeta_1[x, y - 1];
                        matrica_zauzeta_1[x + 1, y - 1] = true;

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
        }

        public void UokviriBrod(bool x)
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
                            matrica_zauzeta_0[i, j] = x;
                        }
                        else
                            matrica_zauzeta_1[i, j] = x;
                    }
                }
                SviZavrseniBrodovi.Add(TrenutniBrod);
                TrenutniBrod.Clear();
            }
        }

        public void KompletanBrod()
        {
            if (TrenutniBrod.Count() == limit)
            {
                prethodniPostavljen = true;
                velicineBrodova.Remove(limit);
            }
        }

        public void PostaviVelicinu(int velicina)
        {
            this.velicina = velicina;
        }

        public string VratiImeIgraca()
        {
            if (igracNaPotezu % 2 == 0)
            {
                return player0;
            }
            else
                return player1;
        }

        //-------------------------------------------//

        public bool PotopiBrod(int x, int y)
        {
            if (igracNaPotezu % 2 == 0)
            {
                if (matrica_brodova_1[x, y])
                {
                    brojPogodjenih_0++;
                    Console.WriteLine("Igrac 0 " + x + " " + y);
                    return true;
                }
                else
                {
                    Console.WriteLine(matrica_brodova_0[x, y] + " " + " Igrac 0");
                    return false;
                }
            }
            else
            {
                if (matrica_brodova_0[x, y])
                {
                    brojPogodjenih_1++;
                    Console.WriteLine("Igrac 1 " + x + " " + y);
                    return true;
                }
                else return false;
            }
        }

        public int brojacPostavljenihPolja = 0;

        public bool ProveriZaKrajPostavljanja()
        {
            if (brojacPostavljenihPolja == brojSegmenata)
                return true;
            return false;
        }

        public void ProveriZaKraj()
        {
            if (igracNaPotezu % 2 == 0)
            {
                if (brojPogodjenih_0 == brojSegmenata)
                {
                    MessageBox.Show(String.Format("Bravo šefe \nPobednik je {0}", player0));
                    System.Windows.Application.Current.Shutdown();
                }
            }
            else
            {
                if (brojPogodjenih_1 == brojSegmenata)
                {
                    MessageBox.Show(String.Format("Bravo šefe \nPobednik je {0}", player1));
                    System.Windows.Application.Current.Shutdown();
                }
            }
        }

        

        //void UokviriBrod(List<Polje> lista)
        //{
        //    if (TrenutniBrod.Count() != 0)
        //    {
        //        int minX = lista.Min(polje => polje.x);
        //        int minY = lista.Min(polje => polje.y);
        //        int maxX = lista.Max(polje => polje.x);
        //        int maxY = lista.Max(polje => polje.y);

        //        for (int i = minX - 1; i <= maxX + 1; i++)
        //        {
        //            for (int j = minY - 1; j <= maxY + 1; j++)
        //            {
        //                if (igracNaPotezu % 2 == 0)
        //                {
        //                    matrica_zauzeta_0[i, j] = true;
        //                }
        //                else
        //                    matrica_zauzeta_1[i, j] = true;
        //            }
        //        }
        //    }
        //}

        //void PromeniBrodoveFalse(int i, int j)
        //{
        //    if (igracNaPotezu % 2 == 0) matrica_brodova_0[i, j] = false;
        //    else matrica_brodova_1[i, j] = false;
        //}

        //public void Undo()
        //{
        //    if (TrenutniBrod.Count() != 0)
        //    {
        //        prethodniPostavljen = true;
        //        foreach (Polje polje in TrenutniBrod)
        //        {
        //            PromeniBrodoveFalse(polje.x, polje.y);
        //        }
        //        TrenutniBrod.Clear();
        //        foreach (List<Polje> lista in SviZavrseniBrodovi)
        //        {                   
        //            UokviriBrod(lista);                    
        //        }
        //    }
        //}

    }
}
