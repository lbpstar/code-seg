using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDemo
{
    class Program
    {
        // 这个例子说明编译器是元数据的消费者之一，同时编译器又是元数据的生产者。先生产再消费
        [Obsolete("lbpstar:Don't use OldMethod, use NewMethod instead", true)]  
	    static void OldMethod()
	    {
            Console.WriteLine("It is the old method");  
         }  
	     //[Obsolete("Don't use OldMethod, use NewMethod instead", false)]  
        static void NewMethod()
	    {  
	        Console.WriteLine("It is the new method");  
        }  
	    public static void Main()
	    {  
            OldMethod();  
	        NewMethod();  
	        Console.ReadKey();  
         }  

    }
}
