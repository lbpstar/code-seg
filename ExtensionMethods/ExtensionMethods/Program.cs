using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionMethods;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "The quick brown fox jumped over the lazy dog.";
            // Call the method as if it were an 
            // instance method on the type. Note that the first
            // parameter is not specified by the calling code.
            int i = s.WordCount();
            string str = s.TestTwoMultiPara(true, "lbp");
            System.Console.WriteLine("Word count of s is {0}", i);
            System.Console.WriteLine(str);
            Console.ReadKey();
        }
    }
}
