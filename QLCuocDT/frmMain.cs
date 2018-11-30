using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCuocDT
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private frmCustomer frmCustomer;
        private frmSim frmSim;
        private frmRegisterBill frmRegisterBill;
        private frmImport frmImport;
        private frmBillCharge frmBillCharge;
        public frmMain()
        {
            InitializeComponent();
        }

        public bool IsExistform(Form form)
        {
            if (form == null)
                return false;
            foreach (var child in MdiChildren)
            {
                if (child.Name == form.Name)
                {
                    child.Activate();
                    return true;
                }
            }
            return false;
        }

        private void navBtnKhachHang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (IsExistform(frmCustomer)) return;
            frmCustomer = new frmCustomer();
            frmCustomer.MdiParent = this;
            frmCustomer.Show();
        }

        private void navBtnSim_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (IsExistform(frmSim)) return;
            frmSim = new frmSim();
            frmSim.MdiParent = this;
            frmSim.Show();
        }

        private void navBtnRegister_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (IsExistform(frmRegisterBill)) return;
            frmRegisterBill = new frmRegisterBill();
            frmRegisterBill.MdiParent = this;
            frmRegisterBill.Show();
        }
        private void btnImport_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (IsExistform(frmImport)) return;
            frmImport = new frmImport();
            frmImport.MdiParent = this;
            frmImport.Show();
        }

        private void btnBillCharge_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (IsExistform(frmBillCharge)) return;
            frmBillCharge = new frmBillCharge();
            frmBillCharge.MdiParent = this;
            frmBillCharge.Show();
        }
        #region Basic Action
        private void barBtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var child = this.ActiveMdiChild;
            if (child == null)
                return;
            switch (child.Name)
            {
                case "frmCustomer":
                    frmCustomer.New();
                    break;

                case "frmSim":
                    frmSim.New();
                    break;

                case "frmRegisterBill":
                    frmRegisterBill.New();
                    break;

                case "frmImport":
                    frmImport.New();
                    break;

                case "frmBillCharge":
                    frmBillCharge.New();
                    break;

                default:
                    break;
            }
        }

        private void barBtnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var child = this.ActiveMdiChild;
            if (child == null)
                return;
            switch (child.Name)
            {
                case "frmCustomer":
                    frmCustomer.Save();
                    break;

                case "frmSim":
                    frmSim.Save();
                    break;

                case "frmRegisterBill":
                    frmRegisterBill.Save();
                    break;

                case "frmImport":
                    frmImport.Save();
                    break;

                case "frmBillCharge":
                    frmBillCharge.Save();
                    break;

                default:
                    break;
            }
        }

        private void barBtnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var child = this.ActiveMdiChild;
            if (child == null)
                return;
            switch (child.Name)
            {
                case "frmCustomer":
                    frmCustomer.Delete();
                    break;

                case "frmSim":
                    frmSim.Delete();
                    break;

                case "frmRegisterBill":
                    frmRegisterBill.Delete();
                    break;

                case "frmImport":
                    frmImport.Delete();
                    break;

                case "frmBillCharge":
                    frmBillCharge.Delete();
                    break;

                default:
                    break;
            }
        }

        private void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var child = this.ActiveMdiChild;
            if (child == null)
                return;
            switch (child.Name)
            {
                case "frmCustomer":
                    frmCustomer.RefreshData();
                    break;

                case "frmSim":
                    frmSim.RefreshData();
                    break;

                case "frmRegisterBill":
                    frmRegisterBill.RefreshData();
                    break;

                case "frmImport":
                    frmImport.RefreshData();
                    break;

                case "frmBillCharge":
                    frmBillCharge.RefreshData();
                    break;

                default:
                    break;
            }
        }



        #endregion
    }
}
