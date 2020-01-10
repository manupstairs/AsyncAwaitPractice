using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncExceptionHandle
{
    class CatchAsyncExceptionTester
    {
        private async void ThrowExceptionAsync()
        {
            throw new InvalidOperationException();
        }

        public void AsyncVoidExceptions_CannotBeCaughtByCatch()
        {
            try
            {
                ThrowExceptionAsync();
            }
            catch (Exception ex)
            {
                // The exception is never caught here!
                Console.WriteLine($"We catch an exception: {ex}");
            }
        }
    }
}
