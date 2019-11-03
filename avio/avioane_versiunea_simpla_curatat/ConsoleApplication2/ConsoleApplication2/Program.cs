using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    class Program
    {
        
        static Boolean bPlaneHit = false;        
        static List<Punct> lsLlastHits = new List<Punct>();

        public struct Punct
        {
            public int x;
            public int y;
        }
       
        public static int[,] miAtacuriComputer = new int[10, 10];
        
        public static void initMatrice()
        {            
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {                  
                    miAtacuriComputer[i, j] = 0;
                }
            }
        }



        /// <summary>
        /// Verifica daca locatia data a fost atacata in unul din atacurile anterioare
        /// </summary>
        /// <param name="pct">Coordonatele punctului de verificat</param>
        /// <returns></returns>
        static bool isValidShot(Punct pct)
        {
            if (isValidCoordinate(pct.x,pct.y))
            {
                if (miAtacuriComputer[pct.x, pct.y] == 1)
                {
                    return false;
                }
                else
                {
                return true;
                }
            }
            else
            {
                return false;
            }
            
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

    
        static void updateMatriceAtacuri(Punct pct)
        {
            miAtacuriComputer[pct.x, pct.y] = 1;
        }

     

        public static Punct cautaLovituraRandom()
        {
            Punct pctBestShot;
            Random rndPoz = new Random();

            do
            {//try random positions until a valid one is found
                pctBestShot.x = rndPoz.Next(0, 9);
                pctBestShot.y = rndPoz.Next(0, 9);
            }
            while (!isValidShot(pctBestShot));

            return pctBestShot;
        }

        /// <summary>
        /// Find a valid shot in a 3x3 matrix around the provided point
        /// </summary>
        /// <param name="pct">Point around which to search for a valid shot</param>
        /// <param name="depth">Recursivity depth. Method should be called with value 0</param>
        /// <returns>A valid shooting point</returns>
        public static Punct cautaLovituraInZonaRestransa(Punct pct, int depth)
        {

            int incrementX = 0;
            int incrementY = 0;
            int invalidShotsCounter = 0;
            bool bValidShotFound = false;
            int[] aiRandomValues = { -1, 0, 1 };
            Random rndPoz = new Random();
            Punct pctBestShot;
            
            depth++;//increment indicele de adancime
            do
            {   
                incrementX = aiRandomValues[rndPoz.Next(0, 3)];
                incrementY = aiRandomValues[rndPoz.Next(0, 3)];


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
                if (depth < lsLlastHits.Count - 1)
                {
                    pctBestShot = cautaLovituraInZonaRestransa(lsLlastHits[lsLlastHits.Count - depth], depth);
                }
                else
                {
                    pctBestShot=cautaLovituraRandom();
                }
            }


            return pctBestShot;
        }

        static void Main(string[] args)
        {
            TablaMea tablaMea = new TablaMea();  
            TablaJucator tablaJucator = new TablaJucator();
            Punct pctTempVariable;

            
            tablaMea.initializare();
            tablaJucator.initializare();
            initMatrice();
            tablaMea.afisare();
            tablaJucator.afisare();
            

            //genereaza prima lovitura.
            pctTempVariable = cautaLovituraRandom();

            while ((tablaMea.getLovituri() < 3) && (tablaJucator.getLovituri() < 3))
            {
                //asteapta sa atace jucatorul
                tablaMea.urmMutare();
               
                //ataca cu valoarea calculata anterior
                Marcaj mRezultatAtac = tablaJucator.urmMutare(pctTempVariable.x, pctTempVariable.y);
               
                //update la matricea cu pozitiile atacate anterior
                updateMatriceAtacuri(pctTempVariable);

                if ((mRezultatAtac == Marcaj.aer))
                {//atacul curent a nimerit aer
                    if (bPlaneHit == true)
                    {//in zona a fost descoperit un avion
                        pctTempVariable = cautaLovituraInZonaRestransa(lsLlastHits[lsLlastHits.Count - 1], 0);
                    }
                    else
                    {//in zona NU a fost descoperit un avion
                        pctTempVariable = cautaLovituraRandom();
                    }
                }

                if ((mRezultatAtac == Marcaj.avion))
                {//atacul precedent a lovit un avion
                    
                    lsLlastHits.Add(pctTempVariable); //adaug in lista atacul care a nimerit un avion
                    bPlaneHit = true;
                    pctTempVariable = cautaLovituraInZonaRestransa(lsLlastHits[lsLlastHits.Count-1],0); //cauta urmatoarea lovitura intr`o zona restransa in jurul ultimului atac sucessfull
                }

                if ((mRezultatAtac == Marcaj.cabina))
                {//nimerit cabina. Avion mort
                    bPlaneHit = false;
                    pctTempVariable = cautaLovituraRandom();
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

