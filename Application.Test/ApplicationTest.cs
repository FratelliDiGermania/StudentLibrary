using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;

namespace JT.UniStuttgart.StudentLibrary.TDD.Application.Test
{
    public class ApplicationTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            //SimpleThread();
            ComplexThread();
        }


        public static void SimpleThread()
        {
            ThreadStart ts = new ThreadStart(() => Counter(10));
            Thread T = new Thread(ts);
            T.Start();
        }

        public static void ComplexThread()
        {
            Thread T = new Thread(new ParameterizedThreadStart(ComplexCounter));
            int start = 0;
            int end = 2;
            object[] data = new object[] { start, end };
            T.Start(data);
        }
        public static void Counter(int num)
        {
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine(i);
            }
        }


        public static void ComplexCounter(object data)
        {
            object[] argument = (object[])data;

            int start = (int)argument[0];
            int end = (int)argument[1];
            for (int i = start; i < end; i++)
            {
                Console.WriteLine(33 * i);
            }
        }



    }
}