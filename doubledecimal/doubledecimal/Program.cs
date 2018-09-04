using System;

namespace doubledecimal
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.
            double a1 = 12.23;
            double a2 = a1 * 100; //a2=1223.0

            //2.
            double d1 = 66.24;
            double d2 = d1 * 100; //d2=6623.9999999999991

            //3.
            decimal p1 = 12.34m;
            decimal p2 = p1 * 100; //p2=1234

            //4.
            double dd1 = 1;
            double dd2 = 3;
            double dd3 = dd1 / dd2 * dd2; //dd3=1.0

            //5.
            decimal pp1 = 1;
            decimal pp2 = 3;
            decimal pp3 = pp1 / pp2 * pp2;  //pp3=0.9999999999999999999999999999M


            Console.WriteLine("Hello World!");
        }
    }
}
