using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    enum Orientare { sus, jos, stanga, dreapta };

    class TablaMea : TablaJoc
    {
        int col1, lin1, lin2, col2, lin3, col3, i, j;

        public override void initializare()
        {
            Random rnr = new Random();
            Boolean generat2 = false;
            Boolean generat3 = false;
            hitCabina = 0;
            int orient;//orientare avion 
            //pun peste tot aer
            for (i = 0; i < 10; i++)
            {

                for (j = 0; j < 10; j++)
                {

                    Tabla[i, j] = Marcaj.aer;
                }

            }
            //pun avioanele
            orient = rnr.Next(0, 3);
            if (orient == orientareToInt(Orientare.sus)) //avion orientat in sus
            {
                col1 = rnr.Next(2, 7);
                lin1 = rnr.Next(0, 6);

            }
            if (orient == orientareToInt(Orientare.dreapta)) //avion orientat in dreapta
            {
                col1 = rnr.Next(3, 9);
                lin1 = rnr.Next(2, 7);

            }
            if (orient == orientareToInt(Orientare.stanga)) //avion orientat in stanga
            {
                col1 = rnr.Next(0, 6);
                lin1 = rnr.Next(2, 7);

            }
            if (orient == orientareToInt(Orientare.jos)) //avion orientat in jos
            {
                col1 = rnr.Next(2, 7);
                lin1 = rnr.Next(3, 9);

            }
            i = lin1;
            j = col1;

            if (orient == orientareToInt(Orientare.sus))
            {  //varful in sus, este primul avion si nu are nevoie de verificari
                Tabla[i, j] = Marcaj.cabina;
                Tabla[i + 1, j - 2] = Tabla[i + 1, j - 1] = Tabla[i + 1, j] = Tabla[i + 1, j + 1] = Tabla[i + 1, j + 2] = Tabla[i + 2, j] = Tabla[i + 3, j - 1] = Tabla[i + 3, j] = Tabla[i + 3, j + 1] = Marcaj.avion;

            }
            else if (orient == orientareToInt(Orientare.dreapta))
            { //varful la dreapta
                Tabla[i, j] = Marcaj.cabina;
                Tabla[i - 2, j - 1] = Tabla[i - 1, j - 1] = Tabla[i, j - 1] = Tabla[i + 1, j - 1] = Tabla[i + 2, j - 1] = Tabla[i, j - 2] = Tabla[i - 1, j - 3] = Tabla[i, j - 3] = Tabla[i + 1, j - 3] = Marcaj.avion;
            }
            else if (orient == orientareToInt(Orientare.stanga))
            {//varful in stanga
                Tabla[i, j] = Marcaj.cabina;
                Tabla[i - 2, j + 1] = Tabla[i - 1, j + 1] = Tabla[i, j + 1] = Tabla[i + 1, j + 1] = Tabla[i + 2, j + 1] = Tabla[i, j + 2] = Tabla[i - 1, j + 3] = Tabla[i, j + 3] = Tabla[i + 1, j + 3] = Marcaj.avion;

            }
            else
            { //varful in jos
                Tabla[i, j] = Marcaj.cabina;
                Tabla[i - 1, j - 2] = Tabla[i - 1, j - 1] = Tabla[i - 1, j] = Tabla[i - 1, j + 1] = Tabla[i - 1, j + 2] = Tabla[i - 2, j] = Tabla[i - 3, j - 1] = Tabla[i - 3, j] = Tabla[i - 3, j + 1] = Marcaj.avion;
            }

            int flag = 0;

            //avionul 2
            while (!generat2)
            {
                orient = rnr.Next(0, 3);
                flag++;
                //randomizare a2, x2, y2;
                if (orient == orientareToInt(Orientare.sus)) //avion orientat in sus
                {
                    col2 = rnr.Next(2, 7);
                    lin2 = rnr.Next(0, 6);

                }
                if (orient == orientareToInt(Orientare.dreapta)) //avion orientat in dreapta
                {
                    col2 = rnr.Next(3, 9);
                    lin2 = rnr.Next(2, 7);

                }
                if (orient == orientareToInt(Orientare.stanga)) //avion orientat in stanga
                {
                    col2 = rnr.Next(0, 6);
                    lin2 = rnr.Next(2, 7);

                }
                if (orient == orientareToInt(Orientare.jos)) //avion orientat in jos
                {
                    col2 = rnr.Next(2, 7);
                    lin2 = rnr.Next(3, 9);

                }
                i = lin2;
                j = col2;

                if (orient == orientareToInt(Orientare.sus))  //varful in sus
                {
                    if ((Tabla[i, j] == Marcaj.aer) && (Tabla[i + 1, j - 2] == Marcaj.aer) && (Tabla[i + 1, j - 1] == Marcaj.aer) && (Tabla[i + 1, j] == Marcaj.aer) && (Tabla[i + 1, j + 1] == Marcaj.aer) && (Tabla[i + 1, j + 2] == Marcaj.aer) && (Tabla[i + 2, j] == Marcaj.aer) && (Tabla[i + 3, j - 1] == Marcaj.aer) && (Tabla[i + 3, j] == Marcaj.aer) && (Tabla[i + 3, j + 1] == Marcaj.aer))
                    {
                        Tabla[i, j] = Marcaj.cabina;
                        Tabla[i + 1, j - 2] = Tabla[i + 1, j - 1] = Tabla[i + 1, j] = Tabla[i + 1, j + 1] = Tabla[i + 1, j + 2] = Tabla[i + 2, j] = Tabla[i + 3, j - 1] = Tabla[i + 3, j] = Tabla[i + 3, j + 1] = Marcaj.avion;
                        generat2 = true;
                    }
                }
                else if (orient == orientareToInt(Orientare.dreapta)) //varful la dreapta
                {
                    if ((Tabla[i, j] == Marcaj.aer) && (Tabla[i - 2, j - 1] == Marcaj.aer) && (Tabla[i - 1, j - 1] == Marcaj.aer) && (Tabla[i, j - 1] == Marcaj.aer) && (Tabla[i + 1, j - 1] == Marcaj.aer) && (Tabla[i + 2, j - 1] == Marcaj.aer) && (Tabla[i, j - 2] == Marcaj.aer) && (Tabla[i - 1, j - 3] == Marcaj.aer) && (Tabla[i, j - 3] == Marcaj.aer) && (Tabla[i + 1, j - 3] == Marcaj.aer))
                    {
                        Tabla[i, j] = Marcaj.cabina;
                        Tabla[i - 2, j - 1] = Tabla[i - 1, j - 1] = Tabla[i, j - 1] = Tabla[i + 1, j - 1] = Tabla[i + 2, j - 1] = Tabla[i, j - 2] = Tabla[i - 1, j - 3] = Tabla[i, j - 3] = Tabla[i + 1, j - 3] = Marcaj.avion;
                        generat2 = true;
                    }
                }
                else if (orient == orientareToInt(Orientare.jos))//varful in jos
                {
                    if ((Tabla[i, j] == Marcaj.aer) && (Tabla[i - 1, j - 2] == Marcaj.aer) && (Tabla[i - 1, j - 1] == Marcaj.aer) && (Tabla[i - 1, j] == Marcaj.aer) && (Tabla[i - 1, j + 1] == Marcaj.aer) && (Tabla[i - 1, j + 2] == Marcaj.aer) && (Tabla[i - 2, j] == Marcaj.aer) && (Tabla[i - 3, j - 1] == Marcaj.aer) && (Tabla[i - 3, j] == Marcaj.aer) && (Tabla[i - 3, j + 1] == Marcaj.aer))
                    {
                        Tabla[i, j] = Marcaj.cabina;
                        Tabla[i - 1, j - 2] = Tabla[i - 1, j - 1] = Tabla[i - 1, j] = Tabla[i - 1, j + 1] = Tabla[i - 1, j + 2] = Tabla[i - 2, j] = Tabla[i - 3, j - 1] = Tabla[i - 3, j] = Tabla[i - 3, j + 1] = Marcaj.avion;
                        generat2 = true;
                    }
                }
                else if (orient == orientareToInt(Orientare.stanga))//varful la stanga
                {
                    if ((Tabla[i, j] == Marcaj.aer) && (Tabla[i - 2, j + 1] == Marcaj.aer) && (Tabla[i - 1, j + 1] == Marcaj.aer) && (Tabla[i, j + 1] == Marcaj.aer) && (Tabla[i + 1, j + 1] == Marcaj.aer) && (Tabla[i + 2, j + 1] == Marcaj.aer) && (Tabla[i, j + 2] == Marcaj.aer) && (Tabla[i - 1, j + 3] == Marcaj.aer) && (Tabla[i, j + 3] == Marcaj.aer) && (Tabla[i + 1, j + 3] == Marcaj.aer))
                    {
                        Tabla[i, j] = Marcaj.cabina;
                        Tabla[i - 2, j + 1] = Tabla[i - 1, j + 1] = Tabla[i, j + 1] = Tabla[i + 1, j + 1] = Tabla[i + 2, j + 1] = Tabla[i, j + 2] = Tabla[i - 1, j + 3] = Tabla[i, j + 3] = Tabla[i + 1, j + 3] = Marcaj.avion;
                        generat2 = true;
                    }
                }
                else //incearca alte randomizari
                    generat2 = false;
            }
            //avionul 2
            while (!generat3)
            {
                orient = rnr.Next(0, 3);

                if (orient == orientareToInt(Orientare.sus)) //avion orientat in sus
                {
                    col3 = rnr.Next(2, 7);
                    lin3 = rnr.Next(0, 6);

                }
                if (orient == orientareToInt(Orientare.dreapta)) //avion orientat in dreapta
                {
                    col3 = rnr.Next(3, 9);
                    lin3 = rnr.Next(2, 7);

                }
                if (orient == orientareToInt(Orientare.stanga)) //avion orientat in stanga
                {
                    col3 = rnr.Next(0, 6);
                    lin3 = rnr.Next(2, 7);

                }
                if (orient == orientareToInt(Orientare.jos)) //avion orientat in jos
                {
                    col3 = rnr.Next(2, 7);
                    lin3 = rnr.Next(3, 9);

                }

                i = lin3;
                j = col3;

                if (orient == orientareToInt(Orientare.sus))  //varful in sus
                {
                    if ((Tabla[i, j] == Marcaj.aer) && (Tabla[i + 1, j - 2] == Marcaj.aer) && (Tabla[i + 1, j - 1] == Marcaj.aer) && (Tabla[i + 1, j] == Marcaj.aer) && (Tabla[i + 1, j + 1] == Marcaj.aer) && (Tabla[i + 1, j + 2] == Marcaj.aer) && (Tabla[i + 2, j] == Marcaj.aer) && (Tabla[i + 3, j - 1] == Marcaj.aer) && (Tabla[i + 3, j] == Marcaj.aer) && (Tabla[i + 3, j + 1] == Marcaj.aer))
                    {
                        Tabla[i, j] = Marcaj.cabina;
                        Tabla[i + 1, j - 2] = Tabla[i + 1, j - 1] = Tabla[i + 1, j] = Tabla[i + 1, j + 1] = Tabla[i + 1, j + 2] = Tabla[i + 2, j] = Tabla[i + 3, j - 1] = Tabla[i + 3, j] = Tabla[i + 3, j + 1] = Marcaj.avion;
                        generat3 = true;
                    }
                }
                else if (orient == orientareToInt(Orientare.dreapta)) //varful la dreapta
                {
                    if ((Tabla[i, j] == Marcaj.aer) && (Tabla[i - 2, j - 1] == Marcaj.aer) && (Tabla[i - 1, j - 1] == Marcaj.aer) && (Tabla[i, j - 1] == Marcaj.aer) && (Tabla[i + 1, j - 1] == Marcaj.aer) && (Tabla[i + 2, j - 1] == Marcaj.aer) && (Tabla[i, j - 2] == Marcaj.aer) && (Tabla[i - 1, j - 3] == Marcaj.aer) && (Tabla[i, j - 3] == Marcaj.aer) && (Tabla[i + 1, j - 3] == Marcaj.aer))
                    {
                        Tabla[i, j] = Marcaj.cabina;
                        Tabla[i - 2, j - 1] = Tabla[i - 1, j - 1] = Tabla[i, j - 1] = Tabla[i + 1, j - 1] = Tabla[i + 2, j - 1] = Tabla[i, j - 2] = Tabla[i - 1, j - 3] = Tabla[i, j - 3] = Tabla[i + 1, j - 3] = Marcaj.avion;
                        generat3 = true;
                    }
                }
                else if (orient == orientareToInt(Orientare.jos))//varful in jos
                {
                    if ((Tabla[i, j] == Marcaj.aer) && (Tabla[i - 1, j - 2] == Marcaj.aer) && (Tabla[i - 1, j - 1] == Marcaj.aer) && (Tabla[i - 1, j] == Marcaj.aer) && (Tabla[i - 1, j + 1] == Marcaj.aer) && (Tabla[i - 1, j + 2] == Marcaj.aer) && (Tabla[i - 2, j] == Marcaj.aer) && (Tabla[i - 3, j - 1] == Marcaj.aer) && (Tabla[i - 3, j] == Marcaj.aer) && (Tabla[i - 3, j + 1] == Marcaj.aer))
                    {
                        Tabla[i, j] = Marcaj.cabina;
                        Tabla[i - 1, j - 2] = Tabla[i - 1, j - 1] = Tabla[i - 1, j] = Tabla[i - 1, j + 1] = Tabla[i - 1, j + 2] = Tabla[i - 2, j] = Tabla[i - 3, j - 1] = Tabla[i - 3, j] = Tabla[i - 3, j + 1] = Marcaj.avion;
                        generat3 = true;
                    }
                }
                else if (orient == orientareToInt(Orientare.stanga))//varful la stanga
                {
                    if ((Tabla[i, j] == Marcaj.aer) && (Tabla[i - 2, j + 1] == Marcaj.aer) && (Tabla[i - 1, j + 1] == Marcaj.aer) && (Tabla[i, j + 1] == Marcaj.aer) && (Tabla[i + 1, j + 1] == Marcaj.aer) && (Tabla[i + 2, j + 1] == Marcaj.aer) && (Tabla[i, j + 2] == Marcaj.aer) && (Tabla[i - 1, j + 3] == Marcaj.aer) && (Tabla[i, j + 3] == Marcaj.aer) && (Tabla[i + 1, j + 3] == Marcaj.aer))
                    {
                        Tabla[i, j] = Marcaj.cabina;
                        Tabla[i - 2, j + 1] = Tabla[i - 1, j + 1] = Tabla[i, j + 1] = Tabla[i + 1, j + 1] = Tabla[i + 2, j + 1] = Tabla[i, j + 2] = Tabla[i - 1, j + 3] = Tabla[i, j + 3] = Tabla[i + 1, j + 3] = Marcaj.avion;
                        generat3 = true;
                    }
                }
                else //incearca alte randomizari
                    generat3 = false;
            }

        }
        /// <summary>
        /// Asta se apeleaza cand jucatorul ataca
        /// </summary>
        public void urmMutare()
        {

            Console.WriteLine("Introduceti pozitia de atac(ex: 3 6)");
            string pozitie = Console.ReadLine();

            //citesti o pozitie de tipul celei predefinite
            string[] separator = new string[1];
            separator[0] = " ";
            string[] pozitiiStr = pozitie.Split(separator, 2, System.StringSplitOptions.RemoveEmptyEntries);

            // Console.WriteLine(pozitiiStr[0] + " " + pozitiiStr[1]);
            
            int x = Int16.Parse(pozitiiStr[0]);
            int y = Int16.Parse(pozitiiStr[1]);
            
            Console.WriteLine(Tabla[x, y]);

            if (Tabla[x, y] == Marcaj.cabina)
            {
                hitCabina++;
            }

        }
        public override int getLovituri()
        {
            return hitCabina;
        }
        public Marcaj ceExistaLaCoord(int x,int y)
        {
            return Tabla[x, y];
        }
    }
        class TablaJucator : TablaJoc
        {
            public override void initializare()
            {
                //pun peste tot necunoscut           
                for (int i = 0; i < 10; i++)
                {

                    for (int j = 0; j < 10; j++)
                    {

                        Tabla[i, j] = Marcaj.necunoscut;
                    }


                }
            }
            /// <summary>
            /// asta se apeleaza cand compul tre sa faca o mutare
            /// </summary>
            public Marcaj urmMutare(int x, int y)
            {//OlPa am adaugat aici parametrii de intrare sa nu modific prea mult prin alte parti
                //am bagat si un return

               // int x, y;
                Random rndPoz = new Random();
                //x = rndPoz.Next(1, 9);
                //y = rndPoz.Next(1, 9);

                Console.WriteLine("Atac la : {0} {1}. Ce am nimerit? A / *", x, y);
                string coord = Console.ReadLine();
                
                Tabla[x, y] = stringToMarcaj(coord);
                if (Tabla[x, y] == Marcaj.cabina)
                {
                    hitCabina++;
                }
                return  ceExistaLaCoord(x, y);
            }
            public override int getLovituri()
            {
                return hitCabina;
            }
            public Marcaj ceExistaLaCoord(int x, int y)
            {
                return Tabla[x, y];
            }
        }
    
}
