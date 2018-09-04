using System;
using System.Collections.Generic;
using System.Linq;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product>  products = InitListProducts();
            foreach (var Item in products)
            {
                GetQty(products, Item);
            }

            foreach (var Item in products)
            {
                Console.WriteLine(Item.Code + ":" + Item.Qty);
            }
            Console.ReadKey();
        }

        public static void GetQty(List<Product> all, Product curProduct)
        {
            if (curProduct.Qty > 0)
            {
                foreach (var Item in all)
                {
                    if (Item.ParentCode != "" && Item.ParentCode == curProduct.Code)
                    {
                        if (Item.Qty == 0)
                        {
                            Item.Qty = curProduct.Qty * 1.1;
                        }
                    }
                }
            }
            else
            {
                Product parent = all.Where(i => i.Code == curProduct.ParentCode).FirstOrDefault();
                GetQty(all, parent);
            }            
        }

        public static List<Product> InitListProducts()
        {
            List<Product> listProducts = new List<Product>();
            //以下打乱顺序
            Product p2 = new Product() { Code = "b", ParentCode = "a", Qty = 0 };
            Product p1 = new Product() { Code = "a", ParentCode = "", Qty = 10 };
            Product p3 = new Product() { Code = "c", ParentCode = "b", Qty = 0 };
            listProducts.Add(p1);
            listProducts.Add(p2);
            listProducts.Add(p3);

            return listProducts;
        }

        public class Product
        {
            public string  Code { get; set; }

            public string ParentCode { get; set; }

            public double Qty { get; set; }

        }

    }
}
