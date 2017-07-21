using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLHOTEL
{
    public partial class frmMain : Form
    {
        CSDL csdl = new CSDL();
        DataTable KhachHang;
        DataTable DSPhongTrong;
        String dichvu;
        String manv;
        int co_datphong = 0;
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            khoidong();
            KhachHang = ketnoi(@"select * from KhachHang");
            hienthi_khachhang();
            hienthi_DichVu();
            hienthi_NhanVien();
            
        }
        public void khoidong()
        {
            CSDL.con = new SqlConnection(CSDL.server);// kết lối csdl với chuỗi kết nối là y 
            CSDL.con.Open();// mở kết nỗi
            DataTable tam = new DataTable();//tạo table để lưu kết quả khi lấy dũ liệu từ csdl 
            SqlDataAdapter da = new SqlDataAdapter(@"select TenLoai from LoaiPhong", CSDL.con);
            //biến SqlDataAdapter lấy dữ liệu theo câu lệnh select 
            da.Fill(tam);// đổ dữ liệu vào table tạm 
            CSDL.con.Close();// đóng kết nối
            int i = 0;
            while (i < tam.Rows.Count)
            {
                cbbLoaiPhong.Items.Add(tam.Rows[i][0].ToString());
                i++;
            }
            DataTable dt = ketnoi(@"select * from DichVu");
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dt.Rows[j][0].ToString();
                item.SubItems.Add(dt.Rows[j][1].ToString());
                item.SubItems.Add(dt.Rows[j][2].ToString());
                lvDichVu.Items.Add(item);
            }
            DataTable dt2 = ketnoi(@"select TenCV from ChucVu");
            DataTable dt3 = ketnoi(@"select TenBoPhan from BoPhan");
            for(int k=0;k<dt2.Rows.Count; k++)
            {
                cbbChucVu_nv.Items.Add(dt2.Rows[k][0].ToString());
            }
            for (int h = 0; h < dt3.Rows.Count; h++)
            {
                cbbBoPhan_NV.Items.Add(dt3.Rows[h][0].ToString());
            }
        }
        public void hienthi_khachhang ()
        {
            lvKhachHang.Items.Clear();
            DataTable Kh = ketnoi(@"select * from KhachHang");
            for (int k = 0; k < Kh.Rows.Count; k++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = Kh.Rows[k][0].ToString();
                item.SubItems.Add(Kh.Rows[k][1].ToString());
                item.SubItems.Add(Kh.Rows[k][2].ToString());
                item.SubItems.Add(Kh.Rows[k][3].ToString());
                if (Kh.Rows[k][4].ToString() == "True")
                    item.SubItems.Add("nam");
                else
                    item.SubItems.Add("nữ");
                item.SubItems.Add(Kh.Rows[k][5].ToString());
                lvKhachHang.Items.Add(item);

            }
            KhachHang = ketnoi(@"select * from KhachHang");

        }
        public void hienthi_NhanVien()
        {
            lvNhanVien.Items.Clear();
            DataTable nv = ketnoi(@"select MaNV,TenNV, NgaySinh, GioiTinh, DienThoai, DiaChi , TenBoPhan ,TenCV from NhanVien n, BoPhan b, ChucVu c where n.MaBP= b.MaBP and c.MaCV=n.MaCV");
            for (int i = 0; i < nv.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = nv.Rows[i][0].ToString();
                item.SubItems.Add(nv.Rows[i][1].ToString());
                item.SubItems.Add(nv.Rows[i][2].ToString());
                if (nv.Rows[i][3].ToString() == "True")
                    item.SubItems.Add("nam");
                else
                    item.SubItems.Add("nữ");
                item.SubItems.Add(nv.Rows[i][4].ToString());
                item.SubItems.Add(nv.Rows[i][5].ToString());
                item.SubItems.Add(nv.Rows[i][7].ToString());
                item.SubItems.Add(nv.Rows[i][6].ToString());
                lvNhanVien.Items.Add(item);
            }
            
        }
        public void hienthi_NhanVien2(DataTable nv)
        {
            lvNhanVien.Items.Clear();
            for (int i = 0; i < nv.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                DataTable dt = ketnoi(@"select TenBoPhan from BoPhan where MaBP=N'" + nv.Rows[i][7].ToString() + "'");
                DataTable dt2 = ketnoi(@"select TenCV from ChucVu where MaCV=N'" + nv.Rows[i][6].ToString() + "'");
                item.Text = nv.Rows[i][0].ToString();
                item.SubItems.Add(nv.Rows[i][1].ToString());
                item.SubItems.Add(nv.Rows[i][2].ToString());
                if (nv.Rows[i][3].ToString() == "True")
                    item.SubItems.Add("nam");
                else
                    item.SubItems.Add("nữ");
                item.SubItems.Add(nv.Rows[i][4].ToString());
                item.SubItems.Add(nv.Rows[i][5].ToString());
                item.SubItems.Add(dt.Rows[0][0].ToString());
                item.SubItems.Add(dt2.Rows[0][0].ToString());
                lvNhanVien.Items.Add(item);
            }

        }
        public void capnhap_nv()
        {
            txtHoTen_nv.Text = "";
            dateNgaySinh_NV.Text = "";
            cbbGioiTinh_nv.Text = "";
            txtSDT_NV.Text = "";
            txtDiaChi_nv.Text = "";
            cbbChucVu_nv.Text = "";
            cbbBoPhan_NV.Text = "";
        }
        public void hienthi_DichVu()
        {
            lvDichVu_dvp.Items.Clear();
            DataTable dv = ketnoi(@"select * from DichVu");
            for (int i = 0; i < dv.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dv.Rows[i][0].ToString();
                item.SubItems.Add(dv.Rows[i][1].ToString());
                item.SubItems.Add(dv.Rows[i][2].ToString());
                lvDichVu_dvp.Items.Add(item);
            }
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
        private void btThem_Click(object sender, EventArgs e)
        {
            if (cbbLoaiPhong.Text == "")
                MessageBox.Show("Hãy Chọn Loại Phòng");
            else
            {
                if (txtSoLuong.Text == "")
                    MessageBox.Show("Nhập Số Lượng phòng");
                else
                {
                    DSPhongTrong = ketnoi(@"select TenLoai,Count(p.MaLoai) from phong p, LoaiPhong l 
                    where l.MaLoai=p.MaLoai and   p.MaPhong not in 
                    (select p.MAPHONG from Phong p, ChiTietDatPhong c, PhieuDatPhong d
                       where p.MaPhong= c.MaPhong and c.MaPDP=d.MaPDP and (d.NgayNhanPhong+SoNgay)>'" 
                        + dateNgayNhanPhong.Text + "'and p.MaPhong not in (select MaPhong from PhieuNhanPhong n , ChiTietNhanPhong c where n.MaPNP = c.MaPNP and TinhTrang = 0))group by p.MaLoai,TenLoai");
                    for (int i = 0; i < lvDanhSachPhong.Items.Count; i++)
                    {
                        if (cbbLoaiPhong.Text == lvDanhSachPhong.Items[i].Text)
                        {
                            int s = Int32.Parse(lvDanhSachPhong.Items[i].SubItems[1].Text) + Int32.Parse(txtSoLuong.Text);
                            for(int j=0; j<DSPhongTrong.Rows.Count; j++)
                            {
                                if(cbbLoaiPhong.Text==DSPhongTrong.Rows[j][0].ToString())
                                {
                                    if(s> Int32.Parse(DSPhongTrong.Rows[j][1].ToString()))
                                    {
                                        MessageBox.Show("Số Phòng Bạn Đặt vượt quá số lượng còn trống");
                                        return;
                                    }
                                    else
                                    {
                                        lvDanhSachPhong.Items[i].SubItems[1].Text = s.ToString();
                                        return;
                                    }
                                }
                            }
                            
                        }
                    }
                    for (int j = 0; j < DSPhongTrong.Rows.Count; j++)
                    {
                        if (cbbLoaiPhong.Text == DSPhongTrong.Rows[j][0].ToString())
                        {
                            if (Int32.Parse(txtSoLuong.Text) > Int32.Parse(DSPhongTrong.Rows[j][1].ToString()))
                            {
                                MessageBox.Show("Số Phòng Bạn Đặt vượt quá số lượng còn trống");
                                return;
                            }

                            else
                            {
                                ListViewItem item = new ListViewItem();
                                item.Text = cbbLoaiPhong.Text;
                                item.SubItems.Add(txtSoLuong.Text);
                                lvDanhSachPhong.Items.Add(item);
                                return;
                            }
                        }
                    }
                    MessageBox.Show("Số Phòng Bạn Đặt vượt quá số lượng còn trống");

                }
            }
            capnhap_tapdatphong();
        }

        private void lvDanhSachPhong_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var item = e.Item;
            cbbLoaiPhong.Text = item.Text;
            txtSoLuong.Text = item.SubItems[1].Text;
            btXoa.Enabled = true;
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (cbbLoaiPhong.Text.Length == 0)
            {
                MessageBox.Show("Hãy Click vào dòng cần xóa");
                
            }
            else
            {
                
                foreach (ListViewItem it in lvDanhSachPhong.Items)
                {
                    if (it.Text == cbbLoaiPhong.Text)
                    {
                        it.Remove();
                    }
                    else
                        MessageBox.Show("không tìm thấy dòng cần xóa");
                }
                btXoa.Enabled = false;
            }
            capnhap_tapdatphong();
        }

        private void Luu_Click(object sender, EventArgs e)
        {
            DataTable db = ketnoi(@"select * from KhachHang where CMND='" + txtCMND.Text + "'");
            if (db.Rows.Count != 0)
            {
                MessageBox.Show("Khách Hàng này đã có");
            }
            else
            {
                try
                {
                    CSDL.con.Open();
                    String phai;
                    if (cbbGioiTinh.Text == "nam")
                        phai = "1";
                    else
                        phai = "0";
                    SqlCommand com = new SqlCommand("insert into KhachHang values('" + txtCMND.Text + "','"
                        + txtHoTen.Text + "','" + txtSDT.Text + "','" + dateNgaySinh.Text + "',"
                        + phai + ",'" + txtDiaChi.Text + "')", CSDL.con);
                    com.ExecuteNonQuery();
                    CSDL.con.Close();
                    MessageBox.Show("Lưu thành công");
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi");
                }
            }
        }

        private void txtCMND_Enter(object sender, EventArgs e)
        {
            
        }

        private void btDatPhong_Click(object sender, EventArgs e)
        {
            try
            {
                CSDL.con.Open();
                SqlCommand com = new SqlCommand("insert into PhieuDatPhong values ('" + dateNgayDatPhong.Value.Date.ToString("MM-dd-yyyy")
                    + "','" + txtCMND.Text + "','" + dateNgayNhanPhong.Value.Date.ToString("MM-dd-yyyy") + "','1',"
                    + txtSoNgay.Text + ",1)", CSDL.con);
                com.ExecuteNonQuery();
                CSDL.con.Close();
                int n = 0;
                foreach (ListViewItem it in lvDanhSachPhong.Items)
                {
                    n = n + Int32.Parse(it.SubItems[1].Text);
                }
                String[] maphong = new String[n];
                String maphieu;
                CSDL.con.Open();
                DataTable tam3 = new DataTable();
                SqlDataAdapter da3 = new SqlDataAdapter(@"select top 1 MaPDP from PhieuDatPhong order by MaPDP desc", CSDL.con);
                da3.Fill(tam3);
                maphieu = tam3.Rows[0][0].ToString();
                CSDL.con.Close();
                int j = 0;
                foreach (ListViewItem it in lvDanhSachPhong.Items)
                {
                    int l = Int32.Parse(it.SubItems[1].Text);
                    for (int i = 0; i < l; i++)
                    {
                        //Luucsdl("set DateFormat DMY");
                        CSDL.con.Open();
                        DataTable tam = new DataTable();//tạo table để lưu kết quả khi lấy dũ liệu từ csdl 
                        SqlDataAdapter da = new SqlDataAdapter(@"select MaLoai from LoaiPhong where TenLoai=N'" + it.Text + "'", CSDL.con);
                        //biến SqlDataAdapter lấy dữ liệu theo câu lệnh select 
                        da.Fill(tam);// đổ dữ liệu vào table tạm 
                        DataTable tam2 = new DataTable();//tạo table để lưu kết quả khi lấy dũ liệu từ csdl 
                        SqlDataAdapter da2 = new SqlDataAdapter(@"select top 1 MaPhong from phong where MaLoai='" + tam.Rows[0][0].ToString()
                        + "'and MaPhong not in (select p.MAPHONG from Phong p, ChiTietDatPhong c, PhieuDatPhong d where p.MaPhong = c.MaPhong and c.MaPDP = d.MaPDP and(d.NgayNhanPhong + SoNgay) > '"
                        +dateNgayNhanPhong.Text+ "'and p.MaPhong not in (select MaPhong from PhieuNhanPhong n , ChiTietNhanPhong c where n.MaPNP=c.MaPNP and n.MaPDP=d.MaPDP and TinhTrang=0))", CSDL.con);
                        da2.Fill(tam2);
                        CSDL.con.Close();
                        maphong[j] = tam2.Rows[0][0].ToString();
                        CSDL.con.Open();
                        SqlCommand com2 = new SqlCommand("insert into ChiTietDatPhong values ('" + maphong[j]
                            + "','" + maphieu + "')", CSDL.con);
                        com2.ExecuteNonQuery();
                        CSDL.con.Close();
                        j++;
                    }
                }
                MessageBox.Show("Đặt Phòng Thành Công");
                capnhat();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void capnhat()
        {
            txtCMND.Text = "";
            txtDiaChi.Text = "";
            txtHoTen.Text = "";
            txtSDT.Text = "";
            txtSoLuong.Text = "";
            txtSoNgay.Text = "";
            cbbGioiTinh.Text = "";
            cbbLoaiPhong.Text = "";
            dateNgayDatPhong.Text = "";
            dateNgayNhanPhong.Text = "";
            dateNgaySinh.Text = "";
            lvDanhSachPhong.Items.Clear();
        }

        private void btNhap_Click(object sender, EventArgs e)
        {
            lvDanhSachDat.Items.Clear();
            lvDichVuDaChon.Items.Clear();
            DataTable dt = ketnoi(@"select * from KhachHang where CMND ='" + txtCMND2.Text + "'");
            DataTable dt2 = ketnoi(@"select top 1 MaPDP ,day(NgayNhanPhong), month(NgayNhanPhong),year(NgayNhanPhong) from PhieuDatPhong where CMND='" + txtCMND2.Text + "'and TinhTrang =1 order by NgayNhanPhong");
            if (dt2.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy thông tin đặt phòng từ số CMND đã nhập");
            }
            else
            {
                DataTable dt3 = ketnoi(@"select MaPDP,c.MaPhong ,TenLoai,Gia  from ChiTietDatPhong c, Phong p , LoaiPhong  l where c.MaPhong=p.MaPhong and p.MaLoai=l.MaLoai and MaPDP='"
                + dt2.Rows[0][0].ToString() + "'");
                lbHoTen.Text = dt.Rows[0][1].ToString();
                lbSDT.Text = dt.Rows[0][2].ToString();
                lbNGaySinh.Text = dt.Rows[0][3].ToString();
                lbDiaChi.Text = dt.Rows[0][5].ToString();
                lbNgayNhanPhong.Text = dt2.Rows[0][1].ToString()+ "/" + dt2.Rows[0][2].ToString()+"/"+dt2.Rows[0][3].ToString();
                if (dt.Rows[0][4].ToString() == "True")
                    lbGioiTinh.Text = "nam";
                else
                    lbGioiTinh.Text = "nữ";
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(); ;
                    item.Text = dt3.Rows[i][0].ToString();
                    item.SubItems.Add(dt3.Rows[i][1].ToString());
                    item.SubItems.Add(dt3.Rows[i][2].ToString());
                    item.SubItems.Add(dt3.Rows[i][3].ToString());
                    lvDanhSachDat.Items.Add(item);
                }
            }
        }

        private void lvDichVu_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            String MaDV;
            String TenDV;
            String Gia;
            var item = e.Item;
            foreach (ListViewItem it in lvDichVuDaChon.Items)
            {
                if (item.Text == it.Text)
                {

                    return;
                }
            }
            MaDV = item.Text;
            TenDV = item.SubItems[1].Text;
            Gia = item.SubItems[2].Text;
            ListViewItem item2 = new ListViewItem();
            item2.Text = MaDV;
            item2.SubItems.Add(TenDV);
            item2.SubItems.Add(Gia);
            lvDichVuDaChon.Items.Add(item2);

        }

        private void lvDichVuDaChon_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var item = e.Item;
            dichvu = item.Text;
        }

        private void btXoa2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem it in lvDichVuDaChon.Items)
            {
                if (it.Text == dichvu)
                    it.Remove();
            }
        }

        public int Luucsdl(String y)
        {
            try
            {
                CSDL.con.Open();
                SqlCommand com = new SqlCommand(y, CSDL.con);
                com.ExecuteNonQuery();
                CSDL.con.Close();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        private void btNhanPhong_Click(object sender, EventArgs e)
        {
            DataTable dt = ketnoi(@"select * from PhieuDatPhong where MaPDP ='"+lvDanhSachDat.Items[0].Text+"' and NgayNhanPhong ='"+ DateTime.Today.ToString("MM/dd/yyyy") + "'");
            if (dt.Rows.Count!=0)
            {
                int luupdp = Luucsdl("insert into PhieuNhanPhong values ('" + DateTime.Now + "','" + lvDanhSachDat.Items[0].Text + "',1)");

                if (luupdp == 1)
                {
                    foreach (ListViewItem it in lvDanhSachDat.Items)
                    {
                        if (Luucsdl("insert into ChiTietNhanPhong values ((select top 1 MaPNP from PhieuNhanPhong order by MaPNP Desc),'" + it.SubItems[1].Text + "')") == 0)
                            MessageBox.Show("lỗi");
                    }
                    foreach (ListViewItem it2 in lvDichVuDaChon.Items)
                    {
                        if (Luucsdl("insert into ChiTietDichVu values ('" + it2.Text + "',(select top 1 MaPNP from PhieuNhanPhong order by MaPNP Desc))") == 0)
                            MessageBox.Show("lỗi");
                    }
                    Luucsdl("update PhieuDatPhong set TinhTrang='0' where MaPDP='"+lvDanhSachDat.Items[0].Text+"'");
                    MessageBox.Show("Nhận Phòng thành công");
                }
                else
                {
                    MessageBox.Show("lỗi");
                }
            }
            else
                MessageBox.Show("hiện tại Phiếu Đặt Phòng này vẫn chưa đến ngày nhận phòng xin hãy quay lại hệ thống để sửa lại ngày nhận phòng");
        }

        private void btNhap3_Click(object sender, EventArgs e)
        {
            lvDanhSachDichVu.Items.Clear();
            lvDanSachPhong.Items.Clear();
            DataTable dt = ketnoi(@"select * from KhachHang where CMND ='" + txtCMND3.Text + "'");
            DataTable dt2 = ketnoi(@"select n.MaPDP from PhieuDatPhong d, PhieuNhanPhong n where n.MaPDP=d.MaPDP and  CMND='" + txtCMND3.Text + "'and n.TinhTrang=1");

            if (dt2.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy thông tin đặt phòng từ số CMND đã nhập");
            }
            else
            {
                DataTable dt3 = ketnoi(@"select MaPNP,c.MaPhong ,TenLoai,Gia  from ChiTietDatPhong c, Phong p , LoaiPhong  l ,PhieuDatPhong dp, PhieuNhanPhong np
where c.MaPhong=p.MaPhong and p.MaLoai=l.MaLoai and dp.MaPDP=c.MaPDP and np.MaPDP = dp.MaPDP  and dp.MaPDP='"+ dt2.Rows[0][0].ToString() + "'");
                DataTable dt4 = ketnoi(@"select MaPNP from PhieuDatPhong d, PhieuNhanPhong n where d.MaPDP=n.MaPDP and CMND='" + txtCMND3.Text + "'");
                DataTable dt5 = ketnoi(@"select c.MaDV , TenDV ,Gia from ChiTietDichVu c, DichVu d where c.MaDV= d.MaDV and MaPNP ='" + dt3.Rows[0][0].ToString() + "'");
                lbHoTen3.Text = dt.Rows[0][1].ToString();
                lbSDT3.Text = dt.Rows[0][2].ToString();
                lbNgaySinh3.Text = dt.Rows[0][3].ToString();
                lbDiaChi3.Text = dt.Rows[0][5].ToString();
                if (dt.Rows[0][4].ToString() == "True")
                    lbGioiTinh3.Text = "nam";
                else
                    lbGioiTinh3.Text = "nữ";
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(); ;
                    item.Text = dt3.Rows[i][0].ToString();
                    item.SubItems.Add(dt3.Rows[i][1].ToString());
                    item.SubItems.Add(dt3.Rows[i][2].ToString());
                    item.SubItems.Add(dt3.Rows[i][3].ToString());
                    lvDanSachPhong.Items.Add(item);
                }
                for (int j = 0; j < dt5.Rows.Count; j++)
                {
                    ListViewItem item2 = new ListViewItem(); ;
                    item2.Text = dt5.Rows[j][0].ToString();
                    item2.SubItems.Add(dt5.Rows[j][1].ToString());
                    item2.SubItems.Add(dt5.Rows[j][2].ToString());
                    lvDanhSachDichVu.Items.Add(item2);
                }
                long tong = 0;
                foreach (ListViewItem it in lvDanSachPhong.Items)
                {
                    tong = tong + Int32.Parse(it.SubItems[3].Text);
                }
                DataTable tam = ketnoi(@"select d.MaPDP from PhieuDatPhong d, PhieuNhanPhong n where d.MaPDP=n.MaPDP and n.MaPNP='" + dt4.Rows[0][0].ToString() + "'");
                DataTable dt6 = ketnoi(@"select sum(songuoi) from LoaiPhong l ,Phong p,ChiTietDatPhong c
where l.MaLoai=p.MaLoai and c.MaPhong=p.MaPhong and c.MaPDP='" + tam.Rows[0][0].ToString() + "' group by c.MaPDP");
                foreach (ListViewItem it2 in lvDanhSachDichVu.Items)
                {
                   
                    tong = tong + (Int32.Parse(it2.SubItems[2].Text)* Int32.Parse(dt6.Rows[0][0].ToString()));
                }
                txtTongTien.Text = tong.ToString();
            }
        }

        private void btThanhToan_Click(object sender, EventArgs e)
        {
            if(Luucsdl("insert into HoaDon values (GETDATE(),'1',"+txtTongTien.Text+",1)") ==1)
            {
                DataTable dt = ketnoi(@"select top 1 MAHD from HoaDon order by MAHD desc");
                String mahd=dt.Rows[0][0].ToString();
                if(Luucsdl("insert into PhieuTraPhong values (GETDATE(),'"+txtCMND3.Text+"','"+ lvDanSachPhong.Items[0].Text+ "','"+mahd+"',1) ") ==1)
                {
                    
                    if(Luucsdl("update PhieuNhanPhong set tinhtrang=0 where MaPNP = '"+ lvDanSachPhong.Items[0].Text + "'")==1)
                        MessageBox.Show("Thanh Toán Thành Công");
                    else
                        MessageBox.Show("Lỗi");
                }
                else
                {
                    MessageBox.Show("Lỗi");
                }
            }
            else
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btAllKhachHang_Click(object sender, EventArgs e)
        {
            hienthi_khachhang();
        }

        private void btTimKhachHang_Click(object sender, EventArgs e)
        {
            if(txtCMND4.Text=="")
            {
                MessageBox.Show("Nhập Số CMND khách hàng cần tim");
            }
            else
            {
                DataTable Kh = ketnoi(@"select * from KhachHang where CMND='"+txtCMND4.Text+"'");
                if (Kh.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy khách hàng có số CMND trên");
                }
                else
                {
                    lvKhachHang.Items.Clear();
                    for (int k = 0; k < Kh.Rows.Count; k++)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = Kh.Rows[k][0].ToString();
                        item.SubItems.Add(Kh.Rows[k][1].ToString());
                        item.SubItems.Add(Kh.Rows[k][2].ToString());
                        item.SubItems.Add(Kh.Rows[k][3].ToString());
                        if (Kh.Rows[k][4].ToString() == "True")
                            item.SubItems.Add("nam");
                        else
                            item.SubItems.Add("nữ");
                        item.SubItems.Add(Kh.Rows[k][5].ToString());
                        lvKhachHang.Items.Add(item);

                    }
                }
            }
        }

        private void btThem_KhachHang_Click(object sender, EventArgs e)
        {
            DataTable db = ketnoi(@"select * from KhachHang where CMND='" + txtCMND_Nhap.Text + "'");
            if (db.Rows.Count != 0)
            {
                MessageBox.Show("Khách Hàng này đã có");
            }
            else
            {
                if (txtCMND_Nhap.Text == "" || txtHoTenNhap.Text == "" || txtSDTNhap.Text == "" || dateNgaySinhNhap.Text == "" || cbbGioiTinhNhap.Text == "" || txtDiaChiNhap.Text == "")
                {
                    MessageBox.Show("Hãy nhập đầy đủ thông tin của khách hàng");
                }
                else
                {
                    try
                    {
                        CSDL.con.Open();
                        String phai;
                        if (cbbGioiTinhNhap.Text == "nam")
                            phai = "1";
                        else
                            phai = "0";
                        SqlCommand com = new SqlCommand("insert into KhachHang values('" + txtCMND_Nhap.Text + "',N'"
                            + txtHoTenNhap.Text + "','" + txtSDTNhap.Text + "','" + dateNgaySinhNhap.Text + "',"
                            + phai + ",N'" + txtDiaChiNhap.Text + "')", CSDL.con);
                        com.ExecuteNonQuery();
                        CSDL.con.Close();
                        MessageBox.Show("Lưu thành công");
                        hienthi_khachhang();
                        capnhap_khachhang();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Lỗi");
                    }
                }
            }
        }

        private void btSua_KhachHang_Click(object sender, EventArgs e)
        {
            String phai;
            if (cbbGioiTinhNhap.Text == "Nam")
                phai = "1";
            else
                phai = "0";
            if (Luucsdl("update KhachHang set HoTen =N'"+txtHoTenNhap.Text+"',DienThoai='"+txtSDTNhap.Text+"',NgaySinh='"+dateNgaySinhNhap.Text+
                "',GioiTinh="+phai+",DiaChi=N'"+txtDiaChiNhap.Text+"' where CMND = '"+txtCMND_Nhap.Text+"'") ==1)
            {
                MessageBox.Show("Sửa thành công");
                hienthi_khachhang();
                capnhap_khachhang();
            }
            else
            {
                MessageBox.Show("lỗi");
            }
        }
        public void capnhap_khachhang()
        {
            txtCMND_Nhap.Text = "";
            txtHoTenNhap.Text = "";
            txtSDTNhap.Text = "";
            cbbGioiTinhNhap.Text = "";
            dateNgaySinhNhap.Text = "";
            txtDiaChiNhap.Text = "";
        }

        private void lvKhachHang_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var item = e.Item;
            txtCMND_Nhap.Text = item.Text;
            txtHoTenNhap.Text = item.SubItems[1].Text;
            txtSDTNhap.Text = item.SubItems[2].Text;
            dateNgaySinhNhap.Text = item.SubItems[3].Text;
            if (item.SubItems[4].Text == "True")
                cbbGioiTinhNhap.Text = "Nam";
            else
                cbbGioiTinhNhap.Text = "Nữ";
            txtDiaChiNhap.Text = item.SubItems[5].Text;

        }

        private void btnThemQL_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = ketnoi(@"select MaBP from BoPhan where TenBoPhan=N'" + cbbBoPhan_NV.Text + "'");
                DataTable dt2 = ketnoi(@"select MaCV from ChucVu where TenCV=N'" + cbbChucVu_nv.Text + "'");
                String gioitinh;
                if (cbbGioiTinh_nv.Text == "Nam")
                {
                    gioitinh = "1";
                }
                else
                {
                    gioitinh = "0";
                }
                if (Luucsdl("insert into NhanVien values(N'" + txtHoTen_nv.Text + "','" + dateNgaySinh_NV.Text + "'," + gioitinh + ",'"
                    + txtSDT_NV.Text + "',N'" + txtDiaChi_nv.Text + "','" + dt2.Rows[0][0].ToString() + "','" + dt.Rows[0][0].ToString() + "')") == 1)
                {
                    MessageBox.Show("Thêm Thành công");
                    hienthi_NhanVien();
                    capnhap_nv();
                }
                else
                {
                    MessageBox.Show("Lỗi");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void lvNhanVien_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var item = e.Item;
            manv = item.Text;
            txtHoTen_nv.Text = item.SubItems[1].Text;
            dateNgaySinh_NV.Text = item.SubItems[2].Text;
            cbbGioiTinh_nv.Text = item.SubItems[3].Text;
            txtSDT_NV.Text = item.SubItems[4].Text;
            txtDiaChi_nv.Text = item.SubItems[5].Text;
            cbbChucVu_nv.Text = item.SubItems[6].Text;
            cbbBoPhan_NV.Text = item.SubItems[7].Text;
        }

        private void btnXoaQL_Click(object sender, EventArgs e)
        {
            if(Luucsdl(" delete from NhanVien where MaNV='"+manv+"'") ==1)
            {
                MessageBox.Show("Xóa Thành Công");
                hienthi_NhanVien();
                capnhap_nv();
            }
            else
            {
                MessageBox.Show("Lỗi");
            }
        }
        private void btnSuaQL_Click(object sender, EventArgs e)
        {
            DataTable dt = ketnoi(@"select MaBP from BoPhan where TenBoPhan=N'" + cbbBoPhan_NV.Text + "'");
            DataTable dt2 = ketnoi(@"select MaCV from ChucVu where TenCV=N'" + cbbChucVu_nv.Text + "'");
            String gioitinh;
            if (cbbGioiTinh_nv.Text == "Nam")
            {
                gioitinh = "1";
            }
            else
            {
                gioitinh = "0";
            }
            if (Luucsdl(" update NhanVien set TenNV=N'"+txtHoTen_nv.Text+"',NgaySinh='"+dateNgaySinh_NV.Text+"',GioiTinh='"+gioitinh
                +"',DienThoai='"+txtSDT_NV.Text+"',DiaChi=N'"+txtDiaChi_nv.Text+"',MaCV='"+dt2.Rows[0][0].ToString()+"',MaBP='"+dt.Rows[0][0].ToString()+"' where MaNV='"+manv+"'") == 1)
            {
                MessageBox.Show("Sửa Thành Công");
                hienthi_NhanVien();
                capnhap_nv();
            }
            else
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btTim_nv_Click(object sender, EventArgs e)
        {
            DataTable dt;
            if(cbbTimKiem.Text== "MaNV")
            {
                dt = new DataTable();
                dt = ketnoi(@"select * from NhanVien where MaNV='"+txtNhap.Text+"'");
                hienthi_NhanVien2(dt);
                return;
            }
            if (cbbTimKiem.Text == "HoTen")
            {
                dt = new DataTable();
                dt = ketnoi(@"select * from NhanVien where TenNV like N'%" + txtNhap.Text + "%'");
                hienthi_NhanVien2(dt);
                return;
            }
            if (cbbTimKiem.Text == "Năm Sinh")
            {
                dt = new DataTable();
                dt = ketnoi(@"select * from NhanVien where Year(NgaySinh)='" + txtNhap.Text + "'");
                hienthi_NhanVien2(dt);
                return;
            }
            if (cbbTimKiem.Text == "Địa Chỉ")
            {
                dt = new DataTable();
                dt = ketnoi(@"select * from NhanVien where DiaChi like N'%" + txtNhap.Text + "%'");
                hienthi_NhanVien2(dt);
                return;
            }
        }

        private void dateNgayDatPhong_Click(object sender, EventArgs e)
        {

        }

        private void txtSoNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar<48 && e.KeyChar!=8 && e.KeyChar !=13|| e.KeyChar>57)
            {
                e.Handled = true;
                MessageBox.Show("Số lượng phòng phải là số nguyên");
                
            }
            capnhap_tapdatphong();
        }

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            for (int i = 0; i < KhachHang.Rows.Count; i++)
            {
                if (txtCMND.Text == KhachHang.Rows[i][0].ToString())
                {
                    txtHoTen.Text = KhachHang.Rows[i][1].ToString();
                    txtSDT.Text = KhachHang.Rows[i][2].ToString();
                    dateNgaySinh.Text = KhachHang.Rows[i][3].ToString();
                    cbbGioiTinh.Text = KhachHang.Rows[i][4].ToString();
                    txtDiaChi.Text = KhachHang.Rows[i][5].ToString();
                    co_datphong = 0;
                    capnhap_tapdatphong();
                    return;
                }
            }
            txtHoTen.Text = "";
            txtSDT.Text = "";
            dateNgaySinh.Text = "";
            cbbGioiTinh.Text = "";
            txtDiaChi.Text = "";
            co_datphong = 1;
            capnhap_tapdatphong();
        }
        public void capnhap_tapdatphong()
        {
            if(co_datphong==1)
            {
                if (txtHoTen.Text == "" || txtSDT.Text == "" || dateNgaySinh.Text == "" || cbbGioiTinh.Text == "" || txtDiaChi.Text == "")
                {
                    Luu.Enabled = false;
                }
                else
                {
                    Luu.Enabled = true;
                }
            }
            else
            {
                Luu.Enabled = false;
            }
            if(txtCMND.Text==""||dateNgayDatPhong.Text==""||dateNgayNhanPhong.Text==""||txtSoNgay.Text==""||lvDanhSachPhong.Items.Count==0)
            {
                btDatPhong.Enabled = false;
            }
            else
            {
                btDatPhong.Enabled = true;
            }
            if(txtSoLuong.Text=="" || cbbLoaiPhong.Text=="")
            {
                btThem.Enabled = false;
            }
            else
            {
                btThem.Enabled = true;
            }

        }

        private void dateNgayDatPhong_KeyPress(object sender, KeyPressEventArgs e)
        {
            capnhap_tapdatphong();
        }

        private void dateNgayNhanPhong_KeyPress(object sender, KeyPressEventArgs e)
        {
            capnhap_tapdatphong();
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            capnhap_tapdatphong();
        }

        private void cbbLoaiPhong_KeyPress(object sender, KeyPressEventArgs e)
        {
            capnhap_tapdatphong();
        }

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            //capnhap_tapdatphong();
        }

        private void txtDiaChi_MouseLeave(object sender, EventArgs e)
        {
            //capnhap_tapdatphong();
        }

        private void dateNgaySinh_MouseLeave(object sender, EventArgs e)
        {
            //capnhap_tapdatphong();
        }

        private void txtHoTen_KeyUp(object sender, KeyEventArgs e)
        {
            capnhap_khachhang();
        }
    }
    
}
