using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    class Program
    {
        TablaMea tablaMea = new TablaMea();
        public struct Punct
        {
            public int x;
            public int y;
        }
        public static int[,] TablaCost = new int[9, 9];
        
        public static void initTablaCost()
        {
            //pun peste tot necunoscut           
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    TablaCost[i, j] = 50;//valoare neutra
                }
            }
        }

        public static Punct cautaLovitura(bool bPrimaLovitura)
        {
            Punct pctBestShot,pctTempShot;
            int max = -10000;
            
            pctTempShot.x = 0;            
            pctTempShot.y = 0;

            if (bPrimaLovitura)
            {//prima lovitura so dont care
                Random rndPoz = new Random();
                pctBestShot.x = rndPoz.Next(2, 8);
                pctBestShot.y = rndPoz.Next(2, 8);
            }
            else
            {
                //cauta valoarea maxima
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (TablaCost[i, j] > max)
                        {
                            max = TablaCost[i,j];
                            pctTempShot.x = (i);
                            pctTempShot.y = (j);
                        }
                    }
                }
            //best shot found 
                pctBestShot = pctTempShot;
            }
            return pctBestShot;
        }

        static void updateMatriceCost(Marcaj m, Punct p)
        {
            switch (m)
            {
                case Marcaj.aer://A
                    {
                        TablaCost[p.x, p.y] = 0;
                        updateCeluleAdiacente(-10, p);
                    }break;
                case Marcaj.avion:// /
                    {
                        TablaCost[p.x, p.y] = 100;
                    }break;
                case Marcaj.cabina:// *
                    {
                        TablaCost[p.x, p.y] = 200;
                    }break;               
            }

        }
        static void updateCeluleAdiacente(int val,Punct p)
        {
            if ((p.x > 0) && (p.y > 0) && (p.x < 9) && (p.y <9))
            {
                for (int i = p.x - 1; i <= p.x + 1; i++)
                {
                    for (int j = p.x - 1; j <= p.x + 1; j++)
                    {
                        TablaCost[i, j] -= 10;//scade valoarea casutelor adiacente cu 1
                    }
                }
            }
            
        }
        static void Main(string[] args)
        {

            TablaMea tablaMea = new TablaMea();
            TablaJucator tablaJucator = new TablaJucator();
            tablaMea.initializare();
            tablaJucator.initializare();
            tablaMea.afisare();
            tablaJucator.afisare();
            Punct pctTempVariable;

            initTablaCost();
            pctTempVariable = cautaLovitura(true);

            while ((tablaMea.getLovituri() < 3) && (tablaJucator.getLovituri() < 3))
            {
                //asteapta sa atace jucatorul
                tablaMea.urmMutare();
               
                //ataca cu valoarea calculata anterior
                Marcaj mRezultatAtac = tablaJucator.urmMutare(pctTempVariable.x, pctTempVariable.y);
              //update la matrice cost cu rezultatul atacului
                updateMatriceCost(mRezultatAtac, pctTempVariable);
                
                //cauta next best shot
                pctTempVariable = cautaLovitura(false);
               
                
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