using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("returnStr:" + test()); 
            Console.ReadKey();

        }
        public static int test()
        {
            int i = 1;
            try
            {
                i = i / 0;
            }
            catch (Exception ex)
            {
                // throw new Exception(ex.Message);
                Console.WriteLine("this is catch" );
            }
            finally
            {

            }
            return i;
        }
    }
}
