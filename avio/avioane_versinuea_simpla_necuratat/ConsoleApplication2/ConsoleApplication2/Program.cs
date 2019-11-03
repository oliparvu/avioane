using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    class Program
    {
        static TablaMea tablaMea = new TablaMea();
        static Punct lastHit;
        static Boolean bPlaneHit = false;
        static Boolean bPlaneDestroyed = false;
        static List<Punct> lastHits = new List<Punct>();

        struct hailasa
        {
            public int matrixSum;
            public Punct pct;
        }
       
        public struct Punct
        {
            public int x;
            public int y;
        }
        public static int[,] miTablaCost = new int[10, 10];
        public static int[,] miAtacuriComputer = new int[10, 10];
        
        public static void initTablaCost()
        {
            
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    miTablaCost[i, j] = 0;
                    miAtacuriComputer[i, j] = 0;
                }
            }
        }




        


        /// <summary>
        /// Calculeaza suma elementelor din jurul unui element dat dintr`o materice
        /// </summary>
        /// <param name="pct">Punctul in jurul caruia se calculeaza suma</param>
        /// <returns></returns>
        static int smallMatrixSum(Punct pct)
        {
            int sum = 0;

            for (int i = pct.x - 1; i <= pct.x + 1; i++)
                for (int j = pct.y - 1; j <= pct.y + 1; j++)
                {
                    if (isValidCoordinate(i,j))
                    {
                        sum += miTablaCost[i,j];
                    }
                }
            return sum;
        }


        /// <summary>
        /// Verifica daca locatia data a fost atacata in unul din atacurile anterioare
        /// </summary>
        /// <param name="pct">Coordonatele punctului de verificat</param>
        /// <returns></returns>
        static bool isValidShot(Punct pct)
        {
            if (miAtacuriComputer[pct.x, pct.y] == 1)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Verifica daca coordonatele date sunt in matrice sau in exteriorul ei
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <returns></returns>
        static bool isValidCoordinate(int x, int y)
        {
            if ((x < 0) || (y < 0) || (x > 9) || (y > 9))
                return false;
            else
                return true;
        }



    
        static void updateMatriceCost(Marcaj m, Punct p)
        {
            miAtacuriComputer[p.x, p.y] = 1;

            switch (m)
            {
                case Marcaj.aer://A
                    {
                        miTablaCost[p.x, p.y] = 0;
                        
                    }break;
                case Marcaj.avion:// /
                    {
                        miTablaCost[p.x, p.y] = 1;
                        
                    }break;
                case Marcaj.cabina:// *
                    {
                        miTablaCost[p.x, p.y] = 2;
                        
                    }break;               
            }

        }

        static void updateCeluleAdiacente(int val,Punct pct)
        {
            for (int i = pct.x - 1; i <= pct.x + 1; i++)
            {
                for (int j = pct.y - 1; j <= pct.y + 1; j++)
                {
                    if (isValidCoordinate(i, j) && ((i!=pct.x) || (j!=pct.y)))
                    {
                        miTablaCost[i, j] += val;
                    }
                }
            }
            //ToDo vezi colturile
            //V2
            //if ((pct.x - 1 >= 0) && (pct.y - 1 >=0)) TablaCost[pct.x -1,pct.y -1] += val;//stanga sus
            //if ((pct.x - 1 >= 0) && (pct.y >= 0))    TablaCost[pct.x - 1, pct.y] += val;//deasupra
            //if ((pct.x - 1 >= 0) && (pct.y + 1 <=9)) TablaCost[pct.x - 1, pct.y + 1] += val;//dreapta sus
            //if ((pct.x >= 0) && (pct.y + 1 <= 9)) TablaCost[pct.x , pct.y + 1] += val;//dreapta
            //if ((pct.x + 1 <=9) && (pct.y + 1 <=9)) TablaCost[pct.x + 1, pct.y + 1] += val;//dreapta jos
            //if ((pct.x + 1 <= 9) && (pct.y  <= 9)) TablaCost[pct.x + 1, pct.y ] += val;//jos
            //if ((pct.x + 1 <= 9) && (pct.y-1 <= 9)&&(pct.y-1 >=0)) TablaCost[pct.x + 1, pct.y - 1 ] += val;//stanga jos
            //if ((pct.x  >= 0) && (pct.y - 1 >= 0)) TablaCost[pct.x , pct.y - 1] += val;//stanga

            //afiseaza
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                   // char var = TablaCost[i, j];
                    Console.Write(miTablaCost[i, j] + " ");
                }
                Console.WriteLine();
           }
           
            
        }

       

        public static Punct cautaLovitura()
        {
            Punct pctBestShot;
            Random rndPoz = new Random();

            do
            {
                pctBestShot.x = rndPoz.Next(1, 9);
                pctBestShot.y = rndPoz.Next(1, 9);
            }
            while (!isValidShot(pctBestShot));

            return pctBestShot;
        }

        public static Punct cautaLovituraMica(Punct pct, int depth)
        {

            int incrementX = 0;
            int incrementY = 0;
            int invalidShotsCounter = 0;
            bool bValidShotFound = false;
            int[] randomValueArray = { -1, 0, 1 };
            Random rndPoz = new Random();
            Punct pctBestShot;
            
            depth++;
            do
            {
                incrementX = randomValueArray[rndPoz.Next(0, 3)];
                incrementY = randomValueArray[rndPoz.Next(0, 3)];


                pctBestShot.x = pct.x + incrementX;
                pctBestShot.y = pct.y + incrementY;
                if (isValidShot(pctBestShot))
                {
                    bValidShotFound = true;
                    
                }
                else
                {
                    invalidShotsCounter++;
                }
            }
            while (((incrementX == 0) && (incrementY == 0)) || ((bValidShotFound == false) && (invalidShotsCounter < 30)));

            if (!bValidShotFound)
            {
                if (depth < lastHits.Count - 1)
                {
                    pctBestShot = cautaLovituraMica(lastHits[lastHits.Count - depth], depth);
                }
                else
                {
                    pctBestShot=cautaLovitura();
                }
            }


            return pctBestShot;
        }

        static void Main(string[] args)
        {

            TablaJucator tablaJucator = new TablaJucator();
            tablaMea.initializare();
            tablaJucator.initializare();
            tablaMea.afisare();
            tablaJucator.afisare();
            Punct pctTempVariable;

            initTablaCost();
            pctTempVariable = cautaLovitura();

            while ((tablaMea.getLovituri() < 3) && (tablaJucator.getLovituri() < 3))
            {
                //asteapta sa atace jucatorul
                tablaMea.urmMutare();
               
                //ataca cu valoarea calculata anterior
                Marcaj mRezultatAtac = tablaJucator.urmMutare(pctTempVariable.x, pctTempVariable.y);
               
                //update la matrice cost cu rezultatul atacului
                updateMatriceCost(mRezultatAtac, pctTempVariable);

                if ((mRezultatAtac == Marcaj.aer))
                {
                    if (bPlaneHit == true)
                    {
                        pctTempVariable = cautaLovituraMica(lastHits[lastHits.Count - 1], 0);
                    }
                    else
                    {
                        pctTempVariable = cautaLovitura();
                    }
                }

                if ((mRezultatAtac == Marcaj.avion))
                {
                    //lastHit = pctTempVariable;
                    lastHits.Add(pctTempVariable);
                    bPlaneHit = true;
                    pctTempVariable = cautaLovituraMica(lastHits[lastHits.Count-1],0); ;
                }

                if ((mRezultatAtac == Marcaj.cabina))
                {
                    bPlaneHit = false;
                    pctTempVariable = cautaLovitura();
                }

              
              
                
                Console.Clear();
                tablaMea.afisare();
                tablaJucator.afisare();
            }
            Console.WriteLine("Game over");
            Console.Read();

        }
    }
}

// enum Marcaj { aer, avion, cabina, necunoscut}