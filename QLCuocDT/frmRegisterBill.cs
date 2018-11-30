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
    public partial class frmRegisterBill : Form, IFormAction
    {
        List<HoaDonDangKy> Bills = new List<HoaDonDangKy>();
        ThongTinSIM curSim;
        HoaDonDangKy curBill;
        QLTinhCuocDTEntities db = new QLTinhCuocDTEntities();
        public frmRegisterBill()
        {
            InitializeComponent();
        }

        public void UpdateSim(ThongTinSIM sim)
        {
            curSim = sim;
            txtIDSim.Text = sim.IDSIM;
        }

        public void Delete()
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    db.HoaDonDangKies.Remove(curBill);
                    db.SaveChanges();
                    RefreshData();
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show("Không thể xóa hóa đơn");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        public void New()
        {
            curBill = new HoaDonDangKy();

            string newestBill = db.HoaDonDangKies.OrderByDescending(x => x.MaHDDK).Select(x => x.MaHDDK).FirstOrDefault();
            if (newestBill != null)
            {
                try
                {
                    newestBill = newestBill.Substring(2);
                    int NumberBill = int.Parse(newestBill) + 1;
                    newestBill = "HD" + (NumberBill < 10 ? "0" + NumberBill.ToString() : NumberBill.ToString());
                }
                catch (ArgumentOutOfRangeException e)
                {
                    MessageBox.Show("Có lỗi xảy ra");
                }
            }
            else
            {
                newestBill = "HD01";
            }
            curBill.MaHDDK = newestBill;
            curBill.ChiPhiDangKy = 50000;
            ShowData();
            //txtBillID.Enabled = true;
        }

        public void RefreshData()
        {
            if (String.IsNullOrEmpty(txtSearch.Text))
            {
                Bills = db.HoaDonDangKies.ToList();
            }
            else
            {
                Bills = db.HoaDonDangKies.Where(x =>
                    x.IDSIM.Contains(txtSearch.Text) ||
                    x.MaHDDK == txtSearch.Text
                ).ToList();
            }

            gridControl1.DataSource = Bills;
        }

        public void Save()
        {
            if (curBill == null)
                curBill = new HoaDonDangKy();
            curBill.IDSIM = txtIDSim.Text;
            curBill.ChiPhiDangKy = Convert.ToDecimal(txtPrice.Text);
            curBill.MaHDDK = txtBillID.Text;
            if (curBill.MaHDDK == null)
            {
                MessageBox.Show("Vui lòng nhập mã hợp đồng");
                return;
            }
            try
            {
                if (db.HoaDonDangKies.FirstOrDefault(x => x.MaHDDK == curBill.MaHDDK) != null)
                {
                    db.HoaDonDangKies.Attach(curBill);
                    db.Entry(curBill).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    if(db.HoaDonDangKies.FirstOrDefault(x => x.IDSIM == curBill.IDSIM) != null)
                    {
                        MessageBox.Show("Sim đã có người đăng ký, vui lòng chọn sim khác");
                    }

                    db.HoaDonDangKies.Add(curBill);
                    db.SaveChanges();
                }
                MessageBox.Show("Cập nhật thành công!");
                RefreshData();
            }
            catch (DbEntityValidationException e)
            {
                MessageBox.Show("Có lỗi xảy ra, không thể lưu");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra, không thể lưu");
            }
        }

        private void frmRegisterBill_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnSelectSim_Click(object sender, EventArgs e)
        {
            popSim popSim = new popSim();
            popSim.frmRegisterBill = this;
            popSim.ShowDialog();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            int[] ids = gridView1.GetSelectedRows();
            foreach (int id in ids)
            {
                curBill = gridView1.GetRow(id) as HoaDonDangKy;
                ShowData();
                txtBillID.Enabled = false;
            }
        }

        private void ShowData()
        {
            txtBillID.Text = curBill.MaHDDK;
            txtIDSim.Text = curBill.IDSIM;
            txtPrice.Text = curBill.ChiPhiDangKy.ToString();
        }
        
    }
}
