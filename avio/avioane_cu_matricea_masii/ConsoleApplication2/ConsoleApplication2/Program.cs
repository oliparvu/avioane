using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    class Program
    {
        static TablaMea tablaMea = new TablaMea();

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
                    miTablaCost[i, j] = 50;//valoare neutra
                    miAtacuriComputer[i, j] = 0;
                }
            }
        }




        public static Punct cautaLovitura(bool bPrimaLovitura, Marcaj bLastShootValue)
        {
            Punct pctBestShot;
            int max = -10000;
            bool bValidShotFound=false;
            List<Punct> possibleShots = new List<Punct>();
            int maxSum = 0;
            int[] randomValueArray = {-1,0,1 };
            Random rndPoz = new Random();
            int incrementX, incrementY;

            pctBestShot.x = 9;
            pctBestShot.y = 9;

            if (bPrimaLovitura)
            {//prima lovitura so dont care
                pctBestShot.x = rndPoz.Next(2, 8);
                pctBestShot.y = rndPoz.Next(2, 8);
            }
            else
            {

                if (bLastShootValue == Marcaj.avion)
                {

                }

                if (bLastShootValue == Marcaj.cabina)
                {

                }


                // while (bValidShotFound == false)
                {//cauta valorile maxime din matrice
                    possibleShots = findMaxValues(miTablaCost, 0);

                    do
                    {
                        pctBestShot = possibleShots[rndPoz.Next(0, possibleShots.Count)];
                    }
                    while (isValidShot(pctBestShot) == false);


                    //foreach (Punct pct in possibleShots)
                    //{
                    //    //extrage matrice mica
                    //    if (maxSum < smallMatrixSum(pct))
                    //    {
                    //        if (isValidShot(pct))
                    //        {
                    //            maxSum = smallMatrixSum(pct);
                    //            pctBestShot = pct;
                    //        }
                    //        else
                    //        {
                    //            incrementX = 0;
                    //            incrementY = 0;
                    //            bValidShotFound = false;
                    //            do
                    //            {
                    //                incrementX = randomValueArray[rndPoz.Next(0, 3)];
                    //                incrementY = randomValueArray[rndPoz.Next(0, 3)];


                    //                pctBestShot.x = pct.x + incrementX;
                    //                pctBestShot.y = pct.y + incrementY;
                    //                if (isValidShot(pctBestShot)) bValidShotFound = true;
                    //            }
                    //            while (((incrementX == 0) && (incrementY == 0)) || (bValidShotFound == false));
                    //        }
                            
                    //    }
                    //}
               }
            }
            return pctBestShot;
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



        static List<Punct> findMaxValues(int[,] inMatrix,int lastmax)
        {
            

            Punct pct = new Punct();
            List<hailasa> allSum = new List<hailasa>();
            List<Punct> maxSum = new List<Punct>();
            hailasa tempHailasa = new hailasa();
            
            //calc suma pt toate matricele de 3x3
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    pct.x = i;
                    pct.y = j;
                    tempHailasa.matrixSum = smallMatrixSum(pct);
                    tempHailasa.pct = pct;
                    //adauga suma si elementrul central al matricii in lista
                    allSum.Add(tempHailasa);
                }
            }
            //sorteaza descrescator dupa suma
            List<hailasa> mama = allSum.OrderByDescending(x => x.matrixSum).ToList();

            maxSum.Add(mama[0].pct);

            for (int i = 1; i < mama.Count; i++)
            {
                if (mama[0].matrixSum == mama[i].matrixSum)
                {
                    maxSum.Add(mama[i].pct);
                }
            }

            // at this point maxSum should contain all the points in which the sum of the minimatrix is greatest

            return maxSum;
            

            //int maxVal=-500;
            //List<Punct> outvals=new List<Punct>();
           
            //Punct tempPunct;

            //for (int i = 0; i < 10; i++)
            //{               
            //    for (int j = 0; j < 10; j++)
            //    {
            //         if (inMatrix[i,j]>maxVal)
            //         {
            //             maxVal=inMatrix[i,j];                                             
            //         }
            //    }
            //}

            //for (int i = 0; i < 10; i++)
            //{
            //    for (int j = 0; j < 10; j++)
            //    {
            //        if (inMatrix[i, j] == maxVal)
            //        {
            //            tempPunct.x = i;
            //            tempPunct.y = j;                        
            //            outvals.Add(tempPunct);    
            //        }
            //    }
            //}
            
            //return outvals;
        }

        static void updateMatriceCost(Marcaj m, Punct p)
        {
            miAtacuriComputer[p.x, p.y] = 1;

            switch (m)
            {
                case Marcaj.aer://A
                    {
                        miTablaCost[p.x, p.y] = 0;
                        updateCeluleAdiacente(-10, p);
                    }break;
                case Marcaj.avion:// /
                    {
                        miTablaCost[p.x, p.y] = 0;
                        updateCeluleAdiacente(100, p);
                    }break;
                case Marcaj.cabina:// *
                    {
                        miTablaCost[p.x, p.y] = 200;
                        updateCeluleAdiacente(200, p);
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
        static void Main(string[] args)
        {

            TablaJucator tablaJucator = new TablaJucator();
            tablaMea.initializare();
            tablaJucator.initializare();
            tablaMea.afisare();
            tablaJucator.afisare();
            Punct pctTempVariable;

            initTablaCost();
            pctTempVariable = cautaLovitura(true,Marcaj.aer);

            while ((tablaMea.getLovituri() < 3) && (tablaJucator.getLovituri() < 3))
            {
                //asteapta sa atace jucatorul
                tablaMea.urmMutare();
               
                //ataca cu valoarea calculata anterior
                Marcaj mRezultatAtac = tablaJucator.urmMutare(pctTempVariable.x, pctTempVariable.y);
              //update la matrice cost cu rezultatul atacului
                updateMatriceCost(mRezultatAtac, pctTempVariable);
                
                //cauta next best shot
                pctTempVariable = cautaLovitura(false, mRezultatAtac);
               
                
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