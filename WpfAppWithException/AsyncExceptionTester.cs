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

        private async Task TaskWrongAsync()
        {
            await Task.Delay(100);
            throw new InvalidOperationException();
        }

        public void TaskWrongWithNothing()
        {
            try
            {
                TaskWrongAsync();
            }
            catch (Exception)
            {
                // Sometimes we write log here, but the exception is never caught!
                throw;
            }
        }

        public async void TaskWrongButCatchAsync()
        {
            try
            {
                await TaskWrongAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<int> TaskIntWrongAsync()
        {
            await Task.Delay(100);
            throw new InvalidOperationException();
        }

        public void TaskIntWrongWithResult()
        {
            TaskIntWrongAsync().ContinueWith(t => t.Result);
        }

        public async void LambdaAsyncVoidMethodAsync()
        {
            try
            {
                await Task.Run(SomethingWrongAsync);
            }
            catch (Exception)
            {
                // The exception is never caught here!
                throw;
            }
        }

        public async void LambdaAsyncTaskMethodAsync()
        {
            try
            {
                await Task.Run(TaskWrongAsync);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
