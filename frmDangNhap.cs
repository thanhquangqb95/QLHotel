using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace QLHOTEL
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void lbDangNhap_MouseMove(object sender, MouseEventArgs e)
        {
            lbDangNhap.ForeColor = Color.Firebrick; 
        }

        private void lbDangNhap_MouseLeave(object sender, EventArgs e)
        {
            lbDangNhap.ForeColor = Color.Black;
        }

        private void lbThoat_MouseLeave(object sender, EventArgs e)
        {
            lbThoat.ForeColor = Color.Black;
        }

        private void lbThoat_MouseMove(object sender, MouseEventArgs e)
        {
            lbThoat.ForeColor = Color.Firebrick;
        }
        private void lbThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public DataTable ketnoi(String y)
        {
            DataTable db = new DataTable();
            CSDL.con = new SqlConnection(CSDL.server);// kết lối csdl với chuỗi kết nối là y 
            CSDL.con.Open();// mở kết nỗi
            SqlDataAdapter da = new SqlDataAdapter(y, CSDL.con);
            //biến SqlDataAdapter lấy dữ liệu theo câu lệnh select 
            da.Fill(db);// đổ dữ liệu vào table tạm 
            CSDL.con.Close();// đóng kết nối
            return db;
        }
        private void lbDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTk.Text == "" || txtMK.Text == "")
                MessageBox.Show("Hãy nhập đầy đủ thông tin để đăng nhập");
            else
            {
                DataTable dt = ketnoi(@"Select MaHT,Pass From HeThong where MaHT='"+txtTk.Text+"'");
                if(dt.Rows.Count==0)
                {
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu sau");
                }
                else
                {
                    if(dt.Rows[0][1].ToString()==txtMK.Text)
                    {
                        frmMain x = new frmMain();
                        x.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Tên tài khoản hoặc mật khẩu sai");
                    }
                }
            }
        }
    }
}
