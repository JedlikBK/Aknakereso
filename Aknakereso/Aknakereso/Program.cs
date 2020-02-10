using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aknakereso
{
    class Program
    {
        

        static void Feltöltés(char[,] pálya)
        {  
            for (int i = 0; i < pálya.GetLength(0); i++)
			{
                for (int j = 0; j < pálya.GetLength(1); j++)
			    {
                    pálya[i,j] = '_';
			    }
			}
        }

        static void Main(string[] args)  // Függvény: megadja, hogy az adott hely körül mennyi bomba van!!!!
        {
            char[,] pálya=new char[10,10];
            
            Console.Write("Bombák száma: ");
            int bombaszám = int.Parse(Console.ReadLine());
            Feltöltés(pálya);
            Bombasorsoló(pálya, bombaszám);
            bool legyenbomba= false;
            Kirajzoló(pálya, legyenbomba);  
            int indexX;
            int indexY;
            do
	        {
                Lépés(pálya, out indexX, out indexY, bombaszám);   // Bekér 1 sor és egy 1 oszlop indexet és kirak egy 'X'-et ha nincs ott bomba, van akkor irja ki hogy felrobbantál
                
	        } while (pálya[indexX,indexY]!='B');
                           
            Console.ReadKey();
        }

        static int BombaSzámláló(char[,] pálya, int indexX, int indexY)
        {
            int BombaSzám = 0;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
			    {
                    if (pálya[indexX+j,indexY+i] == 'B')
	                {
                        BombaSzám++;
	                }
			    }
            }


            return BombaSzám;
        }

        static void Bombasorsoló (char[,] pálya, int bombaszám)
        {
            Random gép= new Random();
            int sor;
            int oszlop;
            for (int i = 0; i < bombaszám; i++)
			{
                do
	            {
                    sor = gép.Next(10);
                    oszlop = gép.Next(10);
	            } while (pálya[sor,oszlop] == 'B');
                pálya[sor,oszlop] = 'B';
			}
        }
        static void Kirajzoló (char[,] pálya, bool legyenbomba)
        {
            for (int i = 0; i < pálya.GetLength(0); i++)
			{
                for (int j = 0; j < pálya.GetLength(1); j++)
			    {
                    if (legyenbomba)
	                {
                        Console.Write(pálya[i,j]);
	                }
                    else if (pálya[i,j]!='X')
	                {
                        Console.Write('_');
                    }
                    else
                    {
                        Console.Write('X');
                    }

                    Console.Write('|');
			    }
	
                
                Console.WriteLine();
			}
        }
        static void Lépés (char[,] pálya, out int indexX, out int indexY, int bombaszám)
        {            
            Console.Write("x = ");
            indexX = int.Parse(Console.ReadLine())-1;
            Console.Write("y = ");
            indexY = int.Parse(Console.ReadLine())-1;
            Console.Clear();
            if (pálya[indexX,indexY] == 'B')
	        {
                Console.WriteLine($"Bombák száma: {bombaszám}");
                Kirajzoló(pálya, true);
                Console.WriteLine("Felrobbantál!");
            }
            else
	        {
                Console.WriteLine($"Bombák száma: {bombaszám}");
                pálya[indexX,indexY] = 'X';
                Kirajzoló(pálya, false);
                Console.WriteLine($"Bombák száma: {BombaSzámláló(pálya, indexX, indexY)}");
            }
            
        }
        
        
    }
}
