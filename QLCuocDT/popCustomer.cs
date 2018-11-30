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
    public partial class popCustomer : Form
    {
        List<KhachHang> Customers = new List<KhachHang>();
        KhachHang curKhachHang;
        QLTinhCuocDTEntities db = new QLTinhCuocDTEntities();
        public popCustomer()
        {
            InitializeComponent();
        }

        public frmSim frmSim { get; set; }

        private void popCustomer_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        public void RefreshData()
        {
            if (String.IsNullOrEmpty(txtSearch.Text))
            {
                Customers = db.KhachHangs.ToList();
            }
            else
            {
                Customers = db.KhachHangs.Where(x =>
                    x.TenKH.Contains(txtSearch.Text) ||
                    x.MaKH == txtSearch.Text ||
                    x.CMND == txtSearch.Text
                ).ToList();
            }

            gridControl1.DataSource = Customers;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            int[] ids = gridView1.GetSelectedRows();
            foreach(int id in ids)
            {
                KhachHang customer = gridView1.GetRow(id) as KhachHang;
                frmSim.UpdateCustomer(customer);
            }
        }
    }
}
