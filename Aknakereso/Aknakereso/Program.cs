using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aknakereso
{
    class Program
    {
        static void Main(string[] args)  // Függvény: megadja, hogy az adott hely körül mennyi bomba van!!!!
        {
            char[,] pálya=new char[12,12];
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
                Ellenörző(pálya);
                
	        } while (pálya[indexX,indexY]!='B' && Ellenörző(pálya) > 44);

            if (Ellenörző(pálya) < 22)
            {
                Console.WriteLine("Győztél!");
            }
            
                           
            Console.ReadKey();
        }
        static int Ellenörző(char[,] pálya)
        {
            int db = 0;
            for (int i = 1; i < pálya.GetLength(0)-1; i++)
			{
                for (int j = 1; j < pálya.GetLength(1)-1; j++)
			    {
                    if (pálya[i,j] == '_')
	                {
                        db++;
	                }
			    }
			}
            return db;
        }

        static int BombaSzámláló(char[,] pálya, int indexX, int indexY)
        {
            int BombaSzám = 0;

            for (int i = indexX-1; i <= indexX+1; i++)
            {
                for (int j = indexY-1; j <= indexY+1; j++)
			    {
                    if (pálya[i,j] == 'B')
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
                    sor = gép.Next(1,11);
                    oszlop = gép.Next(1,11);
	            } while (pálya[sor,oszlop] == 'B');
                pálya[sor,oszlop] = 'B';
			}
        }
        static void Kirajzoló (char[,] pálya, bool legyenbomba)
        {
            for (int i = 1; i < pálya.GetLength(0)-1; i++)
			{
                for (int j = 1; j < pálya.GetLength(1)-1; j++)
			    {
                    if (!legyenbomba)
                    {
                        if (pálya[i,j]=='B')
                        {
                            Console.Write('_');
                        }
                        else
                        {
                            Console.Write(pálya[i, j]);
                        }
                    }
                    else
                    {
                        Console.Write(pálya[i,j]);
                    }

                    Console.Write('|');
			    }              
                Console.WriteLine();
			}
        }
        static void Lépés (char[,] pálya, out int indexX, out int indexY, int bombaszám)
        {            
            
            Console.Write("x = ");
            indexX = int.Parse(Console.ReadLine());
            Console.Write("y = ");
            indexY = int.Parse(Console.ReadLine());
            Console.Clear();
            if (pálya[indexX,indexY] == 'B')
	        {
                Console.WriteLine($"Bombák száma: {bombaszám}");
                pálya[indexX,indexY] = char.Parse(BombaSzámláló(pálya, indexX, indexY).ToString());
                Kirajzoló(pálya, true);
                Console.WriteLine("Felrobbantál!");
            }
            else
	        {
                Console.WriteLine($"Bombák száma: {bombaszám}");
                pálya[indexX,indexY] = char.Parse(BombaSzámláló(pálya, indexX, indexY).ToString());
                Kirajzoló(pálya, false);
            }
                
            
            
        }
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
       
    }
}
