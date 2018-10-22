using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.OleDb;

namespace AttendanceNG
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        public delegate bool MethodCaller(string file, string sheet);
        public XtraForm1()
        {
            InitializeComponent();
        }

        private void simpleButtonChose_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel文件(*.xls)|*.xls|Excel文件(*.xlsx)|*.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textEditFile.Text = openFileDialog1.FileName.ToString();
            }

            if (textEditFile.Text.ToString() != "")
            {
                comboBoxSheet.Items.Clear();
                GetExcelSheetName(textEditFile.Text.ToString());
            }
        }

        private void simpleButtonQuery_Click(object sender, EventArgs e)
        {
            simpleButtonQuery.Enabled = false;
            simpleButtonQuery.Text = "排查中。。。";
            string file = textEditFile.Text.ToString().Trim();
            string sheet = comboBoxSheet.Text.ToString();
            if (file == "")
            {
                MessageBox.Show("没有选择文件", "提示信息", MessageBoxButtons.OK);
                simpleButtonQuery.Enabled = true;

            }
            else if (sheet == "")
            {
                MessageBox.Show("请选择sheet表", "提示信息", MessageBoxButtons.OK);
                simpleButtonQuery.Enabled = true;
            }
            else
            {
                Import(file, sheet);
                simpleButtonQuery.Enabled = true;
                simpleButtonQuery.Text = "排查";
            }
        }
        private bool Import(string file, string sheet)
        {
            bool success = true;
            try
            {
                DataTable dt;
                dt = GetDataFromExcel(file, sheet);
                CheckData(dt);
            }
            catch
            {
                MessageBox.Show("失败！");
                success = false;
            }
            return success;
        }
        /// <summary>
        /// 从System.Data.DataTable导入数据到数据库
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private  void CheckData(DataTable dt)
        {
            int count = dt.Rows.Count;
            string fdate = "";
            string ftype;
            DateTime _out, _in;
            TimeSpan ts1,ts2,ts3;
            _out = DateTime.Now;
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("cardno", typeof(string));
            dt2.Columns.Add("name", typeof(string));
            dt2.Columns.Add("out", typeof(DateTime));
            dt2.Columns.Add("in", typeof(DateTime));
            dt2.Columns.Add("munites", typeof(Decimal));
            for (int i = 0;i<count;i++)
            {
                if (dt.Rows[i]["time"].ToString().Trim() != "" && dt.Rows[i]["type"].ToString().Trim() == "" && dt.Rows[i]["cardno"].ToString().Trim() == "")
                {
                    fdate = Convert.ToDateTime(dt.Rows[i]["time"].ToString().Trim()).ToShortDateString().ToString();
                }
                else
                {
                    dt.Rows[i]["time"] = Convert.ToDateTime(fdate + " " + Convert.ToDateTime(dt.Rows[i]["time"].ToString().Trim()).ToLongTimeString().ToString()); 
                }
            }
            var query_cardno = from row in dt.AsEnumerable()
                        group row by row.Field<string>("cardno") into m
                        select new { cardno = m.Key};
            var query_date = from row in dt.AsEnumerable()
                               group row by row.Field<DateTime>("time").Date into m
                               select new { time = m.Key };
            foreach (var item in query_date)
            {
                foreach (var item2 in query_cardno)
                {
                    bool tag = false;
                    for (int i = 0; i < count; i++)
                    {
                        if (item.time != null && item2.cardno != null && Convert.ToDateTime(dt.Rows[i]["time"].ToString().Trim()).Date == item.time && dt.Rows[i]["cardno"].ToString().Trim() == item2.cardno)
                        {
                            ftype = dt.Rows[i]["type"].ToString().Trim();
                            if (ftype.Substring(ftype.Length - 1, 1)=="出")
                            {
                                _out = Convert.ToDateTime(dt.Rows[i]["time"].ToString().Trim());
                                tag= true;
                            }
                            if (ftype.Substring(ftype.Length - 1, 1) == "入")
                            {
                                _in = Convert.ToDateTime(dt.Rows[i]["time"].ToString().Trim());
                                if(tag == true)
                                {
                                    if(Convert.ToDateTime(_in.ToLongTimeString())<= Convert.ToDateTime(timeEdit1.EditValue) || Convert.ToDateTime(_out.ToLongTimeString()) >= Convert.ToDateTime(timeEdit2.EditValue))
                                    {
                                        ts1 = _in - _out;
                                    }
                                    else
                                    {
                                        ts2 = Convert.ToDateTime(timeEdit1.EditValue) - Convert.ToDateTime(_out.ToLongTimeString());
                                        ts3 = Convert.ToDateTime(_in.ToLongTimeString()) - Convert.ToDateTime(timeEdit2.EditValue);
                                        if (ts2.Minutes<0)
                                        {
                                            ts2 = TimeSpan.Zero;
                                        }
                                        if (ts3.Minutes < 0)
                                        {
                                            ts3 = TimeSpan.Zero;
                                        }
                                        ts1 = ts2 + ts3;
                                    }
                                    if (ts1.TotalMinutes>= Convert.ToInt32(textEdit1.Text))
                                    {
                                        dt2.Rows.Add(item2.cardno, dt.Rows[i]["name"].ToString().Trim(), _out,_in, Math.Ceiling(ts1.TotalMinutes));
                                    }
                                }
                                tag = false;
                            }
                        }
                    }
                }
            }
            if(dt2.Rows.Count ==0)
            {
                MessageBox.Show("没有发现异常！");
            }
            else
            {
                Common.DataSetToExcel(dt2, true);
            }
           
        }

        private void GetExcelSheetName(String fileName)
        {
            try
            {
                string connectionString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\";", fileName);
                OleDbConnection conn = new OleDbConnection(connectionString);
                string name;
                conn.Open();
                DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                for (int i = 0; i < schemaTable.Rows.Count; i++)
                {
                    name = schemaTable.Rows[i]["TABLE_NAME"].ToString();
                    comboBoxSheet.Items.Insert(i, name);
                    //comboBox2.DataSource = comboBox2.Items;
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// 获取指定 Excel 文件中工作表的数据
        /// </summary>
        /// <param name="fileName">Excel 的文件名</param>
        /// <returns></returns>
        private DataTable GetDataFromExcel(String fileName, String sheet)
        {
            if (!String.IsNullOrEmpty(sheet))
            {
                string commandText = String.Format("SELECT  time,event,type,cardno,name FROM [{0}] where ltrim(rtrim(time)) <> '' and time is not null", sheet);
                return this.ExecuteDataTable(fileName, commandText);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获取指定 Excel 文件中工作表的数据。
        /// </summary>
        /// <param name="fileName">Excel 的文件名</param>
        /// <param name="commandText">查询 SQL </param>
        private DataTable ExecuteDataTable(String fileName, String commandText)
        {
            string connectionString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\";", fileName);
            using (OleDbDataAdapter da = new OleDbDataAdapter(commandText, connectionString))
            {
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
        }


        private void XtraForm1_Load_1(object sender, EventArgs e)
        {
            textEdit1.Text = "30";
            timeEdit1.EditValue = "11:30";
            timeEdit2.EditValue = "14:00";
        }
    }
}