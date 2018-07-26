using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DemoEf
{
    class OrderContext : DbContext
    {
        public OrderContext(string connectionName)
            : base(connectionName)
        {
        }
        public DbSet<Order> Orders
        {
            get;
            set;
        }

        public DbSet<OrderDetail> OrderDetails
        {
            get;
            set;
        }
    }
}

