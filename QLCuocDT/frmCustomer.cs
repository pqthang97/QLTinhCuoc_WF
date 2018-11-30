using QLCuocDT.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCuocDT
{
    public partial class frmCustomer : Form, IFormAction
    {
        List<KhachHang> Customers = new List<KhachHang>();
        KhachHang curKhachHang;
        QLTinhCuocDTEntities db = new QLTinhCuocDTEntities();
        public frmCustomer()
        {
            InitializeComponent();
        }

        public void Delete()
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);
            if(dr == DialogResult.Yes)
            {
                try
                {
                    if(curKhachHang.ThongTinSIMs.Count > 0)
                    {
                        MessageBox.Show("Không thể xóa khách hàng đang sở hữu sim số");
                    }
                    else
                    {
                        db.KhachHangs.Remove(curKhachHang);
                        db.SaveChanges();
                        RefreshData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        public void New()
        {
            curKhachHang = new KhachHang();

            string newestKH = db.KhachHangs.OrderByDescending(x => x.MaKH).Select(x => x.MaKH).FirstOrDefault();
            if (newestKH != null)
            {
                try
                {
                    newestKH = newestKH.Substring(2);
                    int NumberKH = int.Parse(newestKH) + 1;
                    newestKH = "KH" + (NumberKH < 10 ? "0" + NumberKH.ToString() : NumberKH.ToString());
                }
                catch (ArgumentOutOfRangeException e)
                {
                    MessageBox.Show("Có lỗi xảy ra");
                }
            }
            else
            {
                newestKH = "KH01";
            }
            curKhachHang.MaKH = newestKH;

            ShowText(curKhachHang);
        }

        public void RefreshData()
        {
            if(String.IsNullOrEmpty(txtSearch.Text))
            {
                Customers = db.KhachHangs.Where(x => x.Flag == false).ToList();
            }
            else
            {
                Customers = db.KhachHangs.Where(x => 
                    x.TenKH.Contains(txtSearch.Text) ||
                    x.MaKH == txtSearch.Text ||
                    x.CMND == txtSearch.Text
                ).Where(x => x.Flag == false).ToList();
            }
            
            gridControl1.DataSource = Customers;
        }

        public void Save()
        {
            curKhachHang.TenKH = txtName.Text;
            curKhachHang.DiaChi = txtAddress.Text;
            curKhachHang.CMND = txtCMND.Text;
            curKhachHang.Email = txtEmail.Text;
            curKhachHang.NgheNghiep = txtJob.Text;
            curKhachHang.ChucVu = txtPosition.Text;

            try
            {
                if (db.KhachHangs.FirstOrDefault(x => x.MaKH == curKhachHang.MaKH) != null)
                {
                    db.KhachHangs.Attach(curKhachHang);
                    db.Entry(curKhachHang).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    db.KhachHangs.Add(curKhachHang);
                    db.SaveChanges();
                }
                MessageBox.Show("Cập nhật thành công");
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            int[] rows = gridView1.GetSelectedRows();
            foreach(int id in rows)
            {
                curKhachHang = gridView1.GetRow(id) as KhachHang;
                ShowText(curKhachHang);
            }
        }

        private void ShowText(KhachHang row)
        {
            txtCusomterID.Enabled = false;
            txtCusomterID.Text = row.MaKH;
            txtName.Text = row.TenKH;
            txtAddress.Text = row.DiaChi;
            txtCMND.Text = row.CMND;
            txtEmail.Text = row.Email;
            txtJob.Text = row.NgheNghiep;
            txtPosition.Text = row.ChucVu;

            gridControl2.DataSource = row.ThongTinSIMs;
        }
    }
}
