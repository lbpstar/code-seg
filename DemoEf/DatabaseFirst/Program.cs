using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            //DatabaseFirstDbEntities db = new DatabaseFirstDbEntities();

            ////按照ID排序,并查找
            //var model = db.OrderBy(m => m.ID).Select(m => new
            //{
            //    ID = m.ID,
            //    Name = m.Name
            //});


            //if (model.Count() > 0)
            //{
            //    Console.WriteLine("ID号:{0}", model.First().ID);
            //    Console.WriteLine("班级名:{0}", model.First().Name);
            //}
            using (var ctx = new DatabaseFirstDbEntities())
            {

                //var o = new Order();
                //o.OrderDate = DateTime.Now;
                //ctx.Orders.Add(o);
                //ctx.SaveChanges();

                var query = from order in ctx.Orders
                            where order.Id == 1
                            orderby order.Id
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
