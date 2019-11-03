using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    
    enum Marcaj { aer, avion, cabina, necunoscut}
    
    abstract class TablaJoc
    {
       public Marcaj[,] Tabla;
       
       public int hitCabina;
        public TablaJoc() {
            Tabla = new Marcaj[10, 10];
           
        }

       public abstract void initializare();
       public abstract int getLovituri();

        public void afisare()
        {
            Console.WriteLine("  ¦ 0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("--+--------------------");           
            for (int i = 0; i < 10; i++)
            {
                  
                Console.Write((i).ToString() + " ¦ ");
                for (int j = 0; j < 10; j++)
                {
                    char var = marcajToChar(Tabla[i, j]);                                       
                    Console.Write(var + " ");                    
                }
                Console.WriteLine();
                
            }
            Console.WriteLine("\n");
        }
        
        public char marcajToChar(Marcaj val)
        {
            switch (val) {
                case Marcaj.aer: return 'A'; 
                case Marcaj.avion: return '/';
                case Marcaj.cabina: return '*';
                case Marcaj.necunoscut: return 'N';
                default: break;
            }
            return 'H';
        }
        public Marcaj stringToMarcaj(string val)
        {
            switch (val)
            {
                case "A": return Marcaj.aer;
                case "/": return Marcaj.avion;
                case "*": return Marcaj.cabina;
                case "N": return  Marcaj.necunoscut;
                default: 
                    return  Marcaj.necunoscut;
            }
            
        }
        public int orientareToInt(Orientare val)
        {
            switch (val)
            {
                case Orientare.dreapta: return 0;
                case Orientare.jos: return 1;
                case Orientare.stanga: return 2;
                case Orientare.sus: return 3;
                default: break;
            }
            return 10;
        }
    }
}
