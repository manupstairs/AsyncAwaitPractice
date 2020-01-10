using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppWithException
{
    class AsyncExceptionTester
    {
        private async void ThrowExceptionAsync()
        {
            await Task.Delay(100);
            throw new InvalidOperationException();
        }

        public void AsyncVoidExceptions_CannotBeCaughtByCatch()
        {
            try
            {
                ThrowExceptionAsync();
            }
            catch (Exception)
            {
                // The exception is never caught here!
                throw;
            }
        }
    }
}
