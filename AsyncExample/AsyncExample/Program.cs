using System;
using System.Collections;
using System.Collections.Generic;
using AsyncExample.Async;
using AsyncExample.Callback;
using AsyncExample.Sync;

namespace AsyncExample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //TrySync.Do();
            //Console.ReadKey();

            //TryCallback.Do1();
            //Console.ReadKey();
            //TryCallback.Do1();
            //Console.ReadKey();

            //TryAsync.Do();
            //Console.ReadKey();

            TryYield.Do();
            Console.ReadKey();
        }
    }
}