
using System;
using System.Buffers;
using System.Xml.Schema;

namespace Игра_в_камешки //надеюсь я выживу //я ебался с этим кодом неделю //господи, до чего я тупой
{
    class Program
    { 
        static void  Hod_igroka(int K1, ref int N)
        {
            K1 = Convert.ToInt32(Console.ReadLine());
            if (K1>0.5*N && N>2)
            {
                Console.WriteLine("Вы не можете брать больше 1/2 от числа N");
                Console.WriteLine("Нажмите Enter для повоторного введения числа");
                Console.ReadKey();
                Console.WriteLine();
                Hod_igroka(K1, ref N);
            }
            N -= K1;
            if (N == 0)
            {
                Console.WriteLine("Вы победитель !!!!");
            }
            else
            {
                Console.WriteLine("Камней в мешочке {0}", N);
            }
        }
        static void Analiz(ref int N, ref int K2)//с ударением на последний слог
        {
            int N1; 
            double vid;
            int a = 0;
            for (int j = 1; j < N / 2; j++)
            {
                N1 = N;
                N1 -=j;
                for (int i = 1; i <= N / 3; i++)
                {
                    vid = 3 * Math.Pow(2, i) - 1;
                    if (vid == N1)
                    {
                        K2 = j;
                        a = 1;
                        if (j==0)
                        {
                            K2 = 1;
                        }
                        break; 
                    }
                }
                if (a == 1)
                {
                    break; 
                }
            }
            Console.WriteLine("Компьютер взял {0} камушков", K2);
            N -= K2;
            if (N == 0)
            {
                Console.WriteLine("Компьютер победил!!!!");
            }
            else
            {
                Console.WriteLine("Камней в мешочке {0}", N);
            }
        }
        static void Pravila()
        {
            Console.WriteLine("Правила игры:");
            for (int i = 0; i<=20;i++)
            {
                Console.Write(" _ "); 
            }
            Console.WriteLine(" ");
            Console.WriteLine("К началу игры в коробке находится некоторое число (N) камешков. ");
            Console.WriteLine("Два соперника (человек и ЭВМ).");
            Console.WriteLine("Необходимио поочередно извлекать из коробки любое количество");
            Console.WriteLine(" камешков (но не больше 1/2 от N)."); 
            Console.WriteLine("Выигрывает тот, кто берет последний камешек.");
            for (int i = 0; i <= 20; i++)
            {
                Console.Write(" _ ");
            }
            Console.WriteLine(" ");
            Console.WriteLine("Нажмите Enter если вы ознакомились с правилами и они вам понятны");
            Console.ReadKey(); 
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте");
            Pravila();
            int N, K1 = 0,K2 = 1; // K1 = камни игрока. К2 = камни ЭВМ 
            Random r = new Random();
            N = r.Next(100);
            Console.Clear();
            Console.WriteLine("Камушков в мешку - {0}",N);
            Console.WriteLine("Жеребьевка...");
            if (r.Next(2) == 1)
            {
                Console.WriteLine("Вы начинаете первым");
                Hod_igroka(K1, ref N);
            }
            else
            {
                Console.WriteLine("Начинает компьютер");
            }
            Analiz(ref N,ref K2);
            do
            {
                Hod_igroka(K1, ref N);
                Analiz(ref N,ref K2);
            } while (N > 0);
        }
    }
}
