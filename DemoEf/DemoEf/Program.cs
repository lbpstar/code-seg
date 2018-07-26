using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEf
{
    //Code First:http://www.cnblogs.com/gaodaoheng/articles/6489759.html
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new OrderContext("CodeFirstDb"))
            {

                //var o = new Order();
                //o.OrderDate = DateTime.Now;
                //ctx.Orders.Add(o);
                //ctx.SaveChanges();

                var query = from order in ctx.Orders where order.Id == 1
                            select order;
                foreach (var q in query)
                {
                    Console.WriteLine("OrderId:{0},OrderDate:{1}", q.Id, q.OrderDate);
                }

                Console.Read();
            }
        }
    }
}
