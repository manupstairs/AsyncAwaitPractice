using System;
using System.Threading.Tasks;

namespace AsyncVoidExceptionHandle
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().TaskIntWrongWithResult();
            Console.ReadKey();
        }

        private async Task<int> TaskIntWrongAsync()
        {
            await Task.Delay(100);
            throw new InvalidOperationException();
        }

        public void TaskIntWrongWithResult()
        {
            try
            {
                var result = TaskIntWrongAsync().Result;
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
