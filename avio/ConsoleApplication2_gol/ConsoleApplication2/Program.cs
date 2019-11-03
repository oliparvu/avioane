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
        public int[,] TablaCost = new int[9, 9];
        
        public void initializare()
        {
            //pun peste tot necunoscut           
            for (int i = 0; i < 9; i++)
            {

                for (int j = 0; j < 9; j++)
                {

                    TablaCost[i, j] = 50;
                }


            }
        }

        public Punct cautaLovitura(bool primaLovitura)
        {
            Punct pct,coord;
            coord.x = 0;
            coord.y = 0;
            int max = TablaCost[0,0];
            if (primaLovitura == true)
            {

                Random rndPoz = new Random();
                pct.x = rndPoz.Next(2, 8);
                pct.y = rndPoz.Next(2, 8);
            }
            else
            {

                for (int i = 0; i < 9; i++)
                {

                    for (int j = 0; j < 9; j++)
                    {
                        if (TablaCost[i, j] > max)
                        {
                            max = TablaCost[i , j ];
                            coord.x = (i);
                            coord.y = (j);
                        }
                    }
                }
              

            }
            return pct;
        }
        static void Main(string[] args)
        {

            TablaMea tablaMea = new TablaMea();
            TablaJucator tablaJucator = new TablaJucator();
            tablaMea.initializare();
            tablaJucator.initializare();
            tablaMea.afisare();
            tablaJucator.afisare();

            while ((tablaMea.getLovituri() < 3) && (tablaJucator.getLovituri()<3))
            {
               
            tablaMea.urmMutare();
            tablaJucator.urmMutare();
            Console.Clear();
            tablaMea.afisare();
            tablaJucator.afisare();
            }
            Console.WriteLine("Game over");
            Console.Read();

        }
    }
}
