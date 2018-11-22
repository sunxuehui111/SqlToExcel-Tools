using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Data.SqlClient;
namespace tranEtoS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnrefresh.Enabled = false;
        }
        private string connString;
        private void button1_Click(object sender, EventArgs e)
        {
                   //测试，将excel中的student导入到sqlserver的db_test中，如果sql中的数据表不存在则创建 
            if (File.Exists(textBox2.Text))
            {               
                TransferData(textBox2.Text,cbExcelSheet.SelectedItem.ToString(), connString);
                MessageBox.Show(string.Format("导入到数据库 {0} 中 {1} 表成功！", cbDataName.SelectedItem.ToString(), cbExcelSheet.SelectedItem.ToString()));
            }
            else
            {
                MessageBox.Show("文件路径有误!");
            }
        }
            public void TransferData(string excelFile, string sheetName, string connectionString)       
            {       
                DataSet ds = new DataSet();    
                try      
                {    
                    //获取全部数据     
                    string strConn = "Provider = Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + excelFile + ";" + "Extended Properties = 'Excel 8.0;HDR=Yes;IMEX=2';";       
                    OleDbConnection conn = new OleDbConnection(strConn);    
                    conn.Open();
                    string strExcel = "";
                    OleDbDataAdapter myCommand = null;
                    strExcel = string.Format("select * from [{0}$]", sheetName);
                    myCommand = new OleDbDataAdapter(strExcel, strConn);
                    myCommand.Fill(ds, sheetName);    

        
                    //如果目标表不存在则创建,excel文件的第一行为列标题,从第二行开始全部都是数据记录     
                    string strSql = string.Format("if exists(select * from sysobjects where name = '{0}') drop table {0}  create table {0}(", sheetName);   //以sheetName为表名     
        
                    foreach (System.Data.DataColumn c in ds.Tables[0].Columns)    
                    {       
                        strSql += string.Format("[{0}] varchar(255),", c.ColumnName);       
                    }       
                    strSql = strSql.Trim(',') + ")";       
          
                    using (System.Data.SqlClient.SqlConnection sqlconn = new System.Data.SqlClient.SqlConnection(connectionString))       
                    {    
                        sqlconn.Open();       
                        System.Data.SqlClient.SqlCommand command = sqlconn.CreateCommand();       
                        command.CommandText = strSql;       
                        command.ExecuteNonQuery();       
                        sqlconn.Close();    
                    }       
                    //用bcp导入数据        
                    //excel文件中列的顺序必须和数据表的列顺序一致，因为数据导入时，是从excel文件的第二行数据开始，不管数据表的结构是什么样的，反正就是第一列的数据会插入到数据表的第一列字段中，第二列的数据插入到数据表的第二列字段中，以此类推，它本身不会去判断要插入的数据是对应数据表中哪一个字段的     
                    using (System.Data.SqlClient.SqlBulkCopy bcp = new System.Data.SqlClient.SqlBulkCopy(connectionString))       
                    {       
                        bcp.SqlRowsCopied += new System.Data.SqlClient.SqlRowsCopiedEventHandler(bcp_SqlRowsCopied);       
                        bcp.BatchSize = 100;//每次传输的行数        
                        bcp.NotifyAfter = 100;//进度提示的行数        
                        bcp.DestinationTableName = sheetName;//目标表        
                        bcp.WriteToServer(ds.Tables[0]);    
                    }       
                }       
                catch (Exception ex)       
                {       
                    System.Windows.Forms.MessageBox.Show(ex.Message);       
                }     
            }       
          
            //进度显示        
            void bcp_SqlRowsCopied(object sender, System.Data.SqlClient.SqlRowsCopiedEventArgs e)       
            {       
                this.Text = e.RowsCopied.ToString();       
                this.Update();       
            }

            private void button2_Click(object sender, EventArgs e)
            {
                this.cbExcelSheet.Items.Clear();
                System.Windows.Forms.OpenFileDialog fd = new OpenFileDialog();
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    textBox2.Text = fd.FileName;
                    string strConn = "Provider = Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + fd.FileName + ";" + "Extended Properties = 'Excel 8.0;HDR=Yes;IMEX=2';";
                    OleDbConnection conn = new OleDbConnection(strConn);
                    conn.Open(); 
                    DataTable sheetNames = conn.GetOleDbSchemaTable
(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                    conn.Close();
                    foreach (DataRow dr in sheetNames.Rows)
                    {
                        string strSheetTableName = dr[2].ToString();
                        if (strSheetTableName.Contains("$") && strSheetTableName.Replace("'", "").EndsWith("$"))
                        {
                            strSheetTableName = strSheetTableName.Substring(0, strSheetTableName.Length - 1);//提取有效的sheet值
                        }                     
                        cbExcelSheet.Items.Add(strSheetTableName);
                    }
                }
            }

            private void Form1_Load(object sender, EventArgs e)
            {
                
            }

            private void rbWindows_CheckedChanged(object sender, EventArgs e)
            {
                if (rbWindows.Checked)
                {
                    btnrefresh.Enabled = true;
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

            private void rbSql_CheckedChanged(object sender, EventArgs e)
            {
                if (rbSql.Checked)
                {
                    btnrefresh.Enabled = true;
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

            private void btnrefresh_Click(object sender, EventArgs e)
            {
                if (cbDataName.SelectedItem.ToString() == "master")
                {
                    this.cbDataName.Items.Clear();
                    SqlConnection Connection = new SqlConnection(
                    connString);
                    DataTable DBNameTable = new DataTable();
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

                }
            }

            private void cbDataName_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (rbWindows.Checked)
                    connString = "server= " + textServer.Text + ";database= " + cbDataName.SelectedItem.ToString() + ";Trusted_Connection=SSPI";
                else
                    connString = string.Format("server = {0}; uid = {1}; pwd = {2}; database = {3}", textServer.Text, UID.Text, Pwd.Text, cbDataName.SelectedItem.ToString());
            }
        }  
}


