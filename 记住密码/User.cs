using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 记住密码
{
   [Serializable]
   public class User
    {

       private string loginID;
       public string LoginID 
       {
           get { return loginID; }
           set { loginID = value; }
       }

       private string pwd;
       public string Pwd
       {
           get { return pwd; }
           set { pwd = value; }
       }
    }
}
