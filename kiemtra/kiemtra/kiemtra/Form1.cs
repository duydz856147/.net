using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace kiemtra
{
    public partial class Form1 : Form
    {
        DataSet hoinghi = new DataSet();
        public class KetNoi
        {
            public SqlConnection connect;
            public KetNoi()
            {
                connect = new SqlConnection("Data Source = A209PC32; Initial Catalog = QLHN; Integrated Security = True");
            }
            public KetNoi(string strcn)
            {
                connect = new SqlConnection(strcn);
            }
        }
        KetNoi kn = new KetNoi();
        SqlConnection connsql;
        public Form1()
        {
            connsql = kn.connect;
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                string insertString;
                insertString = "Insert into HoiNghi values(' " + textBox1.Text + " ', N'" + textBox2.Text + "', N'" + textBox3.Text + "', '" + comboBox1.SelectedValue + "')";
                SqlCommand cmd = new SqlCommand(insertString, connsql);
                cmd.ExecuteNonQuery();
                if (connsql.State == ConnectionState.Open)
                {
                    connsql.Close();
                }
                MessageBox.Show("Thanh Cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show("That Bai");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                string deleteString;
                deleteString = "Delete HoiNghi where tenHoiNghi='" + textBox2.Text + "'";
                SqlCommand cmd = new SqlCommand(deleteString, connsql);
                cmd.ExecuteNonQuery();
                if (connsql.State == ConnectionState.Open)
                {
                    connsql.Close();
                }
                MessageBox.Show("Thanh Cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show("That Bai");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                string query;
                query = "SELECT maLoaiPhong, tenLoaiPhong FROM LoaiPhong";
                SqlDataAdapter ad = new SqlDataAdapter(query, connsql);
                DataTable data = new DataTable();
                ad.Fill(data);
                comboBox1.DataSource = data;
                comboBox1.DisplayMember = "maLoaiPhong";
                comboBox1.ValueMember = "maLoaiPhong";
                string query2;
                query2 = "select * from HoiNghi";
                SqlDataAdapter dsHoiNghi = new SqlDataAdapter(query, connsql);
                dsHoiNghi.Fill(hoinghi, "HoiNghi");
                DataColumn[] key = new DataColumn[1];
                key[0] = hoinghi.Tables["HoiNghi"].Columns[0];
                hoinghi.Tables["HoiNghi"].PrimaryKey = key;
                loadgrid();
                
                
        }
        void Databingding(DataTable pDT)
        {
            textBox2.DataBindings.Clear();
            textBox1.DataBindings.Clear();
            textBox2.DataBindings.Add("Text", pDT, "tenHoiNghi");
            textBox1.DataBindings.Add("Text", pDT, "maHoiNghi");
        }
        void loadgrid()
        {
            dataGridView1.DataSource = hoinghi.Tables[0];
            Databingding(hoinghi.Tables[0]);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
