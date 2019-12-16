using System;

namespace segitiga_siku_kiri
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, i, j, menu;
            Console.WriteLine("1. Segitiga Siku-siku model 1. . .");
            Console.WriteLine("2. Segitiga Siku-siku model 2. . .");
            Console.WriteLine("3. Segitiga Siku-siku model 3. . .");

            menu = int.Parse(Console.ReadLine());

            switch (menu)
            {
                case 1:
                    Console.WriteLine("tentukan baris model 1");
                    a = int.Parse(Console.ReadLine());

                    for (i = 0; i <= a; i++)
                    {
                        for (j = 1; j <= i; j++)
                        {
                            Console.Write(i);
                        }

                        Console.WriteLine();
                    }
                    break;
                case 2:
                    Console.WriteLine("tentukan baris model 2");
                    a = int.Parse(Console.ReadLine());

                    for(i = 0; i <= a; i++)
                    {
                        for (j = a; j >= i; j--)
                        {
                            Console.Write(i);
                        }

                        Console.WriteLine();
                    }

                    break;                  
                case  3:
                    Console.WriteLine("tentukan baris model 3");
                    a = int.Parse(Console.ReadLine());
                    for (i = a; i > 0; i--)
                    {
                        for (j = i; j > 0; j--)
                        {
                            Console.Write(" ");
                        }
                        for (j = a; j >= i; j--)
                        {
                            Console.Write("*");
                        }
                        for (j = a; j > i; j--)
                        {
                            Console.Write("*");
                        }
                        Console.WriteLine("");
                    }
                    break;
                    
            }

            Console.WriteLine();
            Console.ReadLine();

            Console.Write("Press any key to continue . . . ");

        }
    }
}
