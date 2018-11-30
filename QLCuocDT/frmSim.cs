using QLCuocDT.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCuocDT
{
    public partial class frmSim : Form, IFormAction
    {
        List<ThongTinSIM> SIMs = new List<ThongTinSIM>();
        ThongTinSIM curSim;
        KhachHang curCustomer;
        QLTinhCuocDTEntities db = new QLTinhCuocDTEntities();
        public frmSim()
        {
            InitializeComponent();
        }

        public void Delete()
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    db.ThongTinSIMs.Remove(curSim);
                    db.SaveChanges();
                    RefreshData();
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show("Không thể xóa Sim đã có phát sinh cước");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        public void New()
        {
            curSim = new ThongTinSIM();
            curSim.KhachHang = new KhachHang();
            curCustomer = new KhachHang();
            ShowData(curSim);
        }

        public void RefreshData()
        {
            if (String.IsNullOrEmpty(txtSearch.Text))
            {
                SIMs = db.ThongTinSIMs.ToList();
            }
            else
            {
                SIMs = db.ThongTinSIMs.Where(x =>
                    x.IDSIM.Contains(txtSearch.Text) ||
                    x.MaKH == txtSearch.Text
                ).ToList();
            }

            gridControl1.DataSource = SIMs;
        }

        public void Save()
        {
            curSim.IDSIM = txtIDSim.Text;
            curSim.NgayDangKy = dtNgayDK.DateTime;
            curSim.NgayHetHan = dtNgayHetHan.DateTime;

            
            try
            {
                if (db.ThongTinSIMs.FirstOrDefault(x => x.IDSIM == curSim.IDSIM) != null)
                {
                    db.ThongTinSIMs.Attach(curSim);
                    db.Entry(curSim).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    curSim.KhachHang = db.KhachHangs.FirstOrDefault(x => x.MaKH == curSim.MaKH);
                    db.ThongTinSIMs.Add(curSim);
                    db.SaveChanges();
                }
                MessageBox.Show("Cập nhật thành công!");
                RefreshData();
            }
            catch(DbEntityValidationException e)
            {
                MessageBox.Show("Có lỗi xảy ra, không thể lưu");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra, không thể lưu");
            }
            
        }

        private void frmSim_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            int[] ids = gridView1.GetSelectedRows();
            foreach(int id in ids)
            {
                curSim = gridView1.GetRow(id) as ThongTinSIM;
                curCustomer = curSim.KhachHang;
                ShowData(curSim);
            }
        }

        private void ShowData(ThongTinSIM sim)
        {
            txtIDSim.Enabled = sim.IDSIM == null;
            txtIDSim.Text = sim.IDSIM;
            dtNgayDK.DateTime = sim.NgayDangKy.HasValue ? sim.NgayDangKy.Value : DateTime.Now;
            dtNgayHetHan.DateTime = sim.NgayHetHan.HasValue ? sim.NgayHetHan.Value : DateTime.Now;

            ShowCustomer();
        }

        private void ShowCustomer()
        {
            if (curCustomer == null)
                return;
            txtCusomterID.Text = curCustomer.MaKH;
            txtName.Text = curCustomer.TenKH;
            txtAddress.Text = curCustomer.DiaChi;
            txtCMND.Text = curCustomer.CMND;
            txtEmail.Text = curCustomer.Email;
            txtJob.Text = curCustomer.NgheNghiep;
            txtPosition.Text = curCustomer.ChucVu;
        }
        private void btnSelectCustomer_Click(object sender, EventArgs e)
        {
            popCustomer popCustomer = new popCustomer();
            popCustomer.frmSim = this;
            popCustomer.ShowDialog();
        }

        public void UpdateCustomer(KhachHang customer)
        {
            if (curSim == null)
                return;
            curCustomer = customer;
            curSim.MaKH = customer.MaKH;
            ShowCustomer();
        }
    }
}
