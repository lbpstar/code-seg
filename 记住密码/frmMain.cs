using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
//二进制格式将对象序列化和反序列化
using System.Runtime.Serialization.Formatters.Binary;

namespace 记住密码
{
    public partial class frmMain : Form
    {
        //创建用户集合
      
       
        public frmMain()
        {
            InitializeComponent();
        }
        Dictionary<string, User> users = new Dictionary<string, User>();
        private void frmMain_Load(object sender, EventArgs e)
        {
            //读取文件流对象
            FileStream fs = new FileStream("data.bin", FileMode.OpenOrCreate);
            if (fs.Length > 0)
            {
                BinaryFormatter bf = new BinaryFormatter();
                //读出存在Data.bin 里的用户信息
                users = bf.Deserialize(fs) as Dictionary<string, User>;
                //循环添加到Combox1
                foreach (User user in users.Values)
                {
                    combox1.Items.Add(user.LoginID);
                }

                //combox1 用户名默认选中第一个
                if (combox1.Items.Count > 0)
                    combox1.SelectedIndex = combox1.Items.Count-1;
            }
            fs.Close();
        }
       
        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butOK_Click(object sender, EventArgs e)
        {
            User user = new User();
            // 登录时 如果没有Data.bin文件就创建、有就打开
            FileStream fs = new FileStream("data.bin", FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            // 保存在实体类属性中
            user.LoginID = combox1.Text.Trim();
            //保存密码选中状态
            if (chkcaes.Checked)
                user.Pwd = txtPwd.Text.Trim();
            else
                user.Pwd = "";
            //选在集合中是否存在用户名 
            if (users.ContainsKey(user.LoginID))
            {
                //如果有清掉
                users.Remove(user.LoginID);
            }
            //添加用户信息到集合
            users.Add(user.LoginID, user);
            //写入文件
            bf.Serialize(fs, users);
            //关闭
            fs.Close();
            MessageBox.Show("保存密码成功！请关闭窗体看效果");
        } 
       
        //当用户名下拉选项发生改变时 
        private void combox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayUserInfo();
        }
        //当用户名文本发生改变时 
        private void combox1_TextChanged(object sender, EventArgs e)
        {
            DisplayUserInfo();
           
        }
        //显示用户所对应匹配的信息
        private void DisplayUserInfo()
        {

            string key = combox1.Text.Trim();
            //查找用户Id
            if (users.ContainsKey(key) == false)
            {
                txtPwd.Text = "";
                return;
            }
            //查找到赋值
            User user = users[key];
            txtPwd.Text = user.Pwd;
            // 如有有密码 选中复选框
            chkcaes.Checked = txtPwd.Text.Trim().Length > 0 ? true : false;
        }

   
    }
}
