using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
namespace Project_J
{
    public partial class พิมพ์รายงาน : Form
    {
        public พิมพ์รายงาน()
        {
            InitializeComponent();
        }

        private void จดซอToolStripMenuItem_Click(object sender, EventArgs e)
        {
            จัดซื้อ f1 = new จัดซื้อ();
            f1.Show();
            this.Hide();
        }

        private void จดจำหนายToolStripMenuItem_Click(object sender, EventArgs e)
        {
            จัดจำหน่าย f2 = new จัดจำหน่าย();
            f2.Show();
            this.Hide();
        }

        private void บรการToolStripMenuItem_Click(object sender, EventArgs e)
        {
            บริการ f4 = new บริการ();
            f4.Show();
            this.Hide();
        }

        private void รบคนสนคาToolStripMenuItem_Click(object sender, EventArgs e)
        {
            รับคืนสินค้า f5 = new รับคืนสินค้า();
            f5.Show();
            this.Hide();
        }

        private void รบคนToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ส่งคืนสินค้า f6 = new ส่งคืนสินค้า();
            f6.Show();
            this.Hide();
        }

        

        private void กลบเมนหลกToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FirstFrom fm = new FirstFrom();
            fm.Show();
            this.Hide();
        }

        private void พิมพ์รายงาน_Load(object sender, EventArgs e)
        {
            MySqlConnection conn;
            string server = "localhost";
            string database = "triple_c_technology";
            string uid = "root";
            string password = "12345678";
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                String sqlCmd = "SELECT Product_Name FROM detail_product";
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    comboBox1.Items.Add(dr["Product_Name"].ToString());
                    comboBox2.Items.Add(dr["Product_Name"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn;
            string server = "localhost";
            string database = "triple_c_technology";
            string uid = "root";
            string password = "12345678";
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                String sqlCmd = "SELECT * FROM sales_data ";
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
                cmd.ExecuteNonQuery();
                MySqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dataReader);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection conn;
            string server = "localhost";
            string database = "triple_c_technology";
            string uid = "root";
            string password = "12345678";
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                String sqlCmd = "SELECT * FROM sales_data WHERE Product_Name = '" + comboBox2.Text + "'";
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
                cmd.ExecuteNonQuery();
                MySqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dataReader);
                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            MySqlConnection conn;
            string server = "localhost";
            string database = "triple_c_technology";
            string uid = "root";
            string password = "12345678";
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                String sqlCmd = "SELECT * FROM sales_data WHERE Product_Name = '" + comboBox1.Text + "'";
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
                cmd.ExecuteNonQuery();
                MySqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dataReader);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            พิมพ์ราย_Report พิม = new พิมพ์ราย_Report();
            พิม.Show();
            this.Hide();

            CrystalRepor11 rpt = new CrystalRepor11();
            MySqlConnection conn;
            string server = "localhost";
            string database = "triple_c_technology";
            string uid = "root";
            string password = "12345678";
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                String sqlCmd = "SELECT * FROM sales_data ";
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
                cmd.ExecuteNonQuery();
                MySqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dataReader);
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                rpt.SetDataSource(ds.Tables[0]);
                พิม.crystalReportViewer1.ReportSource = rpt;
                พิม.crystalReportViewer1.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            TextObject วันที่ = (TextObject)rpt.ReportDefinition.Sections["Section1"].ReportObjects["Text9"];
            วันที่.Text = dateTimePicker1.Value.ToString();
            TextObject วันที่2 = (TextObject)rpt.ReportDefinition.Sections["Section1"].ReportObjects["Text10"];
            วันที่2.Text = dateTimePicker2.Value.ToString();
            TextObject สินค้า = (TextObject)rpt.ReportDefinition.Sections["Section1"].ReportObjects["Text12"];
            สินค้า.Text = comboBox1.Text;
            TextObject สินค้า2 = (TextObject)rpt.ReportDefinition.Sections["Section1"].ReportObjects["Text1"];
            สินค้า2.Text = comboBox2.Text;
            พิม.crystalReportViewer1.ReportSource = rpt;

        }
    }
}
