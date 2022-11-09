//Mustafa Eren Erdoğan - Nesneye Dayanlı Programlama Ödev 1

using System;


namespace console
{
    class Amiral_Batti
    {
        static void Gemi_Bilgi(int[] gemi, int i)
        {
            Console.WriteLine();
            Console.Write("{0}. geminin X kordinatı : ", i);
            gemi[0] = Convert.ToInt32(Console.ReadLine());
            Console.Write("{0}. geminin Y kordinatı : ", i);
            gemi[1] = Convert.ToInt32(Console.ReadLine());
            Console.Write("Yatay için (0) Dikey için (1): ");
            gemi[2] = Convert.ToInt32(Console.ReadLine());
        }

        static void Harita_Yaz(char[,] harita)
        {
            int x, y;
            x = 0;
            y = 0;
            Console.WriteLine();
            Console.WriteLine("        1  2  3  4  5  6  7  8  9  10 11 12 13 14 15 16 17 18 19 20");
            while (x < 20)
            {
                y = 0;
                Console.Write("{0}\t", (x + 1));
                while (y < 20)
                {
                    if (harita[x, y] == 'O')
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(harita[x, y] + "  ");
                        Console.ResetColor();
                    }
                    else if (harita[x, y] == '*')
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(harita[x, y] + "  ");
                        Console.ResetColor();
                    }
                    else if (harita[x, y] == '-')
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write(harita[x, y] + "  ");
                        Console.ResetColor();
                    }
                    else
                        Console.Write(harita[x, y] + "  ");
                    y++;
                }
                Console.WriteLine();
                x++;
            }
        }

        static void Gemi_Yerlestir(char[,] harita, int[] gemi)
        {
            int i = -1;
            if (gemi[2] == 0)
            {
                //yatay
                while (i < gemi[3] - 1)
                {
                    harita[gemi[1] - 1,gemi[0] + i] = 'O';
                    i++;
                }
            }
            else
            {
                //dikey
                while (i < gemi[3] - 1)
                {
                    harita[gemi[1] + i, gemi[0] - 1] = 'O';
                    i++;
                }
            }

        }

        static void Ates(ref int a, ref int b)
        {
            Console.Write("X Kordinati : ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Y Kordinati : ");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Hedef X : {0} Y : {1}", a, b);
        }

        static void Main(string[] args)
        {
            Console.Clear();
            char[,] harita = new char[20,20];
            char[,] harita_copy = new char[20, 20];
            int x, y, i, a, b, c;
            int[] gemi1 = { 0, 0, 0, 2 };
            int[] gemi2 = { 0, 0, 0, 3 };
            int[] gemi3 = { 0, 0, 0, 4 };


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("**** AMİRAL BATTI ****");
            Console.WriteLine();
            Console.ResetColor();
           
            x = 0;
            y = 0;
            while (x < 20)
            {
                y = 0;
                while (y < 20)
                { 
                    harita[x, y] = 'X';
                    y++;
                }
                x++;
            }
            x = 0;
            y = 0;
            while (x < 20)
            {
                y = 0;
                while (y < 20)
                {
                    harita_copy[x, y] = 'X';
                    y++;
                }
                x++;
            }

            Harita_Yaz(harita);
    
            Gemi_Bilgi(gemi1, 1);
            Gemi_Bilgi(gemi2, 2);
            Gemi_Bilgi(gemi3, 3);


            Gemi_Yerlestir(harita, gemi1);
            Gemi_Yerlestir(harita, gemi2);
            Gemi_Yerlestir(harita, gemi3);

            Harita_Yaz(harita);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" *** OYUN BASLIYOR ***");
            Console.ResetColor();
            System.Threading.Thread.Sleep(2000);
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("**** AMİRAL BATTI ****");
            Console.WriteLine();
            Console.ResetColor();
            Harita_Yaz(harita_copy);
            i = 0;
            a = 0;
            b = 0;
            c = 0;
            while (i < 100)
            {
                Console.WriteLine();
                Ates(ref a, ref b);
                if (harita[b - 1, a - 1] == 'O')
                {
                    harita_copy[b - 1, a - 1] = '*';
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("İsabet");
                    Console.ResetColor();
                    c++;
                    if (c == 9)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write("*** Kazandınız ***");
                        Console.ResetColor();
                        break;
                    }
                }
                else
                {
                    harita_copy[b - 1, a - 1] = '-';
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Iska");
                    Console.ResetColor();
                }
                Harita_Yaz(harita_copy);
                i++;
            }
        }
    }
}