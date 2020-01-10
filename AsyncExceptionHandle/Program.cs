using System;

namespace AsyncExceptionHandle
{
    class Program
    {
        static void Main(string[] args)
        {
            var tester = new CatchAsyncExceptionTester();
            try
            {
                tester.AsyncVoidExceptions_CannotBeCaughtByCatch();
            }
            catch (Exception)
            {
                Console.WriteLine("The topmost try catch");
            }
            Console.ReadKey();
        }
    }
}
