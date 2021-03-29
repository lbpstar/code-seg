using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileExists
{
    public partial class Form1 : Form
    {
        private string serverFilePath = "";
        public Form1()
        {
            InitializeComponent();
            string path = System.Configuration.ConfigurationSettings.AppSettings["ServerPathLabel"].ToString();
            this.serverFilePath = @path;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = GetFileFromServer();
            MessageBox.Show(s);
        }
        private string GetFileFromServer()
        {
            string msg = "";
            bool re = true;

            string te = txtsysproductcode.Text + ".lab";
            re = FileServerIfExists(te, serverFilePath);
            if (!re)
                msg = "该料号没有维护标签模板!";
            else
                msg = "\\\\" + this.serverFilePath + "\\" + te;
            return msg;
        }
        public bool FileServerIfExists(string filename, string spath)
        {
            try
            {
                string floerPath = "\\\\" + spath;
                string fileServerPath = floerPath + "\\" + filename;
                if (System.IO.File.Exists(fileServerPath) == false)
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
