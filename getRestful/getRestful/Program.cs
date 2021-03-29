using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace getRestful
{
    class Program
    {
        static void Main(string[] args)
        {
            string endPoint = @"http://192.168.8.172:90/restful/AuthorityService.svc/AuthToken/get";
            string name = "admin";
            string postd = $@"""Code"":""{name}"",""Password"":""HND@123"",""Ip"":""""";
            string postjson = "{" + postd+ "}";
            var client = new RestClient(endpoint: endPoint,
                            method: HttpVerb.POST,
                            //postData: @"{""Code"":""admin"",""Password"":""HND@123"",""Ip"":""""}");
                            postData: postjson);
            var json = client.MakeRequest();
            Console.WriteLine(json);
            Console.ReadKey();

            //以下这段独立代码就是可用的
            //string _url = @"http://192.168.8.172:90/restful/AuthorityService.svc/AuthToken/get";
            //string jsonParam = @"{""Code"":""admin"",""Password"":""HND@123"",""Ip"":""""}";
            //var request = (HttpWebRequest)WebRequest.Create(_url);
            //request.Method = "POST";
            //request.ContentType = "application/json;charset=UTF-8";
            //var byteData = Encoding.UTF8.GetBytes(jsonParam);
            //var length = byteData.Length;
            //request.ContentLength = length;
            //var writer = request.GetRequestStream();
            //writer.Write(byteData, 0, length);
            //writer.Close();
            //var response = (HttpWebResponse)request.GetResponse();
            //var responseString = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8")).ReadToEnd();
            //Console.WriteLine(responseString.ToString());
        }
    }
}
