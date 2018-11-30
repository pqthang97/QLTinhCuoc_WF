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
    public partial class popSim : Form
    {
        List<ThongTinSIM> SIMs = new List<ThongTinSIM>();
        ThongTinSIM curSim;
        KhachHang curCustomer;
        QLTinhCuocDTEntities db = new QLTinhCuocDTEntities();
        public frmRegisterBill frmRegisterBill { get; set; }

        public popSim()
        {
            InitializeComponent();
        }

        private void popSim_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        public void RefreshData()
        {
            if (String.IsNullOrEmpty(txtSearch.Text))
            {
                SIMs = db.ThongTinSIMs.Where(x => x.Flag != true).ToList();
            }
            else
            {
                SIMs = db.ThongTinSIMs.Where(x =>
                    x.IDSIM.Contains(txtSearch.Text) ||
                    x.MaKH == txtSearch.Text
                ).Where(x => x.Flag != true).ToList();
            }

            gridControl1.DataSource = SIMs;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            int[] ids = gridView1.GetSelectedRows();
            foreach (int id in ids)
            {
                ThongTinSIM sim = gridView1.GetRow(id) as ThongTinSIM;
                frmRegisterBill.UpdateSim(sim);
                this.Close();
            }
        }
    }
}
