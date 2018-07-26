using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data;
using Newtonsoft.Json.Converters;

namespace json
{
    class Program
    {
        //原文：https://www.cnblogs.com/shang201215019/p/7907655.html
        static void Main(string[] args)
        {
            //待序列化对象
            Student one = new Student()
            { ID = 1, Name = "武松", Age = 250, Sex = "男" };

            //序列化
            string jsonData = JsonConvert.SerializeObject(one);

            Console.WriteLine(jsonData);  //显示结果
            Console.ReadLine();

            //反序列化对象
            string str = "{\"ID\":2,\"Name\":\"鲁智深\",\"Age\":230,\"Sex\":\"男\"}";

            //反序列化
            Student two = JsonConvert.DeserializeObject<Student>(str);

            Console.WriteLine(
                   string.Format("学生信息  ID:{0},姓名:{1},年龄:{2},性别:{3}",
                   two.ID, two.Name, two.Age, two.Sex));//显示结果
            Console.ReadLine();

            //待序列化对象集合
            List<Student> oneList = new List<Student>() {
            new Student{ ID = 1, Name = "武大", Age = 260, Sex = "男" },
            new Student{ ID = 2, Name = "武二", Age = 250, Sex = "男" },
            new Student{ ID = 3, Name = "武三", Age = 240, Sex = "女" }
            }; //定义对象

            string jsonData2 = JsonConvert.SerializeObject(oneList); //序列化

            Console.WriteLine(jsonData2);  //显示结果
            Console.ReadLine();

            //反序列化实体对象集合
            List<Student> twoList = JsonConvert.DeserializeObject<List<Student>>(jsonData2);
            foreach (Student stu in twoList)
            {
                Console.WriteLine(
                string.Format("学生信息  ID:{0},姓名:{1},年龄:{2},性别:{3}",
                stu.ID, stu.Name, stu.Age, stu.Sex));//显示结果   
            }
            Console.ReadLine();

            ////datatable转json
            Console.WriteLine(GetAllCategory());
            Console.ReadLine();
        }
            //datatable转json
            private static string GetAllCategory()

            {

                string result = "";
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(string));
                dt.Columns.Add("name", typeof(string));
                dt.Rows.Add("123", "lisa");
                result = JsonConvert.SerializeObject(dt, new DataTableConverter());
                return result;
            }

        }

    public class Student
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Sex { get; set; }
    }
    
}
