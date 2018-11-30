using QLCuocDT.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCuocDT
{
    public partial class frmImport : Form, IFormAction
    {
        List<ChiTietSuDung> ChiTiets = new List<ChiTietSuDung>();
        QLTinhCuocDTEntities db = new QLTinhCuocDTEntities();
        List<GiaCuoc> GiaCuocs = new List<GiaCuoc>();
        public frmImport()
        {
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if(dr == DialogResult.OK)
            {
                txtPath.Text = openFileDialog1.FileName;

                string[] Lines = File.ReadAllLines(txtPath.Text);
                ChiTiets = new List<ChiTietSuDung>();
                foreach (string line in Lines)
                {
                    string[] input = line.Split('\t');
                    ChiTietSuDung ct = new ChiTietSuDung()
                    {
                        IDSIM = input[0],
                        TGBD = DateTime.Parse(input[1]),
                        TGKT = DateTime.Parse(input[2]),
                        SoPhutSD = Convert.ToInt32((DateTime.Parse(input[2]) - DateTime.Parse(input[1])).TotalMinutes)
                    };
                    ct.PhiCuocGoi = TinhCuoc(ct);
                    ChiTiets.Add(ct);
                }

                gridControl1.DataSource = ChiTiets;
            }
        }

        private decimal TinhCuoc(ChiTietSuDung ct)
        {
            decimal Total = 0;
            
            if(ct.TGBD.Value.TimeOfDay >= TimeSpan.FromHours(7) && ct.TGKT.Value.TimeOfDay <= TimeSpan.FromHours(23))
            {
                Total = Convert.ToDecimal(ct.SoPhutSD * 200);
            }
            else
            {
                if(ct.TGBD.Value.TimeOfDay > TimeSpan.FromHours(23) || ct.TGBD.Value.TimeOfDay < TimeSpan.FromHours(7))
                {
                    if(ct.TGKT.Value.TimeOfDay < TimeSpan.FromHours(7) || ct.SoPhutSD <= 60)
                    {
                        Total = Convert.ToDecimal(ct.SoPhutSD * 200);
                    }
                    else
                    {
                        // 23h - 7h = 8h
                        Total = 8 * 60 * 200;

                        int sophut = (ct.TGKT.Value.TimeOfDay - TimeSpan.FromHours(7)).Minutes;
                        Total += sophut * 150;
                    }
                }
                else
                {
                    Total = Convert.ToDecimal(ct.SoPhutSD * 150);
                }
            }

            return Total;
        }

        private void frmImport_Load(object sender, EventArgs e)
        {
            GiaCuocs = db.GiaCuocs.ToList();
        }

        public void RefreshData()
        {
            GiaCuocs = new List<GiaCuoc>();
        }

        public void New()
        {
            RefreshData();
        }

        private string MaCTMoiNhat()
        {
            string newestKH = db.ChiTietSuDungs.OrderByDescending(x => x.MaChiTiet).Select(x => x.MaChiTiet).FirstOrDefault();
            if (newestKH != null)
            {
                try
                {
                    newestKH = newestKH.Substring(2);
                    int NumberKH = int.Parse(newestKH) + 1;
                    newestKH = "CT" + (NumberKH < 10 ? "0" + NumberKH.ToString() : NumberKH.ToString());
                }
                catch (ArgumentOutOfRangeException e)
                {
                    MessageBox.Show("Có lỗi xảy ra");
                }
            }
            else
            {
                newestKH = "CT001";
            }
            return newestKH;
        }

        public void Save()
        {
            foreach(ChiTietSuDung ct in ChiTiets)
            {
                try
                {
                    ct.MaChiTiet = MaCTMoiNhat();
                    db.ChiTietSuDungs.Add(ct);
                    db.SaveChanges();
                }
                catch(DbUpdateException e)
                {

                }
            }
        }

        public void Delete()
        {
            
        }
    }
}
