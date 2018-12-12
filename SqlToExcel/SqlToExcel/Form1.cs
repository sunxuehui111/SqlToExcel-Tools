﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel;
using Office;
using Microsoft.CSharp;
using System.Data.SqlClient;
using System.IO;
namespace SqlToExcel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string connString;
        public bool inOrout = true;
        private void btnCon_Click(object sender, EventArgs e)
        {
            if (cbDataName.SelectedItem.ToString() == "master")
            {
                this.cbDataName.Items.Clear();
                SqlConnection Connection = new SqlConnection(
                connString);
                System.Data.DataTable DBNameTable = new System.Data.DataTable();
                SqlDataAdapter Adapter = new SqlDataAdapter("select name from master..sysdatabases", Connection);

                lock (Adapter)
                {
                    Adapter.Fill(DBNameTable);
                }

                foreach (DataRow row in DBNameTable.Rows)
                {
                    cbDataName.Items.Add(row["name"]);
                    cbDataName.SelectedIndex = 0;
                }
                Connection.Close();
            }
        }

        private void btndisCon_Click(object sender, EventArgs e)
        {
            connString = "";
            UID.Text = "";
            UID.ReadOnly = true;
            Pwd.Text = "";
            Pwd.ReadOnly = true;
            this.cbDataName.Items.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            this.clbTableName.Items.Clear();
            MessageBox.Show("连接已断开！");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (inOrout)
            {
                int m = 0 ,j = 0;
                for (; m < clbTableName.Items.Count; m++)
                {
                    if (!clbTableName.GetItemChecked(m))
                    {
                        j++;
                    }
                }
                if (m == j)
                {
                    MessageBox.Show("请选择数据库表！");
                    return;
                }
                else
                {
                    for (int i = 0; i < clbTableName.Items.Count; i++)
                    {
                        if (clbTableName.GetItemChecked(i))
                        {
                            string Str = "select * from " + clbTableName.SelectedItem.ToString();
                            SqlConnection sqlCon = new SqlConnection(Form1.connString);
                            sqlCon.Open();
                            SqlCommand command = new SqlCommand();
                            command.Connection = sqlCon;
                            command.CommandText = Str;
                            command.ExecuteNonQuery();
                            SqlDataAdapter sqldb = new SqlDataAdapter(command);
                            System.Data.DataTable bufDatatable = new System.Data.DataTable();
                            sqldb.Fill(bufDatatable);
                            string savefile = tbExcelAdr.Text + string.Format(@"\{0}.xlsx", clbTableName.GetItemText(clbTableName.Items[i]));
                            if (File.Exists(savefile))
                            {
                                if (MessageBox.Show(string.Format("当前目录已存在文件{0}，是否覆盖并导入", clbTableName.GetItemText(clbTableName.Items[i])), "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                {
                                    //确定按钮的方法
                                    File.Delete(savefile);
                                    ExportExcel(bufDatatable, savefile);
                                }
                                else
                                {
                                    //取消按钮的方法
                                    return;
                                }
                            }
                            else
                            {
                                File.Delete(savefile);
                                ExportExcel(bufDatatable, savefile);
                            }
                            sqlCon.Close();
                        }
                    }
                    MessageBox.Show("导出成功！");
                    inOrout = false;
                    btnStart.Text = "刷新";
                }
            }
            else
            {
                btnStart.Text = "导入";
                inOrout = true;
                initControl();
            }
        }

        public static void ExportExcel(System.Data.DataTable dt, String saveFile)
        {
            object objectMissing;
            objectMissing = System.Reflection.Missing.Value;//将一个默认值返回个objectMissing
            if (dt == null || dt.Rows.Count == 0) return;
            Excel.Application xlApp = new Excel.Application();//创建Excel应用程序。
            if (xlApp == null)
            {
                return;
            }
            //System.Globalization.CultureInfo CurrentCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Excel.Workbooks workbooks = xlApp.Workbooks;//创建一个工作簿集合对象。
            Excel.Workbook workbook = workbooks.Add(objectMissing);//创建一个新的工作簿
            Excel.Worksheet worksheet = workbook.Worksheets[1] as Excel.Worksheet;//创建一个工作表对象。
            Excel.Range range;//创建一个excel表格的范围对象。
            long totalCount = dt.Rows.Count;  //获取导出数据行数
            long rowRead = 0;
            float percent = 0;

            //此段代码为表格标题列内容

                for (int i = 0; i < dt.Columns.Count; i++)
            {
                worksheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;//excel的行列是从1开始的  
                range = (Excel.Range)worksheet.Cells[1, i + 1];
                range.Interior.ColorIndex = 15; //15号字体
                range.Font.Bold = true;//粗体
            }

            //此段代码为将数据表中的内容导入到excel表中，因此是从第二行开始的

                for (int r = 0; r < dt.Rows.Count; r++)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    worksheet.Cells[r + 2, i + 1] = dt.Rows[r][i].ToString();
                }
                rowRead++;
                percent = ((float)(100 * rowRead)) / totalCount;
            }
            // xlApp.Visible = true;
            try
            {
                //因为在之前我们已经创建了excel表，但是之前那个还没有数据，因此需要保存。msdn上介绍了save的用法，
                //“当第一次保存excel表示用SaveAs来进行保存文件，下边具体的参数含义，可以具体参照msdn介绍的WookBool.SaveAs()方法”
                workbook.SaveAs(saveFile, objectMissing, objectMissing, objectMissing, objectMissing, objectMissing,
                        XlSaveAsAccessMode.xlExclusive, objectMissing, objectMissing, objectMissing, objectMissing, objectMissing);
            }
            catch (Exception ex)
            {
                MessageBox.Show("有错误：" + ex.ToString());
            }
            xlApp.Quit();//关闭程序。
            //xlApp.
            killMethod.Kill(xlApp);
        }
        public class killMethod
        {
            [System.Runtime.InteropServices.DllImport("User32.dll")]
            public static extern int GetWindowThreadProcessID(IntPtr hwnd, out int ID);
            public static void Kill(Excel.Application excel)
            {
                try
                {
                    IntPtr t = new IntPtr(excel.Hwnd);
                    int k = 0;
                    GetWindowThreadProcessID(t, out k);
                    System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(k);
                    p.Kill();
                }
                catch { }
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                UID.ReadOnly = true;
                Pwd.ReadOnly = true;
                UID.Text = "";
                Pwd.Text = "";
                this.cbDataName.Items.Clear();
                cbDataName.Items.Add("master");
                cbDataName.SelectedIndex = 0;
                connString = "server= " + textServer.Text + ";database= " + cbDataName.SelectedItem.ToString() + ";Trusted_Connection=SSPI";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                UID.ReadOnly = false;
                Pwd.ReadOnly = false;
                UID.Text = "sa";
                Pwd.Text = "123";
                this.cbDataName.Items.Clear();
                cbDataName.Items.Add("master");
                cbDataName.SelectedIndex = 0;
                connString = string.Format("server = {0}; uid = {1}; pwd = {2}; database = {3}", textServer.Text, UID.Text, Pwd.Text, cbDataName.SelectedItem.ToString());
            }
        }

        private void radioButton1_MouseClick(object sender, MouseEventArgs e)
        {
            this.btnCon_Click(sender, e);//触发button事件  
        }

        private void radioButton2_MouseClick(object sender, MouseEventArgs e)
        {
            this.btnCon_Click(sender, e);//触发button事件  
        }

        private void cbDataName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDataName.SelectedItem.ToString() != "master")
            {
                this.clbTableName.Items.Clear();
                if (radioButton1.Checked)
                    connString = "server= " + textServer.Text + ";database= " + cbDataName.SelectedItem.ToString() + ";Trusted_Connection=SSPI";
                else
                    connString = string.Format("server = {0}; uid = {1}; pwd = {2}; database = {3}", textServer.Text, UID.Text, Pwd.Text, cbDataName.SelectedItem.ToString());
                SqlConnection Connection = new SqlConnection(
                   connString);
                Connection.Open();
                System.Data.DataTable dataTable = Connection.GetSchema("Tables");
                foreach (DataRow row in dataTable.Rows)
                {
                    string tableType = (string)row["TABLE_TYPE"];
                    if (tableType.Contains("TABLE"))
                    {
                        clbTableName.Items.Add(row["TABLE_NAME"].ToString());
                    }
                }
                Connection.Close();
            }
        }

        private void Pwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键  
            {
                this.btnCon_Click(sender, e);//触发button事件  
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "选择所有文件存放目录";
            if (folder.ShowDialog() == DialogResult.OK)
            {

                tbExcelAdr.Text = folder.SelectedPath;
            }
        }
        public void initControl()
        {
            tbExcelAdr.Text = "";
            connString = "";
            UID.Text = "";
            UID.ReadOnly = true;
            Pwd.Text = "";
            Pwd.ReadOnly = true;
            this.cbDataName.Items.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            this.clbTableName.Items.Clear();
            this.Update();
        }
    }
}
