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
    public partial class frmBillCharge : Form, IFormAction
    {
        List<HoaDonTinhCuoc> Bills = new List<HoaDonTinhCuoc>();
        HoaDonTinhCuoc curBill;
        QLTinhCuocDTEntities db = new QLTinhCuocDTEntities();
        public frmBillCharge()
        {
            InitializeComponent();
        }

        public void Delete()
        {
            
        }

        public void New()
        {
            
        }

        public void RefreshData()
        {
            DateTime Date = dtDate.DateTime;
            DateTime From = new DateTime(Date.Year, Date.Month, 1);
            DateTime To = new DateTime(Date.Year, Date.Month, DateTime.DaysInMonth(Date.Year, Date.Month));
            Bills = db.HoaDonTinhCuocs.Where(x => x.NgayLapHD <= To && x.NgayLapHD >= From).ToList();

            gridControl1.DataSource = Bills;
        }

        public void Save()
        {
            if(curBill.ThanhToan == true)
            {
                DialogResult dr = MessageBox.Show("Hóa đơn này đã thanh toán, bạn có chắc chắn muốn hủy thanh toán?", "Thông báo", MessageBoxButtons.YesNo);
                if(dr == DialogResult.Yes)
                {
                    curBill.ThanhToan = false;
                    db.HoaDonTinhCuocs.Attach(curBill);
                    db.Entry(curBill).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                curBill.ThanhToan = true;
                db.HoaDonTinhCuocs.Attach(curBill);
                db.Entry(curBill).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            RefreshData();
        }

        private void frmBillCharge_Load(object sender, EventArgs e)
        {
            dtDate.DateTime = DateTime.Now;
            RefreshData();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            int[] ids = gridView1.GetSelectedRows();
            foreach(int id in ids)
            {
                curBill = gridView1.GetRow(id) as HoaDonTinhCuoc;
                DateTime Date = curBill.NgayLapHD.Value;
                DateTime From = new DateTime(Date.Year, Date.Month, 1);
                DateTime To = new DateTime(Date.Year, Date.Month, DateTime.DaysInMonth(Date.Year, Date.Month));
                gridControl2.DataSource = db.ChiTietSuDungs.Where(x => x.IDSIM == curBill.IDSIM).Where(x => x.TGBD >= From && x.TGBD <= To).ToList();
            }
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            List<String> IDSims = db.ThongTinSIMs.Select(x => x.IDSIM).Distinct().ToList();
            foreach(string sim in IDSims)
            {
                string MaHDTC = "HDTC" + DateTime.Now.Month + sim;
                if(db.HoaDonTinhCuocs.FirstOrDefault(x => x.MaHDTC == MaHDTC) != null)
                {
                    continue;
                }

                HoaDonTinhCuoc bill = new HoaDonTinhCuoc
                {
                    IDSIM = sim,
                    MaHDTC = MaHDTC,
                    NgayLapHD = DateTime.Now,
                    PhiThueBao = 50000,
                    ThanhToan = false,
                    ThongTinSIM = db.ThongTinSIMs.FirstOrDefault(x => x.IDSIM == sim),
                    TongTien = 0
                };

                decimal TongTien = 0;
                DateTime Date = bill.NgayLapHD.Value;
                DateTime From = new DateTime(Date.Year, Date.Month, 1);
                DateTime To = new DateTime(Date.Year, Date.Month, DateTime.DaysInMonth(Date.Year, Date.Month));
                List<ChiTietSuDung> ChiTiets = db.ChiTietSuDungs.Where(x => x.IDSIM == bill.IDSIM).Where(x => x.TGBD >= From && x.TGBD <= To).ToList();

                foreach(ChiTietSuDung ct in ChiTiets)
                {
                    TongTien += Convert.ToDecimal(ct.PhiCuocGoi);
                }
                bill.TongTien = bill.PhiThueBao + TongTien;

                db.HoaDonTinhCuocs.Add(bill);
                db.SaveChanges();
            }
            RefreshData();
        }

        private void dtDate_EditValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
