using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppWithException
{
    class AsyncExceptionTester
    {
        private async void SomethingWrongAsync()
        {
            await Task.Delay(100);
            throw new InvalidOperationException();
        }

        public void SomethingWrongCannotCatch()
        {
            try
            {
                SomethingWrongAsync();
            }
            catch (Exception)
            {
                // Sometimes we write log here, but the exception is never caught!
                throw;
            }
        }
    }
}
