using System;
using System.Threading;

namespace JT.UniStuttgart.StudentLibrary.TDD.threadEx
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart ts = new ThreadStart(() => counter(10));
            Thread T = new Thread(ts);
            T.Start();
            //Thread T = new Thread(new ThreadStart(() => counter(10)));
            //T.Start();
            Console.ReadKey();
        }
        public static void counter(int num)
        {
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);

            }
        }
    }
}
