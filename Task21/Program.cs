using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task21
{
    class Program
    {
        static int n;
        static int m;
        static int[,] field;
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество рядов n=");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество шеренг m=");
            m = Convert.ToInt32(Console.ReadLine());

            field = new int[n, m];
            Thread gar1 = new Thread(Gardner1);
            Thread gar2 = new Thread(Gardner2);
            gar1.Start();
            gar2.Start();

            gar1.Join();
            gar2.Join();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(field[i,j] + " ");
                }

                Console.WriteLine();
            }
            Console.ReadKey();

        }
        static void Gardner1()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (field[i,j] == 0)
                    {
                        field[i,j] = 1;
                        Thread.Sleep(1);
                    }

                }
                

            }
        }
        static void Gardner2()
        {
            for (int i = m-1; i > 0; i--)
            {
                for (int j = n-1; j > 0; j--)
                {
                    if (field[j, i] == 0)
                    {
                        field[j, i] = 2;
                        Thread.Sleep(1);
                    }

                }


            }
        }
    }
}
