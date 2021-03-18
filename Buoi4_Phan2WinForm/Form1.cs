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

namespace Buoi4_Phan2WinForm
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        public int StudentID;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetStudentsRecord();
        }

        private void GetStudentsRecord()
        {
            con = new SqlConnection(@"Data Source=ALIKUXAC;Initial Catalog=DemoCrud1;Integrated Security=True");

            SqlCommand com = new SqlCommand("select * from StudentsTb", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = com.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            StudentRecordData.DataSource = dt;
        }
        private bool IsValidData()
        {
            if(txtHoSV.Text == String.Empty || txtTenSV.Text == String.Empty || txtDiaChi.Text == String.Empty || string.IsNullOrEmpty(txtSDT.Text) || string.IsNullOrEmpty(txtSBD.Text))
            {
                MessageBox.Show("Có chỗ chưa nhập dữ liệu!!!", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void ResetData()
        {
            txtHoSV.Text = "";
            txtTenSV.Text = "";
            txtSBD.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";          
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into StudentsTb (Name, FatherName, RollNumber, Address, Mobile) values (@Name, @FatherName, @RollNumber, @Address, @Mobile)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name", txtHoSV.Text);
                cmd.Parameters.AddWithValue("@FatherName", txtTenSV.Text);
                cmd.Parameters.AddWithValue("@RollNumber", txtSBD.Text);
                cmd.Parameters.AddWithValue("@Address", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@Mobile", txtSDT.Text);
                
                
                cmd.ExecuteNonQuery();
                con.Close();
                GetStudentsRecord();
            }
        }

        private void StudentRecordData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int n = StudentRecordData.CurrentRow.Index;
            StudentID = Convert.ToInt32(StudentRecordData.Rows[n].Cells[0].Value);
            txtHoSV.Text = StudentRecordData.Rows[n].Cells[1].Value.ToString();
            txtTenSV.Text = StudentRecordData.Rows[n].Cells[2].Value.ToString();
            txtSBD.Text = StudentRecordData.Rows[n].Cells[3].Value.ToString();
            txtDiaChi.Text = StudentRecordData.Rows[n].Cells[4].Value.ToString();
            txtSDT.Text = StudentRecordData.Rows[n].Cells[5].Value.ToString();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if(StudentID > 0)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update StudentsTb set Name = @Name, FatherName = @FatherName, RollNumber = @RollNumber, Address = @Address, Mobile = @Mobile where StudentID = @ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name", txtHoSV.Text);
                cmd.Parameters.AddWithValue("@FatherName", txtTenSV.Text);
                cmd.Parameters.AddWithValue("@RollNumber", txtSBD.Text);
                cmd.Parameters.AddWithValue("@Address", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@Mobile", txtSDT.Text);
                cmd.Parameters.AddWithValue("ID", this.StudentID);
                cmd.ExecuteNonQuery();
                con.Close();
                GetStudentsRecord();
                ResetData();
            } else
            {
                MessageBox.Show("Cập nhật bị lỗi!!", "Lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (StudentID > 0)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from StudentsTb where StudentID = @ID", con);
                cmd.CommandType = CommandType.Text;
               
                cmd.Parameters.AddWithValue("ID", this.StudentID);
                cmd.ExecuteNonQuery();
                con.Close();
                GetStudentsRecord();
                ResetData();
            }
            else
            {
                MessageBox.Show("Cập nhật bị lỗi!!", "Lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
      
        }
    }
}
